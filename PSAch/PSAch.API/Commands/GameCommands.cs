using MediatR;
using PSAch.API.DTOs;
using PSAch.API.Services.Cache;

namespace PSAch.API.Commands
{
    public class GetGameCommand : IRequest<GameDto>, ICacheableMediatrQuery
    {
        public int Id { get; set; }

        public bool BypassCache { get; set; }

        public string CacheKey => $"Game {Id}";

        public TimeSpan? SlidingExpiration { get; set; }
    }

    public record AddGameCommand(GameDto newGame) : IRequest<GameDto>;

    public record UpdateGameCommand(GameDto updatedGame) : IRequest<Unit>;

    public record DeleteGameCommand(int id) : IRequest<Unit>;
}
