using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestTaskHoH.Entitys;

namespace TestTaskHoH.EntityTypeConfiguration
{
    public class NoteEntityConfiguration : IEntityTypeConfiguration<NoteEntity>
    {
        public void Configure(EntityTypeBuilder<NoteEntity> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(p => p.Id).HasColumnName("Id");
            builder.Property(p => p.CreatedDateTime).HasColumnName("CreatedDateTime").IsRequired();
            builder.Property(p => p.UpdatedDateTime).HasColumnName("UpdatedDateTime");
            builder.Property(x => x.Title).HasMaxLength(50);
            builder.Property(x => x.Info).HasMaxLength(1024);
        }
    }
}
