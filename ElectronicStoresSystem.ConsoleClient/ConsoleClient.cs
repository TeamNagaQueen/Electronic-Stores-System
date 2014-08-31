namespace ElectronicStoresSystem.ConsoleClient
{
    using System;
    using System.Linq;
    using ElectronicStoresSystem.Data;
    using MongoDB.Data;
    using MongoDb.Data;
    using MongoDb.Data.Entities;
    using ElectronicStoresSystem.Models;
    using XmlModule.cs;

    class ConsoleClient
    {
        static void Main()
        {
            //Problem #1 – Load Excel Reports from ZIP File
            ElectronicStoresSystemDbContext dbContext = new ElectronicStoresSystemDbContext();
            //XlsReader.ExtractZipReports();
            //
            //using (dbContext)
            //{
            //    dbContext.Categories.Add(new Category { CategoryName = "Smartphone" });
            //    dbContext.SaveChanges();
            //}

            //var sales = XlsReader.ReadAllExcells();
            //Console.WriteLine();

            //MongoMigrator.MigrateMongoToSql(dbContext);

            // Use once if your MongoDB is empty else delete your Mongo DATABASE for the project so it will generate it new every time
            //MongoStartData.FillSampleCategories();s
            //MongoStartData.FillSampleManufacturers();
            //MongoStartData.FillSampleProducts();

            // Use once if your SQL Database is empty else delete your SQL DATABASE for the project so it will generate
            // the data for the tables
            //MongoMigrator.MigrateMongoToSql(dbContext);
            var expenses = XmlReader.GetXmlInfo();
            XmlReader.AddExpensesToSql(expenses);
        }
    }
}
