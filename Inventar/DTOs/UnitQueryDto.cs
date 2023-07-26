using Application.Models;

namespace API.DTOs
{
    public class UnitQueryDto : IQueryObj
    {
        public string? Name { get; set; }
        public string? SortBy { get; set; }
        public bool? IsSortAscending { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }
        public string? Model { get; set; }
        public string? Mark { get; set; }
        public int? Price { get; set; }
        public int? Floor { get; set; }
        public DateTime? DateCreated { get; set; }

    }
}
