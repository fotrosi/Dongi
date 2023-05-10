using Dongi.Services.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Dongi.Services
{
    public interface IPersonAppService :
    ICrudAppService<
        PersonDto,
        int,
        PagedAndSortedResultRequestDto,
        CreateUpdatePersonDto>
    {
    }
}
