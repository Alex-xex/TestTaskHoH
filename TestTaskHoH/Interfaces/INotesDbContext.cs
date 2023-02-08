using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestTaskHoH.Entitys;

namespace TestTaskHoH.Interfaces
{
    public interface INotesDbContext
    {
        DbSet<NoteEntity> Notes { get; set; }     
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
