namespace FoodieFam_Back.Repository
{
    public interface IUserRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> Get();
        Task<TEntity> GetById(Guid id);
        Task<bool> UserExistsByEmailAsync(string email);
        Task Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task Save();

    }
}
