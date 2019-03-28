using Employees.Data;
using System.Linq;

namespace Employees.Service.Services
{
    public interface IEmployeesServices
    {
        IQueryable<Employee> GetEmployees();
    }
}