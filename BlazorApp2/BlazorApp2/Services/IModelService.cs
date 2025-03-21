namespace BlazorApp2.Services
{
    public interface IModelService<T>
    {
        Task<List<T>> GetAll();
        Task<T> Get(Guid id);
        Task Add(T item);
        Task Update(T item);
        Task Delete(Guid id);
    }
}
