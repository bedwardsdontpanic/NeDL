using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_and_IoC_prac
{
    public class ProductService
    {
        private readonly FileLogger _fileLogger = new FileLogger();

        private readonly DatabaseLogger _databaseLogger = new DatabaseLogger();
        private ILogger logger;

        public ProductService(ILogger logger)
        {
            this.logger = logger;
        }

        public void Log(string message)
        {
            _fileLogger.Log(message);
        }

        public void Log2(string message)
        {
            Console.WriteLine("Inside Log method of DatabaseLogger.");
            LogToDatabase(message);
        }

        private void LogToDatabase(string message)
        {
            Console.WriteLine("Method: LogToDatabase, Text: {0}", message);
        }

        public void LogToFile(string message)
        {
            _fileLogger.Log(message);
        }


    }
}
