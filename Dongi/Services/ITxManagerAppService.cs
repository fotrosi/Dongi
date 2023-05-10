using Dongi.Services.Dtos;
using Volo.Abp.Application.Dtos;

namespace Dongi.Services
{
    public interface ITxManagerAppService
    {
        public Task<PagedResultDto<TxDto>> GetListAsync(PagedAndSortedResultRequestDto input);
        public Task<List<PersonDto>> GetPeopleAsync();
        public Task CreateAsync(CreateUpdateTxDto input);
        public Task<PagedResultDto<CheckoutDto>> CheckoutAsync(PagedAndSortedResultRequestDto input);
        public Task<List<TxDetailListDto>> GetDetailAsync(long id);
        public Task DeleteAsync(long id);
    }
}
