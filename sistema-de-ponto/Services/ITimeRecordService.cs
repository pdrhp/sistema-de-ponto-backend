using sistema_de_ponto.Models;

namespace sistema_de_ponto.Services;

public interface ITimeRecordService
{
    void AddTimeRecord(TimeRecord timeRecord);
    TimeRecord? GetLatestTimeRecordForEmployee(int employeeId);
    void UpdateTimeRecord(TimeRecord timeRecord);
    IEnumerable<TimeRecord> GetAllTimeRecords();
}