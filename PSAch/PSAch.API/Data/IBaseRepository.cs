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
        /// Save all changes
        /// </summary>
        /// <returns></returns>
        Task<bool> SaveChangesAsync();

        Task DeleteAsync(int id);
    }
}
