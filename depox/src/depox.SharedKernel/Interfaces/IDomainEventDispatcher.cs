using System.Threading.Tasks;
using depox.SharedKernel;

namespace depox.SharedKernel.Interfaces
{
    public interface IDomainEventDispatcher
    {
        Task Dispatch(BaseDomainEvent domainEvent);
    }
}