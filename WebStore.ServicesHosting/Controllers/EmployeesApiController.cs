using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStore.Domain.Entities;
using WebStore.Interfaces.Services;

namespace WebStore.ServicesHosting.Controllers
{
    [Route("api/employees"),
    ApiController,
    Produces("application/json")]
    public class EmployeesApiController : ControllerBase, IEmployeesData
    {
        private readonly IEmployeesData _employeesData;

        public EmployeesApiController(IEmployeesData employeesData)
        {
            _employeesData = employeesData;
        }

        [HttpGet, ActionName("Get")]
        public IEnumerable<Employee> GetAll() => _employeesData.GetAll();


        [HttpGet("{id}"), ActionName("Get")]
        public Employee GetById(int id) => _employeesData.GetById(id);

        [HttpPost, ActionName("Post")]
        public void AddNew([FromBody]Employee employee) => _employeesData.AddNew(employee);

        [HttpDelete("{id}")]
        public void Delete(int id) => _employeesData.Delete(id);

        [HttpPut("{id}"), ActionName("Put")]
        public Employee Edit(int id, [FromBody]Employee newEmployee) => _employeesData.Edit(id, newEmployee);
    }
}