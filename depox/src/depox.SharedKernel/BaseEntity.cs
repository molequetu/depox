using System.Collections.Generic;
using Newtonsoft.Json;

namespace depox.SharedKernel
{
    // This can be modified to BaseEntity<TId> to support multiple key types (e.g. Guid)
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        [JsonIgnore]
        public List<BaseDomainEvent> Events = new List<BaseDomainEvent>();
    }
}