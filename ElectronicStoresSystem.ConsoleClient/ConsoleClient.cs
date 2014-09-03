namespace ElectronicStoresSystem.ConsoleClient
{
    using System;
    using System.Linq;
    using ElecrtronicStoreSQLiteDB.Model;
    using ElectronicStoresSystem.Data;
    using MongoDB.Data;
    using MongoDb.Data;
    using MongoDb.Data.Entities;
    using ElectronicStoresSystem.Models;
    using ElecrtronicStoreSQLiteDB.Data;
    using ElectronicStoreMySQL.Model;
    using Telerik.OpenAccess;
    using ElectronicStoreMySQL.Data;
    using XlsModule;
    using XmlModule;
    using PDFModule;

    class ConsoleClient
    {
        static void Main()
        {
            //Problem #1 – Load Excel Reports from ZIP File
            ElectronicStoresSystemDbContext dbContext = new ElectronicStoresSystemDbContext();
            //XlsReader.ExtractZipReports();
            //

            //var sales = XlsReader.ReadAllExcells();
            //
            //// Use once if your MongoDB is empty else delete your Mongo DATABASE for the project so it will generate it new every time
            //MongoStartData.FillSampleCategories();
            //MongoStartData.FillSampleManufacturers();
            //MongoStartData.FillSampleProducts();
            //
            //// Use once if your SQL Database is empty else delete your SQL DATABASE for the project so it will generate
            //// the data for the tables
            //MongoMigrator.MigrateMongoToSql(dbContext);
            //using (dbContext)
            //{
            //    XlsMigrator.MigrateXslToSQL(dbContext, sales);
            //    var expenses = XmlReader.GetXmlInfo();
            //    XmlMigrator.MigrateXmlToSQL(dbContext, expenses);
            //}

            //var sqliteContext = new ElectronicStoreSQLiteContext();

            //var report = new AdditionalData
            //{
            //    InfoId = 1,
            //    InfoDescription = "Report",
            //};
            //
            //SQLiteManager.SaveData(report);

            //var rep = SQLiteManager.LoadAdditionalDataInfo();

            //foreach (var item in rep)
            //{
            //    Console.WriteLine(item.InfoId);
            //}
            //
            //Console.WriteLine(sqliteContext.AdditionalDatas.First().InfoDescription);


            MySqlInitializer.UpdateDatabase();
            dbContext = new ElectronicStoresSystemDbContext();
            using (dbContext)
            {
                MySqlReportsMigrator.MigrateReports(dbContext);
            }

            Console.WriteLine(MySQLDataProvider.LoadReports().Count());

            Console.Write("Database update complete! Press any key to close.");
            var reports = MySQLDataProvider.LoadReports();

            PDFCreator.CreatePDF(reports);

            //var addInfo = new AdditionalData
            //{
            //    InfoDescription = "KJH",
            //    Mark = 15,
            //};

            //var sqliteCtx = new ElectronicStoreSQLiteContext();

            //sqliteCtx.AdditionalDatas.Add(addInfo);
            //sqliteCtx.SaveChanges();

            //foreach (var item in sqliteCtx.AdditionalDatas.ToList())
            //{
            //    Console.WriteLine("{0} -> {1}", item.InfoDescription, item.Mark);
            //}

        }
    }
}
