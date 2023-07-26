using Application.Query.Rooms;
using Infrastructure;
using MediatR;
using Inventar.Models;
using Inventar.Persistance;
using Microsoft.EntityFrameworkCore;

namespace API.Mediator.Rooms
{
    public record GetRoomByIdHandler(Guid Id):IRequest<Room>;
    public class GetRoomById : IRequestHandler<GetRoomByIdHandler, Room>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DataContext _context;

        public GetRoomById(IUnitOfWork unitOfWork, DataContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        public  async Task<Room> Handle(GetRoomByIdHandler request, CancellationToken cancellationToken)
        {
            var room = await _context.Rooms
                .Include(r => r.Inventory)
                .Include(r => r.Worker)
                .FirstOrDefaultAsync(r => r.Id == request.Id);
            if (room == null)
            {
                throw new Exception("Room not found");
            }
            return room;
            
        }
    }
}
