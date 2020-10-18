using System.Threading.Tasks;
using depox.Core.Entities;

namespace depox.Core.Interfaces
{
    public interface IBinService
    {
        Task<Bin> FindItemLocation(int itemId);
    }
}