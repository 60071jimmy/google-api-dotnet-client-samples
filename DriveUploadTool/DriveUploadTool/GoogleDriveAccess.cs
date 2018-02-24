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

		// CHANGE THIS with full path to the file you want to upload
		private const string UploadFileName = @"FILE_TO_UPLOAD";

		// CHANGE THIS if you upload a file type other than a jpg
		private const string ContentType = @"image/jpeg";

		#endregion

		/// <summary>The logger instance.</summary>
		private static readonly ILogger Logger;

		/// <summary>The Drive API scopes.</summary>
		private static readonly string[] Scopes = new[] { DriveService.Scope.DriveFile, DriveService.Scope.Drive };

		/// <summary>
		/// The file which was uploaded.
		/// </summary>
		private static File uploadedFile;

		public GoogleDriveAccess()
		{
			try
			{
				new GoogleDriveAccess().Run().Wait();
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

			await UploadFileAsync(service);

			// uploaded succeeded
			Console.WriteLine("\"{0}\" was uploaded successfully", uploadedFile.Title);
		}
		/// <summary>Uploads file asynchronously.</summary>
		private Task<IUploadProgress> UploadFileAsync(DriveService service)
		{
			var title = UploadFileName;
			if (title.LastIndexOf('\\') != -1)
			{
				title = title.Substring(title.LastIndexOf('\\') + 1);
			}

			var uploadStream = new System.IO.FileStream(UploadFileName, System.IO.FileMode.Open,
				System.IO.FileAccess.Read);

			var insert = service.Files.Insert(new File { Title = title }, uploadStream, ContentType);

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
