using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpveSQL_1.Data
{
    // Bu Single Responsibility Principle için en net örnektir. Tek bir amaç için çalışır bir değişiklik olduğunda sadece tek bir yerden yapılan değişiklik heryeri etkiler.
    internal class DbConnectionFactory
    {
        private static readonly string _connectionString = ConfigurationManager
            .ConnectionStrings["AdventureWorksDW2022"]
            .ConnectionString;

        public static SqlConnection Create()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
