using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage.Blob;

namespace PruebaAzure
{
    class Program
    {
        static void Main(string[] args)
        {

            FrameworkAzure azure = new FrameworkAzure("StorageConnectionString", "fercho");
            azure.DownloadFile(@"C:\Users\f.romerocuellar\Documents\TestAzure.txt");

    //        CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
    //CloudConfigurationManager.GetSetting("StorageConnectionString"));


    //        Microsoft.WindowsAzure.Storage.Blob.CloudBlobClient blobContainer = storageAccount.CreateCloudBlobClient();
    //        Microsoft.WindowsAzure.Storage.Blob.CloudBlobContainer blobFercho = blobContainer.GetContainerReference("fercho");
    //        blobFercho.CreateIfNotExists();
    //        string fileName = String.Format("{0}/TextBlob.txt",DateTime.Now.ToString("yyyy/MM/dd"));

    //        //CloudBlockBlob file1 = blobFercho.GetBlockBlobReference(@"Users/f.romerocuellar/Documents/David.sql");
    //        //file1.UploadFromFile(@"C:\Users\f.romerocuellar\Documents\David.sql");

    //        CloudBlockBlob file1 = blobFercho.GetBlockBlobReference(@"Users/f.romerocuellar/Documents/David.sql");
    //        file1.DownloadToFile(@"C:\Users\f.romerocuellar\Documents\Fercho.txt", System.IO.FileMode.Create);

        }
    }
}
