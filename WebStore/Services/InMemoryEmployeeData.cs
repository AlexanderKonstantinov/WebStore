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
    /// Responsible for getting, updating for controller and view data transfer to the repository 
    /// </summary>
    public class InMemoryEmployeeData : IEmployeeData
    {
        private readonly IEmployeeRepository _employeeRepository;

        // Решил сделать через приватное свойство, а не readonly-поле,
        // чтобы можно было изменять данные, хранящиеся в нём, методом UpdateEmployees
        // после редактирования
        // Имеет ли это смысл или я усложнил код?
        private List<EmployeeView> Employees { get; set; }


        public InMemoryEmployeeData()
        {
            _employeeRepository = new EmployeeRepository();

            UpdateEmployees();
        }
        
        public IEnumerable<EmployeeView> GetAll() => Employees;

        public EmployeeView GetEmployee(int id) => Employees.FirstOrDefault(e => e.Id == id);

        public void AddNew(EmployeeView model)
        {
            if (_employeeRepository.Add(new Employee
            {
                Position = model.Position,
                Age = model.Age,
                FirstName = model.FirstName,
                SecondName = model.SecondName,
                Patronymic = model.Patronymic,
                IsMan = model.IsMan,
                SecretName = model.SecretName
            }))
                UpdateEmployees();
        }

        public void Delete(int id)
        {
            if (_employeeRepository.Delete(id))
                UpdateEmployees();
        }

        public void Edit(EmployeeView model)
        {
            if (_employeeRepository.Edit(
                    new Employee
                    {
                        Position = model.Position,
                        Age = model.Age,
                        FirstName = model.FirstName,
                        SecondName = model.SecondName,
                        Patronymic = model.Patronymic,
                        IsMan = model.IsMan,
                        SecretName = model.SecretName
                    }))
                UpdateEmployees();
        }


        #region Supporting methods this class

        //Проверить работу при отсутствии элементов
        /// <summary>
        /// Updating Employees property
        /// </summary>
        private void UpdateEmployees()
            => Employees = _employeeRepository.Employees
            .Select(e => new EmployeeView
            {
                Id = e.Id,
                Position = e.Position,
                Age = e.Age,
                FirstName = e.FirstName,
                SecondName = e.SecondName,
                Patronymic = e.Patronymic,
                IsMan = e.IsMan,
                SecretName = e.SecretName
            }).ToList(); 

        #endregion
    }
}
