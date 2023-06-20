namespace Inventar.Models
{
    public class InventarDatabaseSettings : IInventarDatabaseSettings
    {
        public string ConnectionString { get; set; } = String.Empty;
        public string DatabaseName { get; set; } = String.Empty;
        public string InventarCollectionName { get; set; } = String.Empty;
    }
}
