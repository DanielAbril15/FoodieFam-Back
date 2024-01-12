

namespace FoodieFam_Back.Services
{
    public interface ICommonGuidService<T,TI,TU>
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetById(Guid id);
        Task<T> Add(TI userInsertDto);
        Task<T> Update(Guid id, TU userPutDto);
        Task<T> Delete(Guid id);
    }
}
