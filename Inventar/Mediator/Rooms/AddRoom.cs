using Application.Query.Rooms;
using Infrastructure;
using User.Models;
using MediatR;

namespace API.Mediator.Rooms
{
    public class AddRoom : IRequestHandler<AddRoomQuery, Room>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddRoom(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Room> Handle(AddRoomQuery request, CancellationToken cancellationToken)
        {
             var result = await _unitOfWork.Rooms.Add(request.Room);
            _unitOfWork.Save();
            return result;

        }
    }
    
}
