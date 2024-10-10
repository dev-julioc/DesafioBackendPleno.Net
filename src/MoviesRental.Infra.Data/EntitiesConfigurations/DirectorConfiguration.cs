using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesRental.Domain.Entities.Write;

namespace MoviesRental.Infra.Data.EntitiesConfigurations;
public class DirectorConfiguration : IEntityTypeConfiguration<Director>
{
    public void Configure(EntityTypeBuilder<Director> builder)
    {
        builder.ToTable("director");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(Director.MAX_LENGTH)
            .IsRequired();

        builder.Property(x => x.Surname)
            .HasMaxLength(Director.MAX_LENGTH)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .IsRequired();

        builder.HasMany(x => x.Dvds).WithOne(x => x.Director);
    }
}
