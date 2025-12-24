using CSharpveSQL_1.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpveSQL_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // C# ve SQL kullanımı Ado.Net başlangıç
            // ADO.NET, SQL Server ve XML gibi veri kaynaklarına ve OLE DB ve ODBC aracılığıyla kullanıma sunulan veri kaynaklarına tutarlı erişim sağlar. (https://learn.microsoft.com/tr-tr/dotnet/framework/data/adonet/ado-net-overview)

            // data source localhost kullandığımız için bilgisayar adıdır, initial catalog kullanacağımız/bağlanacağımız veritabanı adıdır
            //string connectionString = "Data Source=DESKTOP-8HVGQU0;initial catalog=AdventureWorksDW2022;integrated security=true";
            //string queryString = "SELECT * FROM DimEmployee t where t.EmployeeKey = '1'";
            //CreateCommand(queryString, connectionString);
            //SelectCommand(queryString, connectionString);

            // Yukarıdaki basit kullanıma karşın aşşağıda daha profesyonel kullanım;
            // Repository Pattern ile veri erişimini soyutluyoruz
            IEmployeeRepository repo = new EmployeeRepository();

            var employee = repo.GetById(1);

            if (employee != null)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName}");
                Console.WriteLine(employee.DepartmentName);
            }

            Console.ReadKey();
        }
        private static void CreateCommand(string queryString, string connectionString)
        {
            // burada kod using bloğundan çıktığında bağlantı otomatik olarak kapanır.
            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        // Basit bir veri okuma metotu
        private static void SelectCommand(string queryString, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(queryString, connection);
                    command.Connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    foreach (DataRow row in dataTable.Rows)
                    {
                        foreach (var item in row.ItemArray) 
                        { 
                            Console.WriteLine(item.ToString());
                        }
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine($"SQL Error: {e.Message}");
                }
            }
        }
       
    }
}
