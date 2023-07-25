using Application.Query.Rooms;
using Infrastructure;
using MediatR;
using Inventar.Models;

namespace API.Mediator.Rooms
{
    public record GetRoomByIdHandler(Guid Id):IRequest<Room>;
    public class GetRoomById : IRequestHandler<GetRoomByIdHandler, Room>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetRoomById(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public  async Task<Room> Handle(GetRoomByIdHandler request, CancellationToken cancellationToken)
        {
            var room = await _unitOfWork.Rooms.GetById(request.Id);
            if (room == null)
            {
                throw new Exception("Room not found");
            }
            return room;
            
        }
    }
}
