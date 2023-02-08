using MediatR;
using PSAch.API.Models;
using PSAch.API.Services.Cache;

namespace PSAch.API.Queries
{
    /// <summary>
    /// Query for get all <see cref="IEnumerable<Game>"/>
    /// </summary>
    public class GetGamesQuery : IRequest<IEnumerable<Game>>, ICacheableMediatrQuery
    {
        public int Id { get; set; }

        public bool BypassCache { get; set; }

        public string CacheKey => "GamesListQuery";

        public TimeSpan? SlidingExpiration { get; set; }
    }
}
