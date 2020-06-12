using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;

namespace EmployeeManagement.Web.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetDepartments();
        Task<Department> GetDepartment(int id);
    }
}
