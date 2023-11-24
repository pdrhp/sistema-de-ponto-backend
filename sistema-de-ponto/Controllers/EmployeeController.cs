using Microsoft.AspNetCore.Mvc;
using sistema_de_ponto.Data;
using sistema_de_ponto.Data.DTOs;

namespace sistema_de_ponto.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private SistemaDePontoContext _context;
    
    public EmployeeController(SistemaDePontoContext context)
    {
        _context = context;
    }

    public IActionResult AddEmployee(CreateEmployeeDTO employeeDto)
    {
        
    }
    
    
}