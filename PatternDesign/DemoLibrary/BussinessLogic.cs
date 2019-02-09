using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoLibrary.Utilities;

namespace DemoLibrary
{
    public class BussinessLogic : IBussinessLogic
    {

        IDataAccess _dataAccess;
        ILogger _logger;

        public BussinessLogic(ILogger logger, IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
            _logger = logger;
        }

        public void ProccessData()
        {
            _logger.Log("Starting, The process is running");
            Console.WriteLine("Processing tha data");
            _dataAccess.LoadData();
            _dataAccess.SaveData("Finished processing of teh data");
            Console.ReadLine();
        }
    }
}
