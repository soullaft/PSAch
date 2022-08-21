using MediatR;
using PSAch.API.Models;

namespace PSAch.API.Queries
{
    /// <summary>
    /// Query for get all <see cref="IEnumerable<Game>"/>
    /// </summary>
    public record GetGamesQuery() : IRequest<IEnumerable<Game>>;
}
