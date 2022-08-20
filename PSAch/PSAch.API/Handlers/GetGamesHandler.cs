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
        private readonly DataContext _dataContext;

        public GetGamesHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<IEnumerable<Game>> Handle(GetGamesQuery request, CancellationToken cancellationToken)
        {
            return await _dataContext.Games.Include(g => g.Achievements).ToListAsync(cancellationToken: cancellationToken);
        }
    }

    public class GetGameHandler : IRequestHandler<GetGameCommand, Game>
    {
        private readonly DataContext _dataContext;

        public GetGameHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Game> Handle(GetGameCommand request, CancellationToken cancellationToken)
        {
            return await _dataContext.Games.FirstOrDefaultAsync(g => request.id == g.Id,
                                                                cancellationToken: cancellationToken);
        }
    }
}
