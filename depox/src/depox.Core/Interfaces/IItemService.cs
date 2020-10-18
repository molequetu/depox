using System.Collections.Generic;
using System.Threading.Tasks;
using depox.Core.Entities;

namespace depox.Core.Interfaces
{
    public interface IItemService
    {
        Task<List<Item>> GetBinItems(int binId);
    }
}