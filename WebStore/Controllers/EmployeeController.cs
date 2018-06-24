using Microsoft.AspNetCore.Mvc;
using WebStore.Services;
using WebStore.Services.Base;

namespace WebStore.Controllers
{
    /// <summary>
    /// this controller for working with employee data
    /// </summary>
    public class EmployeesController : Controller
    {
        private IEmployeeService _employeeService;

        public EmployeesController()
        {
            _employeeService = new EmployeeService();
        }

        public IActionResult Index() => View();

        public IActionResult EmployeeList() => View(_employeeService.GetEmployees());
        
        public IActionResult EmployeeCard(int Id)
        {
            var selectedEmployee = _employeeService.GetEmployee(Id);
            return View(selectedEmployee);
        } 
    }
}