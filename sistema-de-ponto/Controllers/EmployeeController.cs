﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using sistema_de_ponto.Data;
using sistema_de_ponto.Data.DTOs;
using sistema_de_ponto.Models;

namespace sistema_de_ponto.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private SistemaDePontoContext _context;
    private IMapper _mapper;
    
    public EmployeeController(SistemaDePontoContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddEmployee([FromBody]CreateEmployeeDTO employeeDto)
    {
        Employee employee = _mapper.Map<Employee>(employeeDto);

        _context.Employee.Add(employee);
        _context.SaveChanges();
        return Ok(employee);
    }
    
    [HttpGet]
    public IEnumerable<Employee> GetAllEmployees()
    {
        return _context.Employee;
    }

    [HttpGet("{id}")]
    public IActionResult GetEmployeeWithID(int id)
    {
        Employee employee = _context.Employee.FirstOrDefault(employee => employee.Id == id);
        if (employee != null)
        {
            ReadEmployeeDTO employeeDto = _mapper.Map<ReadEmployeeDTO>(employee);
            return Ok(employeeDto);
        }

        return NotFound();
    }
    
    
}