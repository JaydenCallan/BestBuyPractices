using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestBuyPractices
{
    public interface IDepartmentRepo
    {
        IEnumerable<Department> GetDepartments();
    }
}
