using sistema_de_ponto.Data.DTOs;
using sistema_de_ponto.Models;

namespace sistema_de_ponto.Services;

public interface IEmployeeService
{
    Employee AddEmployee(Employee employee);
    
    Employee GetEmployeeWithID(int id);
    
    IEnumerable<Employee> GetAllEmployees();
    
    void UpdateEmployee(UpdateEmployeeDTO employeeDto,Employee employee);
    
    void DeleteEmployee(Employee employee);
}