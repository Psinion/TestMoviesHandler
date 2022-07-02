using TestMoviesHandler.Data.Models.Base;

namespace TestMoviesHandler.Data.Repositories.Base
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        TEntity? GetById(int id);

        Task<TEntity?> GetByIdAsync(int id);

        IEnumerable<TEntity> GetAll();

        Task<List<TEntity>> GetAllAsync();

        TEntity Add(TEntity item);

        Task<TEntity> AddAsync(TEntity item);

        void Update(TEntity item);

        Task UpdateAsync(TEntity item);

        void Remove(int id);

        Task RemoveAsync(int id);
    }
}
