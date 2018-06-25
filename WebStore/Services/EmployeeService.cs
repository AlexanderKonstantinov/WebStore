using System;
using System.Collections.Generic;
using System.Linq;
using WebStore.Models;
using WebStore.Repositories;
using WebStore.Repositories.Base;
using WebStore.Services.Base;

namespace WebStore.Services
{
    /// <summary>
    /// Layer between EmployeeController and EmployeeRepository
    /// </summary>
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService()
        {
            _employeeRepository = new EmployeeRepository();
        }

        public IEnumerable<EmployeeView> GetEmployees()
        {
            List<EmployeeView> employeeViewList = new List<EmployeeView>(_employeeRepository.Employees.Count());

            foreach (var employee in _employeeRepository.Employees)
                employeeViewList.Add(new EmployeeView(employee));

            return employeeViewList;
        }

        public EmployeeView GetEmployee(int Id)
            => new EmployeeView(_employeeRepository.Employees.FirstOrDefault(e => e.Id == Id))
            ?? throw new Exception("Работник не найден");

        public void Add(Employee newEmployee) => _employeeRepository.Add(newEmployee);

        public void Delete(int id) => _employeeRepository.Delete(id);

        public void Edit(Employee newEmployee) => _employeeRepository.Edit(newEmployee);
    }
}
