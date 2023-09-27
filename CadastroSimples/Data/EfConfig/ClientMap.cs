using CadastroSimples.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CadastroSimples.Data.EfConfig;

public class ClientMap : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(m => m.Endereco)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(m => m.Email)
            .IsRequired()
            .HasMaxLength(250);

        builder.Property(m => m.Sex)
            .IsRequired()
            .HasMaxLength(2);

        builder.Property(m => m.Age)
            .IsRequired()
            .HasMaxLength(3);
    }


}
