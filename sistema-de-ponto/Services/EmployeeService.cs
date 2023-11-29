using AutoMapper;
using sistema_de_ponto.Data;
using sistema_de_ponto.Data.DTOs;
using sistema_de_ponto.Models;

namespace sistema_de_ponto.Services;

public class EmployeeService : IEmployeeService
{

    private SistemaDePontoContext _context;
    private IMapper _mapper;
    
    public EmployeeService(SistemaDePontoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public Employee AddEmployee(Employee employee)
    {
        _context.Employee.Add(employee);
        _context.SaveChanges();
        return employee;
    }

    public Employee? GetEmployeeWithID(int id)
    {
        Employee employee = _context.Employee.FirstOrDefault(employee => employee.Id == id);
        if (employee != null)
        {
            return employee;
        }

        return null;
    }

    public IEnumerable<Employee> GetAllEmployees()
    {
        return _context.Employee;
    }

    public void UpdateEmployee(UpdateEmployeeDTO employeeDto, Employee employee)
    {
        _mapper.Map(employeeDto, employee);
        _context.SaveChanges();
    }

    public void DeleteEmployee(Employee employee)
    {
        _context.Employee.Remove(employee);
        _context.SaveChanges();
    }
}