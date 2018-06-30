using System.Collections.Generic;
using System.Linq;
using WebStore.Helpers;
using WebStore.Models;
using WebStore.Repositories.Interfaces;

namespace WebStore.Repositories.Implementations
{
    /// <summary>
    /// This repository to interact with the database and retrieve data about employees
    /// Responsible for adding, deleting and editing information about employees to the database
    /// </summary>
    public class EmployeeRepository : IEmployeeRepository
    {
        private static int _maxId;

        /// <summary>
        /// Test collection of employees
        /// </summary>
        private readonly List<Employee> _employees;

        public EmployeeRepository()
        {
            _employees = new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Sex = Sex.Man,
                    FirstName = "Иван",
                    SecondName = "Иванов",
                    Patronymic = "Иванович",
                    Age = 20,
                    SecretName = "Корпоративный герой",
                    Position = "Продавец"
                },
                new Employee
                {
                    Id = 2,
                    Sex = Sex.Woman,
                    FirstName = "Наталья",
                    SecondName = "Сидорова",
                    Patronymic = "Владимировна",
                    Age = 23,
                    SecretName = "Девушка с большой буквы \"С\"",
                    Position = "Системный администратор"
                },
                new Employee
                {
                    Id = 3,
                    Sex = Sex.Man,
                    FirstName = "Семён",
                    SecondName = "Семёнов",
                    Patronymic = "Семёнович",
                    Age = 40,
                    SecretName = "Любитель перерывов",
                    Position = "Бухгалтер"
                }
            };

            _maxId = _employees.Select(e => e.Id).Max();
        }

        /// <summary>
        /// All employees contained into database
        /// </summary>
        public IEnumerable<Employee> Employees => _employees ?? new List<Employee>();

        public bool Add(Employee newEmployee)
        {
            if (_employees?.FirstOrDefault(e => e.Id == newEmployee.Id) == null)
            {
                newEmployee.Id = ++_maxId;
                _employees.Add(newEmployee);
                return true;
            }

            throw new AlreadyExistException();
        } 

        public bool Delete(int id)
        {
            var employee = _employees.FirstOrDefault();

            if (employee != null)
            {
                _employees.Remove(employee);
                return true;
            }

            throw new NotFoundException();
        }

        public bool Edit(Employee newEmployee)
        {
            var index = _employees.FindIndex(e => e.Id == newEmployee.Id);

            if (index != -1)
            {
                _employees[index] = newEmployee;
                return true;
            }

            throw new NotFoundException();
        }
    }
}
