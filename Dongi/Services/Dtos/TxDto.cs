using Volo.Abp.Application.Dtos;

namespace Dongi.Services.Dtos
{
    public class TxDto : FullAuditedEntityDto<long>
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal TotalQuota { get; set; }
    }
}
