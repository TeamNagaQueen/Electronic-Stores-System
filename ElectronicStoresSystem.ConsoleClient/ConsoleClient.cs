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
            //var expenses = XmlReader.GetXmlInfo();
            //XmlReader.AddExpensesToSql(expenses);

            //var sqliteContext = new ElectronicStoreSQLiteContext();

            //var report = new AdditionalData
            //{
            //    ReportName = "Report"
            //};

            //sqliteContext.AdditionalData.Add(report);
            //Console.WriteLine(sqliteContext.SaveChanges());

            //var rep = sqliteContext.AdditionalData.Where(x => x.ReportId > 0);

            //foreach (var item in rep)
            //{
            //    Console.WriteLine(item.ReportId);
            //}

            //Console.WriteLine(sqliteContext.AdditionalData.First().ReportName);

            UpdateDatabase();

            using (var ctx = new ElectronicStoreMySQLFluentModel())
            {
                var pesho = new Report()
                {
                    ProductName = "asd",
                    Quantity = 5,
                    Price = 5,
                    StoreName = "name",
                    Sum = 15,
                };
                ctx.Add(pesho);
                ctx.Delete(pesho);
                ctx.SaveChanges();
            }

            Console.Write("Database update complete! Press any key to close.");
        }

        private static void UpdateDatabase()
        {
            using (var context = new ElectronicStoreMySQLFluentModel())
            {
                var schemaHandler = context.GetSchemaHandler();
                EnsureDB(schemaHandler);
            }
        }

        private static void EnsureDB(ISchemaHandler schemaHandler)
        {
            string script = null;

            if (schemaHandler.DatabaseExists())
            {
                script = schemaHandler.CreateUpdateDDLScript(null);
            }
            else
            {
                schemaHandler.CreateDatabase();
                script = schemaHandler.CreateDDLScript();
            }

            if (!string.IsNullOrEmpty(script))
            {
                schemaHandler.ExecuteDDLScript(script);
            }
        }
    }
}
