using Microsoft.EntityFrameworkCore;
using PSAch.API.Models;
using AutoMapper;
using PSAch.API.DTOs;

namespace PSAch.API.Data
{
    public class GamesRepository : IGamesRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public GamesRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Game> AddAsync(GameDto newEntity)
        {
            if(newEntity == null)
                throw new ArgumentNullException(nameof(newEntity));

            await _context.Games.AddAsync(_mapper.Map(newEntity, new Game()));

            await SaveChangesAsync();

            return await _context.Games.LastAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var game = _context.Games.FirstOrDefault(x => x.Id == id);

            if (game == null)
                throw new ArgumentNullException(nameof(game));

            _context.Games.Remove(game);

            if (!await SaveChangesAsync())
                throw new Exception("Something went wrong");
        }

        public async Task<IEnumerable<Game>> GetAllAsync(CancellationToken token = default) => await _context.Games.ToListAsync(cancellationToken: token);

        public async Task<Game> GetByIdAsync(int id)
        {
            if(id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id));

            return await _context.Games.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task UpdateAsync(GameDto updatedGame)
        {
            var game = _context.Games.FirstOrDefault(x => x.Id == updatedGame.Id);

            if(game == null)
                throw new NullReferenceException(nameof(game));

            if(game.Achievements?.Count(a => a.AchievemntType == AchievemntTypes.Platinum) > 1)
                throw new ArgumentOutOfRangeException(nameof(game));
            
            _mapper.Map(updatedGame, game);

            _context.Entry(game).State = EntityState.Modified;

            if (!await SaveChangesAsync())
                throw new Exception("Something went wrong");
        }
    }
}
