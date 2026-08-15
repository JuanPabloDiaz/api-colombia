using api.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace api.Data.Configs
{
    public class TelevisionChannelConfig : IEntityTypeConfiguration<TelevisionChannel>
    {
        public void Configure(EntityTypeBuilder<TelevisionChannel> channel)
        {
            channel.ToTable("TelevisionChannel");
            channel.HasKey(p => p.Id);
            channel.Property(p => p.Id).ValueGeneratedOnAdd();
            channel.Property(p => p.Name).IsRequired().HasMaxLength(150);
            channel.Property(p => p.CityId).IsRequired();
            channel.Property(p => p.Url).IsRequired(false);
            channel.Property(p => p.IsActive).IsRequired();
            channel.HasOne(p => p.City).WithMany(p => p.TelevisionChannels).HasForeignKey(p => p.CityId);
        }
    }
}
