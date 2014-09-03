namespace ElecrtronicStoreSQLiteDB.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using ElecrtronicStoreSQLiteDB.Model;

    public static class SQLiteManager
    {
        public static void SaveData(AdditionalData data)
        {
            using (var context = new ElectronicStoreSQLiteContext())
            {
                context.AdditionalDatas.Add(data);
                context.SaveChanges();
            }
        }

        public static IEnumerable<AdditionalData> LoadAdditionalDataInfo()
        {
            using (var context = new ElectronicStoreSQLiteContext())
            {
                return context.AdditionalDatas.ToList();
            }
        }
    }
}
