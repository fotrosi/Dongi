using Volo.Abp.Domain.Entities.Auditing;

namespace Dongi.Entities
{
    public class TxDetail : FullAuditedAggregateRoot<long>
    {
        public long TxId { get; set; }
        public Tx Tx { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public decimal Amount { get; set; } = 0M;
        public decimal Quota { get; set; } = 1M;
    }
}
