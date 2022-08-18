using MediatR;
using Microsoft.AspNetCore.Mvc;
using PSAch.API.Models;
using PSAch.API.Queries;

namespace PSAch.API.Controllers
{
    public class GamesController : BaseApiController
    {
        private readonly IMediator _mediator;

        public GamesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetAllGames() => Ok(await _mediator.Send(new GetGamesQuery()));

        //[HttpGet("{gameId}", Name = "GetGame")]
        //public async Task<ActionResult<Game>> GetGame(int gameId) => await _dataContext.Games.FirstOrDefaultAsync(g => g.Id == gameId);
    }
}
