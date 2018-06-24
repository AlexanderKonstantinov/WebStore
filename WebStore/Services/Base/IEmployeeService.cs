using System.Collections.Generic;
using WebStore.Models;

namespace WebStore.Services.Base
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeView> GetEmployees();
        EmployeeView GetEmployee(int Id);
    }
}
