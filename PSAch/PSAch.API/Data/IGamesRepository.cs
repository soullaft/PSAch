using PSAch.API.DTOs;
using PSAch.API.Models;

namespace PSAch.API.Data
{
    public interface IGamesRepository : IBaseRepository<Game>
    {
        /// <summary>
        /// Update <see cref="{T}"/> entity async
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(GameDto entity);

        Task<Game> AddAsync(GameDto gameDto);
    }
}
