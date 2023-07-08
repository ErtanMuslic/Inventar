using Application.Query.Rooms;
using Infrastructure;
using MediatR;
using Inventar.Models;

namespace API.Mediator.Rooms
{
    public class GetAllRooms : IRequestHandler<GetAllRoomsQuery, List<Room>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllRooms(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task<List<Room>> Handle(GetAllRoomsQuery request, CancellationToken cancellationToken)
        {
            var rooms = await _unitOfWork.Rooms.GetAll();
            return rooms;
        }
    }
}
