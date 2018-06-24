using System;
using System.Collections.Generic;
using WebStore.Models;
using WebStore.Repositories.Base;

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
    }
}
