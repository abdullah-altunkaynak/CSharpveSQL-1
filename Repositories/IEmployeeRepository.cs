using CSharpveSQL_1.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpveSQL_1.Repositories
{
    internal interface IEmployeeRepository
    {
        DimEmployee GetById(int employeeKey);
        List<DimEmployee> GetAll();
    }
}
