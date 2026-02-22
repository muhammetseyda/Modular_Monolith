using Shared.Contracts;

namespace InventoryModule.Services;

internal class InventoryService : IInventoryService
{
    public bool CheckStock(Guid productId, int quantity)
    {
        return true;
    }
}
