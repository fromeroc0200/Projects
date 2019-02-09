using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureQueues
{
    public class ManagerAzureQueues
    {
        Microsoft.WindowsAzure.Storage.Auth.StorageCredentials storageCredentials = null;
        CloudStorageAccount storageAccount = null;
        CloudQueueClient cloudQueueClient = null;
        CloudQueue queue = null;
        public ManagerAzureQueues(string azureAccount, string azurekey, string queueName, bool useHttps)
        {
            storageCredentials = new Microsoft.WindowsAzure.Storage.Auth.StorageCredentials(azureAccount, azurekey);
            storageAccount = new CloudStorageAccount(storageCredentials, useHttps);
            cloudQueueClient = storageAccount.CreateCloudQueueClient();
            queue = cloudQueueClient.GetQueueReference(queueName);
            queue.CreateIfNotExists();
        }

        public ManagerAzureQueues(string connectionString,string queueName)
        {
            storageAccount = CloudStorageAccount.Parse(
               CloudConfigurationManager.GetSetting(connectionString));
            cloudQueueClient = storageAccount.CreateCloudQueueClient();
            queue = cloudQueueClient.GetQueueReference(queueName);
            queue.CreateIfNotExists();
        }

        public void AddMessage(byte[] docAsBytes)
        {
            CloudQueueMessage queueMessage = new CloudQueueMessage(docAsBytes);            
            queue.AddMessage(queueMessage);
        }

        public CloudQueueMessage GetMessage()
        {
            return queue.GetMessage();
        }

        public CloudQueueMessage Peek()
        {
            return queue.PeekMessage();
        }

        public void DeleteMessage(string id)
        {
            var message = queue.GetMessages(32).Where(x => String.Equals(x.Id, id, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault();
            queue.DeleteMessage(message);
        }
    
    }
}
