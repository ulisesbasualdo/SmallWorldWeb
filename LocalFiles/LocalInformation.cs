using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallWorld.src.LocalFiles
{
    internal static class LocalInformation
    {
        static string connectionString = "Server=" + System.Net.Dns.GetHostName() + "\\SQLEXPRESS;Database=DbSmallWorld;Trusted_Connection=True;";

        static string connectionStringAlt = "Server=" + System.Net.Dns.GetHostName() + ";Database=DbSmallWorld;Trusted_Connection=True;Connect Timeout=5";

        public static string GetConnectionString()
        {
            return connectionString;
        }

        public static string GetConnectionStringAlt()
        {
            return connectionStringAlt;
        }
    }
}
