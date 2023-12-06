using Microsoft.AspNetCore.Mvc;
using sistema_de_ponto.Models;
using sistema_de_ponto.Services;

namespace sistema_de_ponto.Controllers;

[ApiController]
[Route("[controller]")]
public class TimeRecordController : ControllerBase
{

    private readonly IEmployeeService _employeeService;
    private readonly ITimeRecordService _timeRecordService;
    
    public TimeRecordController(IEmployeeService employeeService, ITimeRecordService timeRecordService)
    {
        _employeeService = employeeService;
        _timeRecordService = timeRecordService;
    }

    [HttpPost("RecordEntry/{employeeId}")]
    public ActionResult RecordEntry(int employeeId)
    {
        var employee = _employeeService.GetEmployeeWithID(employeeId);
        if (employee == null)
        {
            return NotFound("Employee not found");    
        }

        var timeRecord = new TimeRecord
        {
            EmployeeId = employee.Id,
            Employee = employee,
            EntryTime = DateTime.Now
        };
        
        _timeRecordService.AddTimeRecord(timeRecord);

        return Ok(timeRecord);
    }
    
    
}