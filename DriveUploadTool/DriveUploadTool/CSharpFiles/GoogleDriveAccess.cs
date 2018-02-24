using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Google;
using Google.Apis.Auth.OAuth2;
//using Google.Apis.Download;
using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;
using Google.Apis.Logging;
using Google.Apis.Services;
using Google.Apis.Upload;

namespace DriveUploadTool
{
	class GoogleDriveAccess
	{
		#region Consts

		private const int KB = 0x400;
		private const int DownloadChunkSize = 256 * KB;

		/// <summary>
		/// Title of the file to insert.
		/// </summary>
		private string Title = @"";
		/// <summary>
		/// Description of the file to insert.
		/// </summary>
		private string Description = @"";
		/// <summary>
		/// Parent folder's ID.
		/// </summary>
		private string ParentId = @"";
		/// <summary>
		/// Filename of the file to insert.
		/// </summary>
		private string UploadFileName = @"";
		/// <summary>
		/// Content type of the file to insert.
		/// </summary>
		private string ContentType = @"";

		#endregion

		/// <summary>The logger instance.</summary>
		private static readonly ILogger Logger;

		/// <summary>The Drive API scopes.</summary>
		private static readonly string[] Scopes = new[] { DriveService.Scope.DriveFile, DriveService.Scope.Drive };

		/// <summary>
		/// The file which was uploaded.
		/// </summary>
		private static File uploadedFile;

		public GoogleDriveAccess(string Title, string Description, string ParentId, string UploadFileName, string ContentType)
		{
			if (string.IsNullOrEmpty(Title) )
			{
				return;
			}

			try
			{
				this.UploadFileName = UploadFileName;
				this.ContentType = ContentType;
				new GoogleDriveAccess(Title, Description, ParentId, UploadFileName, ContentType).Run().Wait();
			}
			catch (AggregateException ex)
			{
				foreach (var e in ex.InnerExceptions)
				{
					Console.WriteLine("ERROR: " + e.Message);
				}
			}

			Console.WriteLine("Press any key to continue...");
			Console.ReadKey();
		}
		private async Task Run()
		{
			GoogleWebAuthorizationBroker.Folder = "DriveUploadTool";
			UserCredential credential;
			using (var stream = new System.IO.FileStream("client_secrets.json",
				System.IO.FileMode.Open, System.IO.FileAccess.Read))
			{
				credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
					GoogleClientSecrets.Load(stream).Secrets, Scopes, "user", CancellationToken.None);
			}

			// Create the service.
			var service = new DriveService(new BaseClientService.Initializer()
			{
				HttpClientInitializer = credential,
				ApplicationName = "DriveUploadTool",
			});

			await UploadFileAsync(service, Title, Description, ParentId, ContentType, UploadFileName);

			// uploaded succeeded
			Console.WriteLine("\"{0}\" was uploaded successfully, fileID = {1}", uploadedFile.Title, uploadedFile.Id);
			CSharpFiles.FileIO.Instance.FileWrite("Upload.log", uploadedFile.Title + " was uploaded successfully, fileID = " + uploadedFile.Id, System.IO.FileMode.Append);
		}
		/// <summary>
		/// Uploads file asynchronously.
		/// </summary>
		/// <param name="service">Drive API service instance.</param>
		/// <param name="title">Title of the file to insert, including the extension.</param>
		/// <param name="description">Description of the file to insert.</param>
		/// <param name="parentId">Parent folder's ID.</param>
		/// <param name="mimeType">MIME type of the file to insert.</param>
		/// <param name="filename">Filename of the file to insert.</param>
		/// <returns></returns>
		private Task<IUploadProgress> UploadFileAsync(DriveService service, String title, String description, String parentId, String mimeType, String filename)
		{
			// File's metadata.
			File body = new File();
			body.Title = title;
			body.Description = description;
			body.MimeType = mimeType;

			// Set the parent folder.
			if (!String.IsNullOrEmpty(parentId))
			{
				body.Parents = new List<ParentReference>()
				{ new ParentReference() {Id = parentId}};
			}
			var uploadStream = new System.IO.FileStream(filename, System.IO.FileMode.Open,
				System.IO.FileAccess.Read);

			var insert = service.Files.Insert(body, uploadStream, mimeType);

			insert.ChunkSize = FilesResource.InsertMediaUpload.MinimumChunkSize * 2;
			insert.ProgressChanged += Upload_ProgressChanged;
			insert.ResponseReceived += Upload_ResponseReceived;

			var task = insert.UploadAsync();

			task.ContinueWith(t =>
			{
				// NotOnRanToCompletion - this code will be called if the upload fails
				Console.WriteLine("Upload Failed. " + t.Exception);
			}, TaskContinuationOptions.NotOnRanToCompletion);
			task.ContinueWith(t =>
			{
				Logger.Debug("Closing the stream");
				uploadStream.Dispose();
				Logger.Debug("The stream was closed");
			});

			return task;
		}

		#region Progress and Response changes
		static void Upload_ProgressChanged(IUploadProgress progress)
		{
			Console.WriteLine(progress.Status + " " + progress.BytesSent);
		}

		static void Upload_ResponseReceived(File file)
		{
			uploadedFile = file;
		}

		#endregion
	}
}
