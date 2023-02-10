using PSAch.API.DTOs;
using PSAch.Core;

namespace PSAch.API.Data
{
    public interface IGamesRepository : IBaseRepository<Game>
    {
        Task UpdateAsync(GameDto entity);

        Task<GameDto> AddAsync(GameDto gameDto);

        Task<GameDto> GetByIdAsync(int gameId);
    }
}
