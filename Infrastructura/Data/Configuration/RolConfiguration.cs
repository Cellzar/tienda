using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Configuration;

public class RolConfiguration: IEntityTypeConfiguration<Rol>
{
    public void Configure(EntityTypeBuilder<Rol> builder)
    {
        builder.ToTable("Rol");
        builder.Property(p => p.Id)
               .IsRequired();

        builder.Property(p => p.Nombre)
               .IsRequired()
               .HasMaxLength(200);
    }
}
