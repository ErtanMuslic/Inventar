namespace Inventar.Models
{
    public interface IInventarDatabaseSettings
    {
         string ConnectionString { get; set; } 
         string DatabaseName { get; set; }
         string InventarCollectionName { get; set; }
    }
}
