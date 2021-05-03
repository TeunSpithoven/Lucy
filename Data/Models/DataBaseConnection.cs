using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public static class DataBaseConnection
    {
        public static string String =
            "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog = Lucy; Integrated Security = True; Connect Timeout = 30; " +
            "Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}
