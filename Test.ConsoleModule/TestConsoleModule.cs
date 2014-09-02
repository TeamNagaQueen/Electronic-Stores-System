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
    using ElectronicStoreMySQL.Model;
    using System.Collections.Generic;
    using Telerik.OpenAccess;
    using PDFModule;

    class TestConsoleModule
    {
        static void Main()
        {
            //Problem #1 – Load Excel Reports from ZIP File
            //ElectronicStoresSystemDbContext dbContext = new ElectronicStoresSystemDbContext();
            //XlsReader.ExtractZipReports();

            //var expenses = XmlReader.GetXmlInfo();
            //using (dbContext)
            //{
            //    MongoStartData.FillSampleCategories();
            //    MongoStartData.FillSampleManufacturers();
            //    MongoStartData.FillSampleProducts();
            //    MongoMigrator.MigrateMongoToSql(dbContext);
            //    var sales = XlsReader.ReadAllExcells();
            //    XlsMigrator.MigrateXslToSQL(dbContext, sales);
            //    XmlMigrator.MigrateXmlToSQL(dbContext, expenses);
            //}

            var reports = new List<Report>()
            { new Report { ProductName = "REPORT", Quantity = 100, Price = 200, StoreName = "Bakaliqta", Sum = 2000},
             new Report { ProductName = "VTORIQ", Quantity = 100, Price = 200, StoreName = "Bakaliqta", Sum = 2000 }};

            PDFCreator.CreatePDF(reports);

            // Use once if your MongoDB is empty else delete your Mongo DATABASE for the project so it will generate it new every time

            // Use once if your SQL Database is empty else delete your SQL DATABASE for the project so it will generate
            // the data for the tables
            //XmlReader.AddExpensesToSql(expenses);
        }
    }
}
