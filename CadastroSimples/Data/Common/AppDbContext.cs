using CadastroSimples.Data.EfConfig;
using CadastroSimples.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CadastroSimples.Data.Common;

public class AppDbContext : DbContext
{

    DbSet<Client> Clients { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    { 
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new ClientMap());
    }

}
