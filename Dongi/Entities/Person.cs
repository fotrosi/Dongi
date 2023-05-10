using Volo.Abp.Domain.Entities.Auditing;

namespace Dongi.Entities
{
    public class Person : FullAuditedAggregateRoot<int>
    {
        public string Name { get; set; }
        public List<TxDetail>? TxDetails { get; set; }
    }
}
