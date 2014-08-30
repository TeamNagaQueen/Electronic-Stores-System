namespace MongoDb.Data
{
    using ElectronicStoresSystem.Models;
    using MongoDb.Data.Entities;

    public static class MongoParser
    {
        public static MongoCategory ParseCategory(Category category)
        {
            var result = new MongoCategory();

            result.CategoryId = category.CategoryId;
            result.CategoryName = category.CategoryName;

            return result;
        }

        public static MongoManufacturer ParseManufacturer(Manufacturer manufacturer)
        {
            var result = new MongoManufacturer();

            result.ManufacturerId = manufacturer.ManufacturerId;
            result.ManufacturerName = manufacturer.ManufacturerName;

            return result;
        }

        public static MongoProduct ParseProduct(Product product)
        {
            var result = new MongoProduct();

            result.ProductId = product.ProductId;
            result.ProductName = product.ProductName;
            result.ManufacturerId = product.ManufacturerId;
            result.BasePrice = product.BasePrice;
            result.CategoryId = product.CategoryId;

            return result;
        }
    }
}
