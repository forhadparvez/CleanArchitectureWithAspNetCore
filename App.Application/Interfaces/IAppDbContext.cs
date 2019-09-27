using App.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace App.Application.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Student> Students { get; set; }
        DbSet<Department> Departments { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
