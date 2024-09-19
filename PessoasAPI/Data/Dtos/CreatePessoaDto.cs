using System.ComponentModel.DataAnnotations;

namespace PessoasAPI.Data.Dtos;

public class CreatePessoaDto
{
    [Required(ErrorMessage = "O Nome é Obrogatório")]
    [StringLength(100, ErrorMessage = "O nome não pode ultrapassar 100 caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O CPF é Obrogatório")]
    [StringLength(11, ErrorMessage = "O CPF não pode ultrapassar 11 caracteres")]
    public string CPF { get; set; }

    [Required(ErrorMessage = "A Data de Nascimento é Obrogatória")]
    public string Nascimento { get; set; }

    [Required(ErrorMessage = "O Status Ativo ou Inativo é Obrogatório")]
    public string Status { get; set; }
}
