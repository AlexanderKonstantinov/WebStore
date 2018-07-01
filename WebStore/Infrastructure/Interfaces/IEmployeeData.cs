using System.Collections.Generic;
using WebStore.Models;

namespace WebStore.Infrastructure.Interfaces
{
    /// <summary>
    /// Interface describe connecting EmployeeController with EmployeeRepository
    /// </summary>
    public interface IEmployeeData
    {
        /// <summary>
        /// Get employee list
        /// </summary>
        /// <returns></returns>
        IEnumerable<EmployeeView> GetAll();

        /// <summary>
        /// Get employee by id
        /// </summary>
        /// <param name="id">identifier</param>
        /// <returns>required employee or null if employee with such Id does not exist</returns>
        EmployeeView GetById(int id);

        /// <summary>
        /// Adding new employee
        /// </summary>
        /// <param name="employee">model of new employee</param>
        void AddNew(EmployeeView employee);

        /// <summary>
        /// Deleting employee by id
        /// </summary>
        /// <param name="id">identifier</param>
        void Delete(int id);

        /// <summary>
        /// Editing employee
        /// </summary>
        /// <param name="employee">correct model of employee</param>
        void Edit(EmployeeView employee);
    }
}
