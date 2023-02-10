using AutoMapper;
using MediatR;
using PSAch.API.Commands;
using PSAch.API.Data;
using PSAch.API.DTOs;
using PSAch.API.Queries;
using PSAch.Core;

namespace PSAch.API.Handlers
{
    public class GetGamesHandler : IRequestHandler<GetGamesQuery, IEnumerable<Game>>
    {
        private readonly IBaseRepository<Game> _gamesRepository;

        public GetGamesHandler(IGamesRepository gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }

        public async Task<IEnumerable<Game>> Handle(GetGamesQuery request, CancellationToken cancellationToken)
        {
            return await _gamesRepository.GetAllAsync(cancellationToken);
        }
    }

    public class GetGameHandler : IRequestHandler<GetGameCommand, GameDto>
    {
        private readonly IGamesRepository _gamesRepository;

        public GetGameHandler(IGamesRepository gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }

        public async Task<GameDto> Handle(GetGameCommand request, CancellationToken cancellationToken)
        {
            return await _gamesRepository.GetByIdAsync(request.Id);
        }
    }

    public class AddGameHandler : IRequestHandler<AddGameCommand, GameDto>
    {
        private readonly IGamesRepository _gamesRepository;

        public AddGameHandler(IGamesRepository gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }

        public async Task<GameDto> Handle(AddGameCommand request, CancellationToken cancellationToken)
        {
            return await _gamesRepository.AddAsync(request.newGame);
        }
    }

    public class UpdateGameHandler : IRequestHandler<UpdateGameCommand, Unit>
    {
        private readonly IGamesRepository _gamesRepository;
        private readonly IMapper _mapper;

        public UpdateGameHandler(IGamesRepository gamesRepository, IMapper mapper)
        {
            _gamesRepository = gamesRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
        {
            await _gamesRepository.UpdateAsync(request.updatedGame);

            return Unit.Value;
        }
    }

    public class DeleteGameHandler : IRequestHandler<DeleteGameCommand, Unit>
    {
        private readonly IGamesRepository _gamesRepository;

        public DeleteGameHandler(IGamesRepository gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }

        public async Task<Unit> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
        {
            await _gamesRepository.DeleteAsync(request.id);
            return Unit.Value;
        }
    }
}
