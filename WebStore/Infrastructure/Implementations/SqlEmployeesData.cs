using System;
using System.Collections.Generic;
using System.Linq;
using WebStore.DAL.Context;
using WebStore.Domain.Entities;
using WebStore.Infrastructure.Interfaces;

namespace WebStore.Infrastructure.Implementations
{
    /// <summary>
    /// Layer between EmployeeController and Database
    /// Responsible for getting, updating for controller and view data transfer to the database 
    /// </summary>
    public class SqlEmployeesData : IEmployeesData
    {
        private readonly WebStoreContext _context;

        public SqlEmployeesData(WebStoreContext context)
        {
            _context = context;
        }


        public IEnumerable<Employee> GetAll()
            => _context.Employees.ToList();

        public Employee GetById(int id)
            => _context.Employees.AsQueryable().FirstOrDefault(e => e.Id == id);

        public void AddNew(Employee employee)
        {
            _context.Employees.Add(employee);

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var employee = GetById(id);

            if (employee is null)
                throw new Exception("Пользователь не найден");

            _context.Employees.Remove(employee);

            _context.SaveChanges();
        }

        public void Edit(Employee employee)
        {
            var oldEmployee = GetById(employee.Id);

            if (oldEmployee is null)
                throw new Exception("Пользователь не найден");

            oldEmployee.Age = employee.Age;
            oldEmployee.FirstName = employee.FirstName;
            oldEmployee.SecondName = employee.SecondName;
            oldEmployee.Patronymic = employee.Patronymic;
            oldEmployee.IsMan = employee.IsMan;
            oldEmployee.Position = employee.Position;
            oldEmployee.SecretName = employee.SecretName;

            _context.SaveChanges();
        }
    }
}
