using MediatR;
using PSAch.API.Models;

namespace PSAch.API.Commands
{
    public record GetGameCommand(int id) : IRequest<Game>;
}
