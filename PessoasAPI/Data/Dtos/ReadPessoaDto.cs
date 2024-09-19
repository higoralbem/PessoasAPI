using System.ComponentModel.DataAnnotations;

namespace PessoasAPI.Data.Dtos;

public class ReadPessoaDto
{
    public string Nome { get; set; }
        
    public string CPF { get; set; }

    public string Nascimento { get; set; }
        
    public string Status { get; set; }

    public DateTime HoraConsulta { get; set; } = DateTime.Now;  
}
