namespace PSAch.API.Data
{
    /// <summary>
    /// Represents base contract for all repositories.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBaseRepository <T> where T : class, new()
    {
        /// <summary>
        /// Get all records of type <see cref="{T}"/> async
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<T>> GetAllAsync(CancellationToken token);

        /// <summary>
        /// Get single record of type <see cref="{T}"/> async
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<T> GetByIdAsync(int id);

        Task<T> AddAsync(T newEntity);

        /// <summary>
        /// Save all changes
        /// </summary>
        /// <returns></returns>
        Task<bool> SaveChangesAsync();
    }
}
