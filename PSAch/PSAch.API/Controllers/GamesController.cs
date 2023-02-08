using MediatR;
using Microsoft.AspNetCore.Mvc;
using PSAch.API.Commands;
using PSAch.API.DTOs;
using PSAch.API.Models;
using PSAch.API.Queries;

namespace PSAch.API.Controllers
{
    public sealed class GamesController : BaseApiController
    {
        private readonly IMediator _mediator;

        public GamesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetAllGames() => Ok(await _mediator.Send(new GetGamesQuery()));

        [HttpGet("{gameId}", Name = "GetGame")]
        public async Task<ActionResult<GameDto>> GetGame(int gameId) => Ok(await _mediator.Send(new GetGameCommand(gameId)));

        [HttpPost(Name = "AddGame")]
        public async Task<ActionResult<GameDto>> AddGame([FromBody] GameDto newGame) => Ok(await _mediator.Send(new AddGameCommand(newGame)));

        [HttpDelete]
        public async Task<ActionResult> DeleteGame(int gameId)
        {
            await _mediator.Send(new DeleteGameCommand(gameId));
            
            Response.StatusCode = 200;

            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> UpdateGame([FromBody] GameDto updatedGame) => Ok(await _mediator.Send(new UpdateGameCommand(updatedGame)));
    }
}
