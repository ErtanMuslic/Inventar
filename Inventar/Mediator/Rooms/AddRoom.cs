using Application.Query.Rooms;
using Infrastructure;
using MediatR;
using Inventar.Models;
using AutoMapper;
using API.DTOs;

namespace API.Mediator.Rooms
{
    public record AddRoomHandler(RoomDto roomDto): IRequest<RoomDto>;
    public class AddRoom : IRequestHandler<AddRoomHandler, RoomDto>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AddRoom(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<RoomDto> Handle(AddRoomHandler request, CancellationToken cancellationToken)
        {
            var newRoom = _mapper.Map<Room>(request.roomDto);
            await _unitOfWork.Rooms.Add(newRoom);
            _unitOfWork.Save();
            var result = _mapper.Map<RoomDto>(newRoom);
            return result;
        }
    }
    
}
