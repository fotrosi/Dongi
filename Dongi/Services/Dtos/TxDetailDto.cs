using Volo.Abp.Application.Dtos;

namespace Dongi.Services.Dtos
{
    public class TxDetailDto : FullAuditedEntityDto<long>
    {
        //public long TxId { get; set; }
        //public Tx Tx { get; set; }
        //public int PersonId { get; set; }
        public PersonDto Person { get; set; }
        public decimal Amount { get; set; } = 0M;
        public decimal Quota { get; set; } = 1M;
    }
}
