using PSAch.API.DTOs;
using PSAch.API.Models;

namespace PSAch.API.Data
{
    public interface IGamesRepository : IBaseRepository<Game>
    {
        Task UpdateAsync(GameDto entity);

        Task<GameDto> AddAsync(GameDto gameDto);

        Task<GameDto> GetByIdAsync(int gameId);
    }
}
