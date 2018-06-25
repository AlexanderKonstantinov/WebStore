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

        void Add(Employee employee);
        void Delete(int id);
        void Edit(Employee employee);
    }
}
