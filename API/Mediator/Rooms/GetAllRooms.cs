using Application.Query.Rooms;
using Infrastructure;
using MediatR;
using Inventar.Models;
using API.DTOs;
using AutoMapper;

namespace API.Mediator.Rooms
{
    public record GetAllRoomsHandler() : IRequest<IEnumerable<RoomDto>>;
    public class GetAllRooms : IRequestHandler<GetAllRoomsHandler, IEnumerable<RoomDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllRooms(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<IEnumerable<RoomDto>> Handle(GetAllRoomsHandler request, CancellationToken cancellationToken)
        {
            var rooms = await _unitOfWork.Rooms.GetAll();
            return rooms.Select(room => _mapper.Map<RoomDto>(room));
        }
    }
}
