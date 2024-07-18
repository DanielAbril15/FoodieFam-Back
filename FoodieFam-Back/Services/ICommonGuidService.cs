

namespace FoodieFam_Back.Services
{
    public interface ICommonGuidService<T,TI,TU>
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetById(Guid id);
        Task<T> Add(TI any);
        Task<T> Update(Guid id, TU any);
        Task<T> Delete(Guid id);
    }
}
