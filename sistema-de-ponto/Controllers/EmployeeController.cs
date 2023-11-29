using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using sistema_de_ponto.Data;
using sistema_de_ponto.Data.DTOs;
using sistema_de_ponto.Models;
using sistema_de_ponto.Services;

namespace sistema_de_ponto.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;
    private IMapper _mapper;
    
    public EmployeeController(IEmployeeService employeeEmployeeService, IMapper mapper)
    {
        _employeeService = employeeEmployeeService;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddEmployee([FromBody]CreateEmployeeDTO employeeDto)
    {
        Employee employee = _mapper.Map<Employee>(employeeDto);

        _employeeService.AddEmployee(employee);
        return Ok(employee);
    }
    
    [HttpGet]
    public IEnumerable<Employee> GetAllEmployees()
    {
        return _employeeService.GetAllEmployees();
    }

    [HttpGet("{id}")]
    public IActionResult GetEmployeeWithID(int id)
    {
        Employee employee = _employeeService.GetEmployeeWithID(id);
        if (employee != null)
        {
            ReadEmployeeDTO employeeDto = _mapper.Map<ReadEmployeeDTO>(employee);
            return Ok(employeeDto);
        }

        return NotFound();
    }
    
    [HttpPut("{id}")]
    public IActionResult UpdateEmployee(int id, [FromBody] UpdateEmployeeDTO employeeDto)
    {
        Employee employee = _employeeService.GetEmployeeWithID(id);
        if (employee == null)
        {
            return NotFound();
        }

        _employeeService.UpdateEmployee(employeeDto, employee);
        return NoContent();
    }

    [HttpDelete]
    public IActionResult DeleteEmployee(int id)
    {
        Employee employee = _employeeService.GetEmployeeWithID(id);
        if (employee != null)
        {
            _employeeService.DeleteEmployee(employee);
        }

        return NotFound();
    }
    
    
}