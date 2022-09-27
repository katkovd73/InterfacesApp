using System;

namespace DataAccessWithNoInterfaces
{
    class Program
    {

        // CLASSES to get data from different sources
        class DbDataProvider
        {
            public string GetData()
            {
                return "Data from Database";
            }
        }

        class FileDataProvider
        {
            public string GetData()
            {
                return "Data from File";
            }
        }

        class APIDataProvider
        {
            public string GetData()
            {
                return "Data from API";
            }
        }

        // Class that we use do display data.
        class ConsoleDataPrinter
        {
            public void DisplayData(string data)
            {
                Console.WriteLine(data);
            }
        }


        static void Main(string[] args)
        {
            ConsoleDataPrinter dataPocessor = new ConsoleDataPrinter();

            // Data from Db
            DbDataProvider dbDataProvider = new DbDataProvider();
            string dataFromDb = dbDataProvider.GetData();
            // Displaying data from Db
            dataPocessor.DisplayData(dataFromDb);

            // Data from File
            FileDataProvider fileDataProvider = new FileDataProvider();
            string dataFromFile = fileDataProvider.GetData();
            // Displaying data from File
            dataPocessor.DisplayData(dataFromFile);


            // Data from API
            APIDataProvider apiDataProvider = new APIDataProvider();
            string dataFromAPI = apiDataProvider.GetData();
            // Displaying data from File
            dataPocessor.DisplayData(dataFromAPI);

        }
    }
}
