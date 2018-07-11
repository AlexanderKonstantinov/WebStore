using AutoMapper;
using WebStore.Domain.Entities;
using WebStore.Models;

namespace WebStore.Helpers
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Employee, EmployeeViewModel>().ForMember(nameof(EmployeeViewModel.Gender),
                opt => opt.MapFrom(e => e.IsMan ? Gender.Man : Gender.Woman));

            CreateMap<EmployeeViewModel, Employee>().ForMember(nameof(Employee.IsMan),
                opt => opt.MapFrom(ev => Gender.Man == ev.Gender));
        }
    }
}
