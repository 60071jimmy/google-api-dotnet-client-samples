/// **********************************************
/// GoogleDriveAccess class
/// **********************************************

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

		/// <summary>
		/// GoogleDriveAccess constructor. This constructor would call GetContentTypeForFileName to get 
		/// MIME type of the input file. Title and description of the file to insert to Google Drive would
		/// be set as same as local filename.
		/// GoogleDriveAccess建構子。該建構子呼叫GetContentTypeForFileName方法取得欲上傳檔案之ContentType(MIME type)。
		/// 檔案描述(Description)及檔案標題(Title，Google雲端檔名)將與本地檔名相同。
		/// </summary>
		/// <param name="ParentId">Parent folder's ID on Google Drive.</param>
		/// <param name="UploadFileName">Local filename of the file to insert to Google Drive.</param>
		public GoogleDriveAccess(string ParentId, string UploadFileName)
		{
			if (string.IsNullOrEmpty(UploadFileName))
			{
				return;
			}
			string Title = UploadFileName;
			if (Title.LastIndexOf('\\') != -1)
			{
				Title = Title.Substring(Title.LastIndexOf('\\') + 1);
			}
			try
			{
				this.Title = Title;
				this.Description = Title;
				this.ParentId = ParentId;
				this.UploadFileName = UploadFileName;
				this.ContentType = GetContentTypeForFileName(UploadFileName);
				this.Run().Wait();
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

		/// <summary>
		/// GoogleDriveAccess constructor. This constructor would call GetContentTypeForFileName to get 
		/// MIME type of the input file. Description of the file to insert to Google Drive would be set
		/// as same as Title.
		/// GoogleDriveAccess建構子。該建構子呼叫GetContentTypeForFileName方法取得欲上傳檔案之ContentType(MIME type)。
		/// 檔案描述(Description)將與檔案標題(Title，Google雲端檔名)相同。
		/// </summary>
		/// <param name="Title">Title of the file to insert to Google Drive.</param>
		/// <param name="ParentId">Parent folder's ID on Google Drive.</param>
		/// <param name="UploadFileName">Local filename of the file to insert to Google Drive.</param>
		public GoogleDriveAccess(string Title, string ParentId, string UploadFileName)
		{
			if (string.IsNullOrEmpty(Title))
			{
				return;
			}
			if (string.IsNullOrEmpty(UploadFileName))
			{
				return;
			}
			try
			{
				this.Title = Title;
				this.Description = Title;
				this.ParentId = ParentId;
				this.UploadFileName = UploadFileName;
				this.ContentType = GetContentTypeForFileName(UploadFileName);
				this.Run().Wait();
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

		/// <summary>
		/// GoogleDriveAccess constructor. This constructor would call GetContentTypeForFileName to get 
		/// MIME type of the input file.
		/// GoogleDriveAccess建構子。該建構子呼叫GetContentTypeForFileName方法取得欲上傳檔案之ContentType(MIME type)。
		/// </summary>
		/// <param name="Title">Title of the file to insert to Google Drive.</param>
		/// <param name="Description">Description of the file to insert to Google Drive.</param>
		/// <param name="ParentId">Parent folder's ID on Google Drive.</param>
		/// <param name="UploadFileName">Local filename of the file to insert to Google Drive.</param>
		public GoogleDriveAccess(string Title, string Description, string ParentId, string UploadFileName)
		{
			if (string.IsNullOrEmpty(Title))
			{
				return;
			}
			if (string.IsNullOrEmpty(UploadFileName))
			{
				return;
			}
			try
			{
				this.Title = Title;
				this.Description = Description;
				this.ParentId = ParentId;
				this.UploadFileName = UploadFileName;
				this.ContentType = GetContentTypeForFileName(UploadFileName);
				this.Run().Wait();
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

		/// <summary>
		/// GoogleDriveAccess constructor.
		/// GoogleDriveAccess建構子。
		/// </summary>
		/// <param name="Title">Title of the file to insert to Google Drive.</param>
		/// <param name="Description">Description of the file to insert to Google Drive.</param>
		/// <param name="ParentId">Parent folder's ID on Google Drive.</param>
		/// <param name="UploadFileName">Local filename of the file to insert to Google Drive.</param>
		/// <param name="ContentType">MIME type of the file to insert.</param>
		public GoogleDriveAccess(string Title, string Description, string ParentId, string UploadFileName, string ContentType)
		{
			if (string.IsNullOrEmpty(Title) )
			{
				return;
			}
			if (string.IsNullOrEmpty(UploadFileName) )
			{
				return;
			}
			try
			{
				this.Title = Title;
				this.Description = Description;
				this.ParentId = ParentId;
				this.UploadFileName = UploadFileName;
				this.ContentType = ContentType;
				this.Run().Wait();
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
				try
				{
					Logger.Debug("Closing the stream");
					uploadStream.Dispose();
					Logger.Debug("The stream was closed");
				}
				catch (Exception)
				{
					
				}
			});

			return task;
		}

		#region Progress and Response changes
		static void Upload_ProgressChanged(IUploadProgress progress)
		{
			Console.WriteLine(	progress.Status + " " + 
								progress.BytesSent + " Bytes = " + 
								progress.BytesSent / KB + " KB = "
								);
		}

		static void Upload_ResponseReceived(File file)
		{
			uploadedFile = file;
		}

		#endregion

		#region Query ContentType
		/// <summary>
		/// GetContentTypeForFileName method could get ContentType of input file.
		/// Reference: https://dotblogs.com.tw/larrynung/2011/03/24/22049
		/// </summary>
		/// <param name="fileName">The file which ContentType would be returnd.</param>
		/// <returns>The ContentType of input file.</returns>
		private string GetContentTypeForFileName(string fileName)
		{
			string ext = System.IO.Path.GetExtension(fileName);
			using (Microsoft.Win32.RegistryKey registryKey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(ext))
			{
				if (registryKey == null)
					return null;
				var value = registryKey.GetValue("Content Type");
				return (value == null) ? string.Empty : value.ToString();
			}
		}
		#endregion

		#region Exponentiation translation
		/// <summary>
		/// Transform unit to KB.
		/// </summary>
		/// <param name="Byte">The number in Byte which would transform to KB.</param>
		/// <returns>Conversion result</returns>
		private long ByteToKB(long Byte)
		{
			return Byte / 0x400;
		}

		#endregion
	}
}
