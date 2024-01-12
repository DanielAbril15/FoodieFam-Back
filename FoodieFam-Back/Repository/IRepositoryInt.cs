using FoodieFam_Back.Models;

namespace FoodieFam_Back.Repository
{
    public interface IRepositoryInt<TEntity>
    {
        Task<IEnumerable<TEntity>> Get();
        Task<TEntity> GetById(int id);
        Task Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task Save();
        Task Add(IngredientType ingredientType);
    }
}
