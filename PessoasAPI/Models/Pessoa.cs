using System.ComponentModel.DataAnnotations;

namespace PessoasAPI.Models;

public class Pessoa
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "O Nome é Obrogatório")]
    [MaxLength(100, ErrorMessage = "O nome não pode ultrapassar 100 caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O CPF é Obrogatório")]
    [MaxLength(11, ErrorMessage = "O CPF não pode ultrapassar 11 caracteres")]
    public string CPF { get; set; }

    [Required(ErrorMessage = "A Data de Nascimento é Obrogatória")]
    public string Nascimento { get; set; }

    [Required(ErrorMessage = "O Status Ativo ou Inativo é Obrogatório")]
    public string Status { get; set; }
    
    
}
