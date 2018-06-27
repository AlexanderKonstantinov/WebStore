using Microsoft.AspNetCore.Mvc;
using WebStore.Infrastructure.Base;
using WebStore.Infrastructure.Implementations;

namespace WebStore.Controllers
{
    /// <summary>
    /// this controller for working with employee data
    /// </summary>
    
    public class EmployeeController : Controller
    {
        private readonly IEmployeeData _employeeData;

        public EmployeeController()
        {
            _employeeData = new InMemoryEmployeeData();
        }

        /// <summary>
        /// Displaying hello page
        /// </summary>
        /// <returns>htmlPage</returns>
        [Route("users/index")]
        public IActionResult Index() => View();

        /// <summary>
        /// Displaying employee list
        /// </summary>
        /// <returns>htmlPage</returns>
        [Route("users")]
        public IActionResult EmployeeList() => View(_employeeData.GetAll());

        /// <summary>
        /// Displaying employeeDetails
        /// </summary>
        /// <returns>htmlPage</returns>
        [Route("users/{id}")]
        public IActionResult EmployeeCard(int id)
        {
            var selectedEmployee = _employeeData.GetEmployee(id);

            if (selectedEmployee == null)
                return new ContentResult { Content = "Такой сотрудник отсутствует" };

            return View(selectedEmployee);
        } 
    }
}