using System.Collections.Generic;
using WebStore.Models;

namespace WebStore.Services.Base
{
    /// <summary>
    /// Service connecting EmployeeController with EmployeeRepository
    /// </summary>
    public interface IEmployeeService
    {
        IEnumerable<EmployeeView> GetEmployees();
        EmployeeView GetEmployee(int Id);

        void Add(Employee employee);
        void Delete(int id);
        void Edit(Employee employee);
    }
}
