using AutoMapper;
using EmployeeProject.Entities.Dtos;
using EmployeeProject.Entities.Models;

namespace EmployeeProject.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EmployeeDtoForCreation, Employee>();
            CreateMap<EmployeeDtoForUpdate, Employee>();

        }
    }
}
