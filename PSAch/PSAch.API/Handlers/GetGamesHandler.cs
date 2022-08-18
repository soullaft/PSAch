using MediatR;
using Microsoft.EntityFrameworkCore;
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
}
