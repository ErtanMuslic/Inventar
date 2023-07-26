using Application.Query.Rooms;
using Infrastructure;
using MediatR;
using Inventar.Models;
using API.DTOs;
using AutoMapper;
using Inventar.Persistance;
using Microsoft.EntityFrameworkCore;

namespace API.Mediator.Rooms
{
    public record GetAllRoomsHandler() : IRequest<IEnumerable<RoomDto>>;
    public class GetAllRooms : IRequestHandler<GetAllRoomsHandler, IEnumerable<RoomDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public GetAllRooms(IUnitOfWork unitOfWork,IMapper mapper, DataContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }


        public async Task<IEnumerable<RoomDto>> Handle(GetAllRoomsHandler request, CancellationToken cancellationToken)
        {
            var rooms = await _context.Rooms
                .Include(c => c.Inventory)
                .Include(c => c.Worker)
                .ToListAsync();
            return rooms.Select(room => _mapper.Map<RoomDto>(room));
        }
    }
}
