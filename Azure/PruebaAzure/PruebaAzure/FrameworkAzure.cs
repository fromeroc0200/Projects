using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaAzure
{
    public class FrameworkAzure
    {
        private string _container;
        CloudStorageAccount storageAccount = null;
        Microsoft.WindowsAzure.Storage.Blob.CloudBlobClient blobContainer = null;
        Microsoft.WindowsAzure.Storage.Blob.CloudBlobContainer blobFercho = null;
        private bool _hasError = false;
        private string _message;


        public FrameworkAzure(string connectionString, string container)
        {
            storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting(connectionString));
            blobContainer = storageAccount.CreateCloudBlobClient();
            blobFercho = blobContainer.GetContainerReference(container);
            blobFercho.CreateIfNotExists();
            _container = container;
        }

        public bool HasError { get => _hasError; set => _hasError = value; }
        public string Message { get => _message; set => _message = value; }

        public void DownloadFile(string FileName)
        {
            DownloadFile(System.IO.Path.GetFileName(FileName), FileName);
        }

        public void DownloadFile(string nameBlob, string fileName)
        {
            try
            {
                CloudBlockBlob cloudBlock = blobFercho.GetBlockBlobReference(nameBlob);
                cloudBlock.DownloadToFile(fileName, System.IO.FileMode.Create);
            }
            catch (Exception ex)
            {
                _hasError = true;
                _message = ex.Message;
            }
        }
        

    }
}
