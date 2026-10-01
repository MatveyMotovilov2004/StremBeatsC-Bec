using Catalog.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.Persistence;

public class TrackConfiguration : IEntityTypeConfiguration<Track>
{
    public void Configure(EntityTypeBuilder<Track> builder)
    {
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Title)
            .IsRequired()
            .HasMaxLength(50);
        builder.HasOne(a => a.Album)
            .WithMany(b => b.Track)
            .HasForeignKey(c => c.AlbumId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
        builder.Property(a => a.Duration)
            .IsRequired();
        builder.Property(a => a.FileId)
            .IsRequired();
        builder.ToTable("track", t =>
        {
            t.HasCheckConstraint
                ("CK_Track_Duration_Min", "\"Duration\" >= 0");
            t.HasCheckConstraint
                ("CK_Track_PlayCount_Min", "\"play_count\" >= 0");
        });
    }
}
