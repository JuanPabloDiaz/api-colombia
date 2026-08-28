using api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class VolcanoConfig : IEntityTypeConfiguration<Volcano>
{
    public void Configure(EntityTypeBuilder<Volcano> volcano)
    {
        volcano.ToTable("Volcano");
        volcano.HasKey(p => p.Id);
        volcano.Property(p => p.Id).ValueGeneratedOnAdd();
        volcano.Property(p => p.Name).IsRequired().HasMaxLength(150);
        volcano.Property(p => p.Description).IsRequired(false).HasMaxLength(4000);
        volcano.Property(p => p.Elevation).IsRequired();
        volcano.Property(p => p.Latitude).IsRequired();
        volcano.Property(p => p.Longitude).IsRequired();
        volcano.Property(p => p.VolcanoType).IsRequired(false).HasMaxLength(150);
        volcano.Property(p => p.ActivityLevel).IsRequired(false).HasMaxLength(50);
        volcano.Property(p => p.ImageUrl).IsRequired(false).HasMaxLength(255);
        volcano.Property(p => p.DepartmentId).IsRequired();
        volcano.Property(p => p.CityId).IsRequired();

        // No inverse navigation collections on Department/City, mirroring HeritageCityConfig:
        // extra cycles in the entity graph blow the JSON-schema depth limit the MCP server
        // hits when it builds its tool schemas.
        volcano.HasOne(p => p.Department).WithMany().HasForeignKey(p => p.DepartmentId);
        volcano.HasOne(p => p.City).WithMany().HasForeignKey(p => p.CityId);
    }
}
