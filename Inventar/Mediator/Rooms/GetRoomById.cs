using Application.Query.Rooms;
using Infrastructure;
using MediatR;
using Inventar.Models;

namespace API.Mediator.Rooms
{
    public class GetRoomById : IRequestHandler<GetRoomByIdQuery, Room>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetRoomById(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public  async Task<Room> Handle(GetRoomByIdQuery request, CancellationToken cancellationToken)
        {
            var room = await _unitOfWork.Rooms.GetById(request.Id);
            return room;
        }
    }
}
