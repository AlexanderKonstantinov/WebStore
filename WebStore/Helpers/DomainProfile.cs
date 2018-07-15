using System;
using AutoMapper;
using WebStore.Domain.Entities;
using WebStore.Models;
using WebStore.Models.Product;

namespace WebStore.Helpers
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Employee, EmployeeViewModel>()
                .ForMember(nameof(EmployeeViewModel.Gender),
                    opt => opt.MapFrom(e => e.IsMan 
                        ? Gender.Man : Gender.Woman));

            CreateMap<EmployeeViewModel, Employee>()
                .ForMember(nameof(Employee.IsMan),
                    opt => opt.MapFrom(ev => Gender.Man == ev.Gender));

            CreateMap<Product, ProductViewModel>()
                .ForMember(nameof(ProductViewModel.Brand),
                    opt => opt.MapFrom(p => p.Brand != null 
                        ? p.Brand.Name : String.Empty));
        }
    }
}
