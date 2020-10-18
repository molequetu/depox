using System.Threading.Tasks;

namespace depox.Core.Interfaces
{
    public interface IStockService
    {
        Task ImportStock(int binId, int itemId, decimal quantity);

        Task ExportStock(int binId, int itemId, decimal quantity);

        Task TransferStock(int fromBin, int toBin, int itemId, decimal quantity);
    }
}