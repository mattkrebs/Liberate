using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Liberate.Models.Mapping
{
    public class MovieMap : EntityTypeConfiguration<Movie>
    {
        public MovieMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Year)
                .HasMaxLength(4);

            this.Property(t => t.Status)
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Movie");
            this.Property(t => t.Id).HasColumnName("MovieId");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.Year).HasColumnName("Year");
            this.Property(t => t.Height).HasColumnName("Height");
            this.Property(t => t.Width).HasColumnName("Width");
            this.Property(t => t.Status).HasColumnName("Status");
            this.Property(t => t.Owner).HasColumnName("Owner");
            this.Property(t => t.CreatedDate).HasColumnName("CreatedDate");
            this.Property(t => t.HD).HasColumnName("HD");
            this.Property(t => t.ImdbUrl).HasColumnName("ImdbUrl");
            this.Property(t => t.PosterUrl).HasColumnName("PosterUrl");

        }
    }
}
