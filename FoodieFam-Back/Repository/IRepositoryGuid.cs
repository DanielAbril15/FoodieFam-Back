namespace FoodieFam_Back.Repository
{
    public interface IRepositoryGuid<TEntity>
    {
        Task<IEnumerable<TEntity>> Get();
        Task<TEntity> GetById(Guid id);
        Task Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task Save();

    }
}
