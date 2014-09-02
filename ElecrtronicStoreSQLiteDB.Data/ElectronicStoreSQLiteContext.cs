namespace ElecrtronicStoreSQLiteDB.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ElecrtronicStoreSQLiteDB.Model;

    public class ElectronicStoreSQLiteContext : DbContext
    {
        public ElectronicStoreSQLiteContext()
            : base("SQLITE_URI")
        {
        }

        public IDbSet<AdditionalData> AdditionalData { get; set; }
    }
}
