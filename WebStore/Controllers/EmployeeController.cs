﻿using System.Linq;
 using Microsoft.AspNetCore.Authorization;
 using Microsoft.AspNetCore.Mvc;
 using WebStore.Domain.Entities;
 using WebStore.Infrastructure.Interfaces;
using WebStore.Models;

namespace WebStore.Controllers
{
    /// <summary>
    /// this controller for working with employee data
    /// </summary>
    [Authorize]
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
        [Route("employees")]
        public IActionResult EmployeeList()
        {
            var employees = _employeeData.GetAll();

            var employeesModel = employees.Select(
                e => new EmployeeViewModel
                {
                    Id = e.Id,
                    Gender = e.IsMan == true ? Gender.Man : Gender.Woman,
                    FirstName = e.FirstName,
                    SecondName = e.SecondName,
                    Patronymic = e.Patronymic,
                    Age = e.Age,
                    SecretName = e.SecretName,
                    Position = e.Position
                }
            );

            return View(employeesModel);
        } 

        /// <summary>
        /// Displaying employeeDetails
        /// </summary>
        /// <returns>EmployeeDetails html page</returns>
        [Route("employees/{id}")]
        public IActionResult EmployeeDetails(int id)
        {
            var selectedEmployee = _employeeData.GetById(id);

            if (selectedEmployee == null)
                return new ContentResult { Content = "Такой сотрудник отсутствует" };

            // Можно ли здесь взять данные из локальных?
            var employeeModel = new EmployeeViewModel
            {
                Id = selectedEmployee.Id,
                Gender = selectedEmployee.IsMan == true ? Gender.Man : Gender.Woman,
                FirstName = selectedEmployee.FirstName,
                SecondName = selectedEmployee.SecondName,
                Patronymic = selectedEmployee.Patronymic,
                Age = selectedEmployee.Age,
                SecretName = selectedEmployee.SecretName,
                Position = selectedEmployee.Position
            };

            return View(employeeModel);
        }

        /// <summary>
        /// Adding or editing employee
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>Edit html page</returns>
        [Route("employee_edit/{id?}")]
        public IActionResult Edit(int? id)
        {
            EmployeeViewModel model;

            if (id.HasValue)
            {
                var employee = _employeeData.GetById(id.Value);

                if (employee is null)
                    return NotFound();

                model = new EmployeeViewModel
                {
                    Id = employee.Id,
                    Gender = employee.IsMan ? Gender.Man : Gender.Woman,
                    FirstName = employee.FirstName,
                    SecondName = employee.SecondName,
                    Patronymic = employee.Patronymic,
                    Age = employee.Age,
                    SecretName = employee.SecretName,
                    Position = employee.Position
                };
            }
            else
                model = new EmployeeViewModel();

            return View(model);
        }

        /// <summary>
        /// Redirecting EmployeeList View after additing or editing employee
        /// </summary>
        /// <param name="model">employee model</param>
        /// <returns>EmployeeList html page</returns>
        [HttpPost]
        [Route("employee_edit/{id?}")]
        public IActionResult Edit(EmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id > 0)
                {
                    var employee = _employeeData.GetById(model.Id);

                    if (employee is null)
                        return NotFound();

                    _employeeData.Edit(
                        new Employee
                        {
                            Id = model.Id,
                            IsMan = model.Gender == Gender.Man,
                            FirstName = model.FirstName,
                            SecondName = model.SecondName,
                            Patronymic = model.Patronymic,
                            Age = model.Age,
                            SecretName = model.SecretName,
                            Position = model.Position
                        });
                }
                else
                    _employeeData.AddNew(new Employee
                    {
                        Id = model.Id,
                        IsMan = model.Gender == Gender.Man,
                        FirstName = model.FirstName,
                        SecondName = model.SecondName,
                        Patronymic = model.Patronymic,
                        Age = model.Age,
                        SecretName = model.SecretName,
                        Position = model.Position
                    });
            }

            return View(model);
        }

        /// <summary>
        /// Deleting an employee
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>EmployeeList html page</returns>
        [Route("employee_delete/{id}")]
        public IActionResult Delete(int id)
        {
            _employeeData.Delete(id);
            return RedirectToAction(nameof(EmployeeList));
        }
    }
}