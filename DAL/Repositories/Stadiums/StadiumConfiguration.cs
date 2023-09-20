using Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Repositories.Stadiums;
public class StadiumConfiguration : IEntityTypeConfiguration<Stadium>
{
    public void Configure(EntityTypeBuilder<Stadium> builder)
    {
        builder.ToTable("Stadiums");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn(1,1);
    }
}
