using MediatR;
using Microsoft.AspNetCore.Mvc;
using PSAch.API.Commands;
using PSAch.API.DTOs;
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

        [HttpGet("{gameId}", Name = "GetGame")]
        public async Task<ActionResult<Game>> GetGame(int gameId) => await _mediator.Send(new GetGameCommand(gameId)) ?? new Game();

        [HttpPost(Name = "AddGame")]
        public async Task<ActionResult<Game>> AddGame([FromBody] GameDto newGame) => await _mediator.Send(new AddGameCommand(newGame));

        [HttpDelete]
        public async Task<ActionResult> DeleteGame(int gameId)
        {
            await _mediator.Send(new DeleteGameCommand(gameId));
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateGame([FromBody] GameDto updatedGame)
        {
            await _mediator.Send(new UpdateGameCommand(updatedGame));

            return NoContent();
        }
    }
}
