using System.ComponentModel.DataAnnotations;

namespace sistema_de_ponto.Data.DTOs;

public class CreateEmployeeDTO
{
    
    [Required(ErrorMessage = "O campo nome é obrigatorio")]
    [StringLength(200, MinimumLength = 5, ErrorMessage = "O campo nome deve ter entre 5 e 200 caracteres")]
    public string Name { get; set; }
}