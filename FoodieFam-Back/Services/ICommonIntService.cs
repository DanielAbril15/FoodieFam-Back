namespace FoodieFam_Back.Services
{
    public interface ICommonIntService<T, TI, TU>
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetById(int id);
        Task<T> Add(TI ingredientTypeInsertDto);
        Task<T> Update(int id, TU ingredientTypePutDto);
        Task<T> Delete(int id);
    }
}
