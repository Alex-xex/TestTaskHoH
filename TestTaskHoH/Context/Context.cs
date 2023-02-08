using Microsoft.EntityFrameworkCore;
using TestTaskHoH.Entitys;
using TestTaskHoH.EntityTypeConfiguration;
using TestTaskHoH.Interfaces;

namespace TestTaskHoH.Context
{
    public class Context : DbContext, INotesDbContext
    {      
        public DbSet<NoteEntity> Notes { get; set; }

        public Context(DbContextOptions<Context> options)
        : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new NoteEntityConfiguration());
            base.OnModelCreating(builder);
        }
    }
}
