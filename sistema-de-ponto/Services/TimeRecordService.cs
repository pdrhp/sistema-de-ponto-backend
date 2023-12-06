using AutoMapper;
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
        _context.TimeRecord.Add(timeRecord);
        _context.SaveChanges();
    }

    public TimeRecord GetLatestTimeRecordForEmployee(int employeeId)
    {
        throw new NotImplementedException();
    }

    public void UpdateTimeRecord(TimeRecord timeRecord)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TimeRecord> GetAllTimeRecords()
    {
        throw new NotImplementedException();
    }
}