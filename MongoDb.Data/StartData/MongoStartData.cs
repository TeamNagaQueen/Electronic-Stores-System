namespace MongoDb.Data
{
    using System;
    using System.Linq;
    using MongoDB.Data;
    using MongoDb.Data.Entities;
    using ElectronicStoresSystem.Data;

    public static class MongoStartData
    {
        private static Random rand = new Random();

        public static void FillSampleManufacturers()
        {
            var manufacturers = new string[] { "Samsung", "Nokia", "Apple", "LG Electronics", 
                                                "ZTE", "Huawei", "TCL Communication", "Lenovo",
                                                "Sony Mobile Communications", "Yulong" };

            for (int i = 0; i < manufacturers.Length; i++)
            {
                var manufacturer = new MongoManufacturer
                {
                    ManufacturerId = i,
                    ManufacturerName = manufacturers[i],
                };

                MongoDbProvider.SaveData<MongoManufacturer>(MongoDbProvider.db, manufacturer);
            }
        }

        public static void FillSampleCategories()
        {
            var categories = new string[] { "Smartphone", "Laptop", "Tablet", "PersonalComputer", "Oven", 
                                            "LED Tellevisor", "Microwave", "Toaster", "Printer", 
                                            "Vibrator", "Vacuum cleaner", "Boiler" };

            for (int i = 0; i < categories.Length; i++)
            {
                var category = new MongoCategory
                {
                    CategoryId = i,
                    CategoryName = categories[i],
                };

                MongoDbProvider.SaveData<MongoCategory>(MongoDbProvider.db, category);
            }
        }

        public static void FillSampleProducts()
        {
            var manufacturers = MongoDbProvider.LoadData<MongoManufacturer>(MongoDbProvider.db);
            var categories = MongoDbProvider.LoadData<MongoCategory>(MongoDbProvider.db);

            for (int i = 0; i < 1000; i++)
            {
                var categoryId = rand.Next(1, categories.Count());
                var manufacturerId = rand.Next(1, manufacturers.Count());

                var product = new MongoProduct
                {
                    BasePrice = (rand.Next(1, 1000) + categoryId + manufacturerId),
                    CategoryId = categoryId,
                    ManufacturerId = manufacturerId,
                    ProductId = i + 1,
                    ProductName = manufacturers.ToList()[manufacturerId].ManufacturerName + "'s " + categories.ToList()[categoryId].CategoryName,
                };

                MongoDbProvider.SaveData<MongoProduct>(MongoDbProvider.db, product);
            }
        }
    }
}
