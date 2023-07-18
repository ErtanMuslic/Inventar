using MediatR;
using Inventar.Models;


namespace Application.Query.Inventories
{
    public class AddInventoryQuery : IRequest<Inventory>
    {
        public Inventory Inventory { get;  }

        public AddInventoryQuery(Inventory inventory) 
        { 
            Inventory = inventory;
        }
    }
}
