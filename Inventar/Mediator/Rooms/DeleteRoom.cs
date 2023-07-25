using Application.Query.Rooms;
using MediatR;
using Infrastructure;
using Inventar.Models;

namespace API.Mediator.Rooms
{
    public record DeleteRoomHandler(Guid Id) : IRequest<Room>;
    public class DeleteRoom : IRequestHandler<DeleteRoomHandler, Room>
    {
        private readonly IUnitOfWork _unitOfWork;


        public DeleteRoom(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Room> Handle(DeleteRoomHandler request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.Rooms.GetById(request.Id);
            if(result == null)
            {
                throw new Exception("Room not Found");
            }
             _unitOfWork.Rooms.Delete(result);
            _unitOfWork.Save();
            return result;
        }
    }
}
