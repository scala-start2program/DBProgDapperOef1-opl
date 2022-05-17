using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scala.Dapper1.Core.Services
{
    public class Helper
    {
        public static string GetConnectionString()
        {
            return @"Data Source=(local)\SQLEXPRESS;Initial Catalog=ScalaDapper1; Integrated security=true;";
        }
        public static string HandleQuotes(string value)
        {
            return value.Trim().Replace("'", "''");
        }
    }
}
