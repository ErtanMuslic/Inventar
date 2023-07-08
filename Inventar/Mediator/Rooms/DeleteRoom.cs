using Application.Query.Rooms;
using MediatR;
using Infrastructure;
using Inventar.Models;

namespace API.Mediator.Rooms
{
    public class DeleteRoom : IRequestHandler<DeleteRoomQuery, Room>
    {
        private readonly IUnitOfWork _unitOfWork;


        public DeleteRoom(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Room> Handle(DeleteRoomQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Rooms.GetById(request.Id);
            if(result == null)
            {

            }
             _unitOfWork.Rooms.Delete(result);
            _unitOfWork.Save();
            return result;
        }
    }
}
