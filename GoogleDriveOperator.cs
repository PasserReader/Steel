using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;


using Google;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v3;
using Google.Apis.Services;


namespace WindowsApplication.Utility
{
    public enum GoogleFileType
    {
        Sheet, Text, Picture,Video
    }


    public class GoogleDriveObject
    {
        public UserCredential credential;
        public ClientSecrets clientSecrets { get; }
        public DriveService driveService;

        public GoogleDriveObject(string id, string secrets)
        {
            clientSecrets.ClientId = id;
            clientSecrets.ClientSecret = secrets;
        }
            
    }


    public static class GoogleDriveOperator
    {

        public static GoogleDriveObject CreateDriveObject(GoogleDriveObject driveObject)
        {
            GoogleDriveAuthorize(driveObject);
            CreateGoogleService(driveObject);

            return driveObject;
        }




        public static void Openfile(GoogleDriveObject dObject,string filePath)
        {
            
        }


        public static void CreateFile(string destination)
        {

        }


        /// <summary>
        /// Google用户认证
        /// </summary>
        /// <param name="driveObject"></param>
        static void GoogleDriveAuthorize(GoogleDriveObject driveObject)
        {
            driveObject.credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                driveObject.clientSecrets,
                new[] { DriveService.Scope.Drive },
                "someone",
                CancellationToken.None).Result;
        }


        static void CreateGoogleService(GoogleDriveObject driveObject)
        {
            driveObject.driveService = new DriveService(new BaseClientService.Initializer
            {
                HttpClientInitializer = driveObject.credential,
                ApplicationName = "Name"
            });
        }

    }
}
