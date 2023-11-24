using System.ComponentModel.DataAnnotations;

namespace sistema_de_ponto.Models;

public class Employee
{
    [Key]
    [Required]
    public int Id { get; set; }
    [Required(ErrorMessage = "O campo nome é obrigatorio")]
    [StringLength(200, MinimumLength = 5, ErrorMessage = "O campo nome deve ter entre 5 e 200 caracteres")]
    public string Name { get; set; }
}