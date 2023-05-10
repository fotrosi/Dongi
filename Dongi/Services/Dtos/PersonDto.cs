using Volo.Abp.Application.Dtos;

namespace Dongi.Services.Dtos
{
    public class PersonDto : FullAuditedEntityDto<int>
    {
        public string Name { get; set; }
    }
}
