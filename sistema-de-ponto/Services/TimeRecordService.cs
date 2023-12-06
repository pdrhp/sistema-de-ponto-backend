using AutoMapper;
using Microsoft.EntityFrameworkCore;
using sistema_de_ponto.Data;
using sistema_de_ponto.Models;

namespace sistema_de_ponto.Services;

public class TimeRecordService : ITimeRecordService
{
    private SistemaDePontoContext _context;
    private IMapper _mapper;
    private IEmployeeService _employeeService;

    public TimeRecordService(SistemaDePontoContext context, IMapper mapper, IEmployeeService employeeService)
    {
        _context = context;
        _mapper = mapper;
        _employeeService = employeeService;
    }
    
    
    public void AddTimeRecord(TimeRecord timeRecord)
    {
        var existingRecord = _context.TimeRecord.FirstOrDefault(tr => tr.EmployeeId == timeRecord.EmployeeId && tr.LeaveTime == null);

        if (existingRecord != null)
        {
            throw new Exception("An entry record already exists for this employee without a leave time.");
        }
        
        _context.TimeRecord.Add(timeRecord);
        _context.SaveChanges();
    }

    public TimeRecord? GetLatestTimeRecordForEmployee(int employeeId)
    {
        return _context.TimeRecord
            .Where(tr => tr.Employee.Id == employeeId)
            .OrderByDescending(tr => tr.EntryTime)
            .FirstOrDefault();
    }

    public void UpdateTimeRecord(TimeRecord timeRecord)
    {
        var existingRecord = _context.TimeRecord
            .FirstOrDefault(tr => tr.RecordId == timeRecord.RecordId);
        
        if (existingRecord != null && existingRecord.LeaveTime != null)
        {
            throw new Exception("The leave time for this record has already been set.");
        }
        
        
        _context.TimeRecord.Update(timeRecord);
        _context.SaveChanges();
    }

    public IEnumerable<TimeRecord> GetAllTimeRecords()
    {
        return _context.TimeRecord
            .Include(tr => tr.Employee)
            .ToList();
    }
}