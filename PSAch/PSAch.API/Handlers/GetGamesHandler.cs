using MediatR;
using Microsoft.EntityFrameworkCore;
using PSAch.API.Commands;
using PSAch.API.Data;
using PSAch.API.Models;
using PSAch.API.Queries;

namespace PSAch.API.Handlers
{
    public class GetGamesHandler : IRequestHandler<GetGamesQuery, IEnumerable<Game>>
    {
        private readonly IBaseRepository<Game> _gamesRepository;

        public GetGamesHandler(IBaseRepository<Game> gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }

        public async Task<IEnumerable<Game>> Handle(GetGamesQuery request, CancellationToken cancellationToken)
        {
            return await _gamesRepository.GetAllAsync();
        }
    }

    public class GetGameHandler : IRequestHandler<GetGameCommand, Game>
    {
        private readonly IBaseRepository<Game> _gamesRepository;

        public GetGameHandler(IBaseRepository<Game> gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }

        public async Task<Game> Handle(GetGameCommand request, CancellationToken cancellationToken)
        {
            return await _gamesRepository.GetByIdAsync(request.id);
        }
    }
}
