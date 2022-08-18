using MediatR;
using PSAch.API.Models;

namespace PSAch.API.Queries
{
    public record GetGamesQuery() : IRequest<IEnumerable<Game>>;
}
