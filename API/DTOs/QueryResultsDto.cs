namespace API.DTOs
{
    public class QueryResultsDto<T> where T : class
    {
        public int TotalItems { get; set; }
        public IEnumerable<T> Items { get; set; }

    }
}
