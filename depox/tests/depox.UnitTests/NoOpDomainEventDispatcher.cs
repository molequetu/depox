using System.Threading.Tasks;
using depox.SharedKernel.Interfaces;
using depox.SharedKernel;

namespace depox.UnitTests
{
    public class NoOpDomainEventDispatcher : IDomainEventDispatcher
    {
        public Task Dispatch(BaseDomainEvent domainEvent)
        {
            return Task.CompletedTask;
        }
    }
}
