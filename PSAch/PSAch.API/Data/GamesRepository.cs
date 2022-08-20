using Microsoft.EntityFrameworkCore;
using PSAch.API.Models;

namespace PSAch.API.Data
{
    public class GamesRepository : IBaseRepository<Game>
    {
        private readonly DataContext _context;

        public GamesRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Game>> GetAllAsync() => await _context.Games.ToListAsync();

        public async Task<Game> GetByIdAsync(int id)
        {
            if(id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            return await _context.Games.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public Task<Game> UpdateAsync(Game entity)
        {
            throw new NotImplementedException();
        }
    }
}
