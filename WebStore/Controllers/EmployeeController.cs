using Microsoft.AspNetCore.Mvc;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;

namespace WebStore.Controllers
{
    /// <summary>
    /// this controller for working with employee data
    /// </summary>
    
    public class EmployeeController : Controller
    {
        private readonly IEmployeeData _employeeData;

        public EmployeeController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }
        

        /// <summary>
        /// Displaying employee list
        /// </summary>
        /// <returns>EmployeeList html page</returns>
        [Route("users")]
        public IActionResult EmployeeList() => View(_employeeData.GetAll());

        /// <summary>
        /// Displaying employeeDetails
        /// </summary>
        /// <returns>EmployeeCard html page</returns>
        [Route("users/{id}")]
        public IActionResult EmployeeCard(int id)
        {
            var selectedEmployee = _employeeData.GetById(id);

            if (selectedEmployee == null)
                return new ContentResult { Content = "Такой сотрудник отсутствует" };

            return View(selectedEmployee);
        }

        /// <summary>
        /// Adding or editing employee
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Edit html page</returns>
        [Route("edit/{id?}")]
        public IActionResult Edit(int? id)
        {
            EmployeeView model;
            if (id.HasValue)
            {
                model = _employeeData.GetById(id.Value);

                if (model is null)
                    return NotFound();
            }
            else
                model = new EmployeeView();

            return View(model);
        }

        /// <summary>
        /// Redirecting EmployeeList View after additing or editing employee
        /// </summary>
        /// <param name="model">employee model</param>
        /// <returns>EmployeeList html page</returns>
        [HttpPost]
        [Route("edit/{id?}")]
        public IActionResult Edit(EmployeeView model)
        {
            if (model.Id > 0)
            {
                var dbItem = _employeeData.GetById(model.Id);

                if (dbItem is null)
                    return NotFound();

                _employeeData.Edit(model);
            }
            else
                _employeeData.AddNew(model);

            return RedirectToAction(nameof(EmployeeList));
        }

        /// <summary>
        /// Deleting an employee
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>EmployeeList html page</returns>
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _employeeData.Delete(id);
            return RedirectToAction(nameof(EmployeeList));
        }
    }
}