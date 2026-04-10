using SeatInventoryService.Domain.Entities;

namespace SeatInventoryService.Domain.Repositories;

public interface IRepository<T> where T : Entity
{
    Task<T?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Save(T entity);
    void Remove(T entity);
}