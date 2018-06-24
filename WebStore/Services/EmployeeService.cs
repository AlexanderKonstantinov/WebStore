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
    /// Layer that generates employee data for display to the user
    /// </summary>
    public class EmployeeService : IEmployeeService
    {
        // Нужно ли делать экземпляр сервиса readonly? 
        // Пока не разобрался как это сделать с внедрением зависимостей.
        // Если правильно понимаю, то при правильной реализации за количеством
        // экземпляров будет следить встроенный механизм внедрения зависимостей?
        private IEmployeeRepository _employeeRepository;

        public EmployeeService()
        {
            _employeeRepository = new EmployeeRepository();
        }
        
        // Лучше ведь будет такие коллекции для представления на лету формировать или эффективнее будет 
        // в отдельном поле данные хранить? 
        // Просто у меня для примера добавлено поле WorkDuration, которое по смыслу часто изменяется.
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
        // Здесь не знаю как лучше будет сделать. 
        // Возвращать bool об успешности получения работника?
    }
}
