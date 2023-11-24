using AutoMapper;
using sistema_de_ponto.Data.DTOs;
using sistema_de_ponto.Models;

namespace sistema_de_ponto.Profiles;


public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<CreateEmployeeDTO, Employee>();
        CreateMap<Employee, ReadEmployeeDTO>();
        CreateMap<UpdateEmployeeDTO, Employee>();
    }
}