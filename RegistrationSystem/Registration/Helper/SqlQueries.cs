using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Registration.Helper
{
    public class SqlQueries
    {
       public static IConfiguration queriesConfig = new ConfigurationBuilder()
            .AddXmlFile("SqlQueries.xml", true, true)
            .Build();
        
        public static string RegisterEmployee { get { return queriesConfig["RegisterEmployee"]; } }
        public static string Login { get { return queriesConfig["Login"]; } }
    }
}
