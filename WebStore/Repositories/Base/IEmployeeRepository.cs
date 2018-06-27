using System.Collections.Generic;
using WebStore.Models;

namespace WebStore.Repositories.Base
{
    /// <summary>
    /// Get, add, delete and edit employee data
    /// </summary>
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> Employees { get; }

        bool Add(Employee employee);
        bool Delete(int id);
        bool Edit(Employee employee);
    }
}
