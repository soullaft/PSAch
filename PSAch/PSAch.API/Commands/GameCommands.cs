using MediatR;
using PSAch.API.DTOs;
using PSAch.API.Models;

namespace PSAch.API.Commands
{
    public record GetGameCommand(int id) : IRequest<Game>;

    public record AddGameCommand(Game newGame) : IRequest<Game>;

    public record UpdateGameCommand(GameDto updatedGame) : IRequest<Unit>;

    public record DeleteGameCommand(int id) : IRequest<Unit>;
}
