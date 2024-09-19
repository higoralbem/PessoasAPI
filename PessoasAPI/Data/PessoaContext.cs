using Microsoft.EntityFrameworkCore;
using PessoasAPI.Models;

namespace PessoasAPI.Data;

public class PessoaContext : DbContext
{
    public PessoaContext(DbContextOptions<PessoaContext> opts)
        :base(opts)
    {
            
    }

    public DbSet<Pessoa> Pessoas { get; set; }
}
