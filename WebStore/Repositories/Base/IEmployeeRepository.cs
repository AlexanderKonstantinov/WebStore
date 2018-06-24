using System.Collections.Generic;
using WebStore.Models;

namespace WebStore.Repositories.Base
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> Employees { get; }
    }
}
