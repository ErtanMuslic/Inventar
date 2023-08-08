using API.DTOs;
using AutoMapper;
using Infrastructure;
using Inventar.Models;
using MediatR;

namespace API.Mediator.Rooms
{
    public record UpdateRoomHandler(Guid Id, UpdateRoomBoss boss) : IRequest<Room>;
    public class UpdateRoom : IRequestHandler<UpdateRoomHandler, Room>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateRoom(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Room> Handle(UpdateRoomHandler request, CancellationToken cancellationToken)
        {
            var room = await _unitOfWork.Rooms.GetById(request.Id);
            var worker = await _unitOfWork.Workers.GetById(request.boss.WorkerId);

            if (room == null)
            {
                throw new Exception("Room not found");
            }

            room.workerId = request.boss.WorkerId;
            room.Boss = $"{worker.Name} {worker.Surname}";
            worker.Qualification = "Boss";
           
            _unitOfWork.Save();
            return room;
        }

    }
}
