using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureQueues
{
    class Program
    {
        static void Main(string[] args)
        {
            ManagerAzureQueues managerAzure = new ManagerAzureQueues("StorageConnectionString", "prebasferchoqueues");
            managerAzure.AddMessage(System.IO.File.ReadAllBytes(@"C:\Users\f.romerocuellar\Documents\TestAzure.txt"));
            var queue = managerAzure.Peek();
            managerAzure.DeleteMessage(queue.Id);
        }
    }
}
