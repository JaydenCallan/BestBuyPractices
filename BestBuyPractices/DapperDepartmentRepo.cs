using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyPractices
{
    public class DapperDepartmentRepo
    {
        public class DapperDepartmentRepository : IDepartmentRepo
        {
            private readonly IDbConnection _connection;
            //Constructor
            public DapperDepartmentRepository(IDbConnection connection)
            {
                _connection = connection;
            }

            public IEnumerable<Department> GetDepartments()
            {
                return _connection.Query<Department>("SELECT * FROM Departments;");
            }

            public void InsertDepartment(string newDepartmentName)
            {
                _connection.Execute("INSERT INTO DEPARTMENTS (Name) VALUES (@departmentName);",
                new { departmentName = newDepartmentName });
            }

        }
    }
}