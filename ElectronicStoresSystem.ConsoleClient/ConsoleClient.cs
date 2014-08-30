namespace ElectronicStoresSystem.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using ElectronicStoresSystem.Data;
    using ElectronicStoresSystem.Models;
    using XlsModule;

    class ConsoleClient
    {
        static void Main()
        {
            ElectronicStoresSystemDbContext dbContext = new ElectronicStoresSystemDbContext();
            XlsReader.ExtractZipReports();
            
            //using (dbContext)
            //{
            //    dbContext.Categories.Add(new Category { CategoryName = "Smartphone" });
            //    dbContext.SaveChanges();
            //}
        }
    }
}
