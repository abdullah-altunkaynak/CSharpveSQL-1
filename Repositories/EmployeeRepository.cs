using CSharpveSQL_1.Data;
using CSharpveSQL_1.models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CSharpveSQL_1.Program;

namespace CSharpveSQL_1.Repositories
{
    internal class EmployeeRepository : IEmployeeRepository
    {
        public DimEmployee GetById(int employeeKey)
        {
            const string sql = @"
            SELECT *
            FROM DimEmployee
            WHERE EmployeeKey = @EmployeeKey";

            var connection = DbConnectionFactory.Create();
            var command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@EmployeeKey", employeeKey); // parametreli sorgu SQL injection önlemek için önemlidir

            connection.Open();

            var reader = command.ExecuteReader();

            if (!reader.Read())
                return null;

            return MapEmployee(reader);
        }

        public List<DimEmployee> GetAll()
        {
            const string sql = "SELECT * FROM DimEmployee";

            var list = new List<DimEmployee>();

            var connection = DbConnectionFactory.Create();
            var command = new SqlCommand(sql, connection);

            connection.Open();

            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                list.Add(MapEmployee(reader));
            }

            return list;
        }

        //mapping 
        private DimEmployee MapEmployee(SqlDataReader reader)
        {
            return new DimEmployee
            {
                EmployeeKey = reader.GetInt32(reader.GetOrdinal("EmployeeKey")),
                ParentEmployeeKey = reader["ParentEmployeeKey"] as int?,
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                Title = reader["Title"] as string,
                EmailAddress = reader["EmailAddress"] as string,
                DepartmentName = reader["DepartmentName"] as string,
                SalariedFlag = reader["SalariedFlag"] as bool?
            };
        }
    }
}
