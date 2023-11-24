using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sistema_de_ponto.Models;

public class TimeRecord
{
    [Key]
    [Required]
    public int RecordId { get; set; }
    
    [ForeignKey("Employee")]
    public int EmployeeId { get; set; }
    
    [Required]
    public Employee Employee { get; set; }
    [Required(ErrorMessage = "O campo data de entrada é obrigatorio")]
    public DateTime EntryTime { get; set; }
    [Required(ErrorMessage = "O campo data de saida é obrigatorio")]
    public DateTime LeaveTime { get; set; }
    
}