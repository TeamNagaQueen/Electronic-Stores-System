namespace ElectronicStoresSystem.ConsoleClient
{
    using System;
    using System.Linq;
    using ElectronicStoresSystem.Data;
    using MongoDB.Data;
    using MongoDb.Data;
    using XlsModule;
    using XmlModule;
    using ElectronicStoresSystem.Models;

    class TestConsoleModule
    {
        static void Main()
        {
            //Problem #1 – Load Excel Reports from ZIP File
            ElectronicStoresSystemDbContext dbContext = new ElectronicStoresSystemDbContext();
            //XlsReader.ExtractZipReports();

            var expenses = XmlReader.GetXmlInfo();
            using (dbContext)
            {
                MongoStartData.FillSampleCategories();
                MongoStartData.FillSampleManufacturers();
                MongoStartData.FillSampleProducts();
                MongoMigrator.MigrateMongoToSql(dbContext);
                var sales = XlsReader.ReadAllExcells();
                XlsMigrator.MigrateXslToSQL(dbContext, sales);
                XmlMigrator.MigrateXmlToSQL(dbContext, expenses);
            }

            // Use once if your MongoDB is empty else delete your Mongo DATABASE for the project so it will generate it new every time

            // Use once if your SQL Database is empty else delete your SQL DATABASE for the project so it will generate
            // the data for the tables
            //XmlReader.AddExpensesToSql(expenses);
        }
    }
}
