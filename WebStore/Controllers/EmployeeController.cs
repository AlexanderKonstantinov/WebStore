﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;
using AutoMapper;

namespace WebStore.Controllers
{
    /// <summary>
    /// this controller for working with employee data
    /// </summary>
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IMapper _mapperEmployeeToEmployeeView;
        private readonly IMapper _mapperEmployeeViewToEmployee;


        private readonly IEmployeeData _employeeData;

        public EmployeeController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;

            _mapperEmployeeToEmployeeView =
                new Mapper(new MapperConfiguration(
                    config => config.CreateMap<Employee, EmployeeViewModel>()
                        .ForMember(nameof(EmployeeViewModel.Gender),
                            opt => opt.MapFrom(e => e.IsMan ? Gender.Man : Gender.Woman))));

            _mapperEmployeeViewToEmployee =
                new Mapper(new MapperConfiguration(
                    config => config.CreateMap<EmployeeViewModel, Employee>()
                    .ForMember(nameof(Employee.IsMan),
                            opt => opt.MapFrom(ev => Gender.Man == ev.Gender))));

        }


        /// <summary>
        /// Displaying employee list
        /// </summary>
        /// <returns>EmployeeList html page</returns>
        [Route("employees")]
        public IActionResult EmployeeList()
        {
            var employees = _mapperEmployeeToEmployeeView
                .Map<IEnumerable<Employee>, List<EmployeeViewModel>>(_employeeData.GetAll());

            return View(employees);
        } 

        /// <summary>
        /// Displaying employeeDetails
        /// </summary>
        /// <returns>EmployeeDetails html page</returns>
        [Route("employees/{id}")]
        public IActionResult EmployeeDetails(int id)
        {
            var employeeModel = _mapperEmployeeToEmployeeView
                .Map<Employee, EmployeeViewModel>(_employeeData.GetById(id));

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
            EmployeeViewModel employeeModel;

            if (id.HasValue)
            {
                var employee = _employeeData.GetById(id.Value);

                if (employee is null)
                    return NotFound();

                employeeModel = _mapperEmployeeToEmployeeView
                    .Map<Employee, EmployeeViewModel>(employee);

            }
            else
                employeeModel = new EmployeeViewModel();

            return View(employeeModel);
        }

        /// <summary>
        /// Redirecting EmployeeList View after additing or editing employee
        /// </summary>
        /// <param name="model">employee model</param>
        /// <returns>EmployeeList html page</returns>
        [HttpPost]
        [Route("employee_edit/{id?}")]
        public IActionResult Edit(EmployeeViewModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                if (employeeModel.Id > 0)
                {
                    var employee = _employeeData.GetById(employeeModel.Id);

                    if (employee is null)
                        return NotFound();

                    var  employeeEdit = _mapperEmployeeViewToEmployee
                        .Map<EmployeeViewModel, Employee>(employeeModel);

                    _employeeData.Edit(employeeEdit);
                }
                else
                {
                    var employeeNew = _mapperEmployeeViewToEmployee
                        .Map<EmployeeViewModel, Employee>(employeeModel);

                    _employeeData.AddNew(employeeNew);
                }
                
            }

            return View(employeeModel);
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