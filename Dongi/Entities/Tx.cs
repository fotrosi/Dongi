using Volo.Abp.Domain.Entities.Auditing;

namespace Dongi.Entities
{
    public class Tx : FullAuditedAggregateRoot<long>
    {
        public string Description { get; set; } = "";
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; } = 0M;
        public decimal TotalQuota { get; set; } = 0M;
        public List<TxDetail>? TxDetails { get; set; }
    }

}
