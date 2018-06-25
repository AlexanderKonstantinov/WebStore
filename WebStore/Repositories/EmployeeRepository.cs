using System;
using System.Collections.Generic;
using System.Linq;
using WebStore.Helpers;
using WebStore.Models;
using WebStore.Repositories.Base;

using static WebStore.Helpers.Logger;

namespace WebStore.Repositories
{
    /// <summary>
    /// This repository to interact with the database and retrieve data about employees
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        private static Random rnd = new Random();

        private static DateTime GetRandomWorkBeginning()
        {
            int year = rnd.Next(2008, 2019),
                month = rnd.Next(1, 13),
                day = DateTime.DaysInMonth(year, month);
            return new DateTime(year, month, day);
        }

        /// <summary>
        /// Test collection of employees
        /// </summary>
        private readonly List<Employee> employees = new List<Employee>
        {
            new Employee
            {
                Id = 1,
                IsMan = true,
                FirstName = "Иван",
                SecondName = "Иванов",
                Patronymic = "Иванович",
                Age = 20,
                SecretName = "Корпоративный герой",
                WorkBeginning = GetRandomWorkBeginning()
            },
            new Employee
            {
                Id = 2,
                IsMan = true,
                FirstName = "Пётр",
                SecondName = "Петров",
                Patronymic = "Петрович",
                Age = 23,
                SecretName = "Тёмная лошадка",
                WorkBeginning = GetRandomWorkBeginning()
            },
            new Employee
            {
                Id = 3,
                IsMan = true,
                FirstName = "Семён",
                SecondName = "Семёнов",
                Patronymic = "Семёнович",
                Age = 40,
                SecretName = "Любитель перерывов",
                WorkBeginning = GetRandomWorkBeginning()
            }
        };

        /// <summary>
        /// All employees contained into database
        /// </summary>
        public IEnumerable<Employee> Employees => employees ?? new List<Employee>();

        public void Add(Employee newEmployee)
        {
            if (employees.FirstOrDefault(e => e.Id == newEmployee.Id) == null)
                employees.Add(newEmployee);
            else
                Logging(newEmployee, DatabaseObjectError.AlreadyExist);
        } 

        public void Delete(int id)
        {
            var employee = employees.FirstOrDefault();

            if (employee != null)
                employees.Remove(employee);
            else
                // Нужно мнение насколько это плохо со стороны)
                Logging(new Employee {Id = id}, DatabaseObjectError.NotFound); 
        }

        public void Edit(Employee newEmployee)
        {
            var employee = employees.FirstOrDefault(e => e.Id == newEmployee.Id);

            if (employee != null)
            {
                employee.IsMan = newEmployee.IsMan;
                employee.FirstName = newEmployee.FirstName;
                employee.SecondName = newEmployee.SecondName;
                employee.Patronymic = newEmployee.Patronymic;
                employee.Age = newEmployee.Age;
                employee.SecretName = newEmployee.SecretName;
                employee.WorkBeginning = newEmployee.WorkBeginning;
            }
            else
                Logging(new Employee { Id = newEmployee.Id }, DatabaseObjectError.NotFound);
        }
    }
}
