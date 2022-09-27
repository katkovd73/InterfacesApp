using System;

namespace DataAccessWithInterfaces
{
    class Program
    {
        // inside interfaces
        // no constructors
        // no variables / fields
        // no access modifiers - all method signatures are public by default
        // interface reference stores information about objects of all classes that implement that interface


        // INTERFACES
        interface IDataProvider
        {
            string GetData();
        }

        interface IDataDisplay
        {
            void DisplayData(IDataProvider dataProvider);
        }


        // CLASSES to get data from different sources
        class DbDataProvider : IDataProvider
        {
            public string GetData()
            {
                return "Data from Database";
            }
        }

        class FileDataProvider : IDataProvider
        {
            public string GetData()
            {
                return "Data from File";
            }
        }

        class APIDataProvider : IDataProvider
        {
            public string GetData()
            {
                return "Data from API";
            }
        }


        // Class that we use do display data. It doesn't matter where the data comes from - Database, File, or API
        class ConsoleDataPrinter : IDataDisplay
        {
            public void DisplayData(IDataProvider dataProvider)
            {
                Console.WriteLine(dataProvider.GetData());
            }
        }


        // MAIN CLASS
        static void Main(string[] args)
        {
            IDataDisplay dataProcessor = new ConsoleDataPrinter();

            dataProcessor.DisplayData(new DbDataProvider());
            dataProcessor.DisplayData(new FileDataProvider());
            dataProcessor.DisplayData(new APIDataProvider());

        }
    }
}
