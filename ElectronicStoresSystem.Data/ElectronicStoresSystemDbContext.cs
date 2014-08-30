namespace ElectronicStoresSystem.Data
{
    //using StudentSystem.Data.Migrations;
    using System.Data.Entity;
    
    using ElectronicStoresSystem.Models;

    public class ElectronicStoresSystemDbContext: DbContext
    {
        public ElectronicStoresSystemDbContext()
            : base("ElectronicSystemConection")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<ElectronicStoresSystemDbContext, Configuration>());
        }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Manufacturer> Manufacturers { get; set; }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Expense> Expenses { get; set; }

        public IDbSet<Sale> Sales { get; set; }

        public IDbSet<Store> Stores { get; set; }
    }
}
