using System.ComponentModel.DataAnnotations;

namespace sistema_de_ponto.Data.DTOs;

public class UpdateEmployeeDTO
{
    [Required(ErrorMessage = "O campo nome é obrigatorio")]
    [StringLength(200, MinimumLength = 5, ErrorMessage = "O campo nome deve ter entre 5 e 200 caracteres")]
    public string Name { get; set; }

    [Required(ErrorMessage = "O campo email é obrigatorio")]
    [EmailAddress]
    public string Email { get; set; }
}