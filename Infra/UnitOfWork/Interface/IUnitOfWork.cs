using Microsoft.EntityFrameworkCore;
using Models;

public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChangesAsync();
}