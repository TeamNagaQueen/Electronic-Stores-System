namespace ElectronicStoresSystem.ConsoleClient
{
    using System;
    using System.Collections.Generic;
    using ElectronicStoresSystem.Data;
    using ElectronicStoresSystem.Models;

    class ConsoleClient
    {
        static void Main()
        {
            ElectronicStoresSystemDbContext dbContext = new ElectronicStoresSystemDbContext();

            using (dbContext)
            {
                dbContext.Categories.Add(new Category { CategoryName = "Smartphone" });
                dbContext.SaveChanges();
            }
        }
    }
}
