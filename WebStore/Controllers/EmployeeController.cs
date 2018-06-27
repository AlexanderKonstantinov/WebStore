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
        private IEmployeeData _employeeData;

        public EmployeeController()
        {
            _employeeData = new InMemoryEmployeeData();
        }

        [Route("users/index")]
        public IActionResult Index() => View();

        [Route("users")]
        public IActionResult EmployeeList() => View(_employeeData.GetAll());
        
        [Route("users/{id}")]
        public IActionResult EmployeeCard(int id)
        {
            var selectedEmployee = _employeeData.GetEmployee(id);
            return View(selectedEmployee);
        } 
    }
}