namespace PSAch.API.Data
{
    public interface IBaseRepository <T> where T : class, new()
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task<T> UpdateAsync(T entity);

        Task<int> SaveChangesAsync();
    }
}
