using Application.Query.Rooms;
using MediatR;
using Infrastructure;
using Inventar.Models;
using Inventar.Persistance;
using Microsoft.EntityFrameworkCore;

namespace API.Mediator.Rooms
{
    public record DeleteRoomHandler(Guid Id) : IRequest<Room>;
    public class DeleteRoom : IRequestHandler<DeleteRoomHandler, Room>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DataContext _context;


        public DeleteRoom(IUnitOfWork unitOfWork, DataContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public async Task<Room> Handle(DeleteRoomHandler request, CancellationToken cancellationToken)
        {
            var result = await _context.Rooms
                .Include(r => r.Inventory)
                .Include(r => r.Worker)
                .FirstOrDefaultAsync(r => r.Id == request.Id);
            
            if(result == null)
            {
                throw new Exception("Room not Found");
            }

            result.Worker.Qualification = "Worker";
            _unitOfWork.Rooms.Delete(result);
            _unitOfWork.Save();
            return result;
        }
    }
}
