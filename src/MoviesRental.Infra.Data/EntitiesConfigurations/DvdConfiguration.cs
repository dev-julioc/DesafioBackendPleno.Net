using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoviesRental.Domain.Entities.Write;
using MoviesRental.Domain.Enums;

namespace MoviesRental.Infra.Data.EntitiesConfigurations;
public class DvdConfiguration : IEntityTypeConfiguration<Dvd>
{
    public void Configure(EntityTypeBuilder<Dvd> builder)
    {
        builder.ToTable("dvd");
        builder.HasKey(x => x.Id);

        builder.HasIndex(x => x.Title)
            .IsUnique();

        builder.Property(x => x.Title)
            .HasMaxLength(Dvd.MAX_TITLE_LENGTH)
            .IsRequired();

        builder.Property(x => x.Copies)
            .IsRequired();

        builder.Property(x => x.IsAvailable)
            .IsRequired();

        builder.Property(x => x.Publisher)
            .IsRequired();

        builder.Property(x => x.CreatedAt)
            .IsRequired();

        builder.Property(x => x.UpdatedAt)
            .IsRequired();

        builder.Property(x => x.Genre)
            .HasConversion(x => x.ToString(),
            x => (EGenre)Enum.Parse(typeof(EGenre), x));

        builder.Property(x => x.DirectorId)
            .IsRequired();

        builder.HasOne(x => x.Director).WithMany(x => x.Dvds).HasForeignKey(x => x.DirectorId).OnDelete(DeleteBehavior.Restrict);


    }
}
