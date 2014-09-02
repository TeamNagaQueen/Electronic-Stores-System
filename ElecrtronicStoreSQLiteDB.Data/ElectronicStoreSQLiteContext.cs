using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElecrtronicStoreSQLiteDB.Data
{
    class ElectronicStoreSQLiteContext : DbContext
    {
        public IDbSet<Report> Reports { get; set; }
    }
}
