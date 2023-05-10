using Dongi.Entities;
using Dongi.Services.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Dongi.Services
{
    public class TxManagerAppService : ApplicationService, ITxManagerAppService
    {
        private readonly IRepository<Person, int> _personRepository;
        private readonly IRepository<Tx, long> _txRepository;
        private readonly IRepository<TxDetail, long> _txDetailRepository;

        public TxManagerAppService(
            IRepository<Person, int> personRepository,
            IRepository<Tx, long> txRepository,
            IRepository<TxDetail, long> txDetailRepository
            )
        {
            _personRepository = personRepository;
            _txRepository = txRepository;
            _txDetailRepository = txDetailRepository;
        }

        public virtual async Task<PagedResultDto<TxDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            var list = await _txRepository.GetPagedListAsync(input.SkipCount, input.MaxResultCount, input.Sorting);
            var totalCount = await _txRepository.CountAsync();
            return new PagedResultDto<TxDto>(totalCount, ObjectMapper.Map<List<Tx>, List<TxDto>>(list));
        }

        public virtual async Task<List<PersonDto>> GetPeopleAsync()
        {
            var People = await _personRepository.GetListAsync();
            return ObjectMapper.Map<List<Person>, List<PersonDto>>(People);
        }

        public virtual async Task CreateAsync(CreateUpdateTxDto input)
        {
            var Tx = new Tx() { Description = input.Description, Date = input.Date };
            var txDetails = new List<TxDetail>();
            foreach (var txd in input.TxDetails.Where(x => !(x.Amount == 0 && x.Quota == 0)))
            {
                Tx.TotalAmount += txd.Amount;
                Tx.TotalQuota += txd.Quota;
                var txDetail = new TxDetail() { Tx = Tx, TxId = Tx.Id, PersonId = txd.Person.Id, Amount = txd.Amount, Quota = txd.Quota };
                txDetails.Add(txDetail);
            }
            await _txDetailRepository.InsertManyAsync(txDetails);
        }

        public virtual async Task<PagedResultDto<CheckoutDto>> CheckoutAsync(PagedAndSortedResultRequestDto input)
        {
            var People = await _personRepository.GetListAsync();
            var totalCount = People.Count();
            var checkouts = new List<CheckoutDto>();
            var txd = await _txDetailRepository.GetListAsync();
            var tx = await _txRepository.GetListAsync();
            foreach (var person in People.OrderBy(x => x.Name))
            {
                var checkout = new CheckoutDto();
                checkout.Name = person.Name;
                var txDetails = await _txDetailRepository.GetListAsync(x => x.PersonId == person.Id);
                var ca = 0M;
                foreach (var txDetail in txDetails)
                {
                    ca += txDetail.Amount - txDetail.Tx.TotalAmount * txDetail.Quota / txDetail.Tx.TotalQuota;
                }
                checkout.CheckoutAmount = ca.ToString("##,#");
                checkouts.Add(checkout);
            }
            return new PagedResultDto<CheckoutDto>(totalCount, checkouts);
        }

        public virtual async Task<List<TxDetailListDto>> GetDetailAsync(long id)
        {
            var people = await GetPeopleAsync();
            var list = await _txDetailRepository.GetListAsync(x => x.TxId == id);
            var result = new List<TxDetailListDto>();
            foreach (var item in list)
            {
                var r = new TxDetailListDto();
                r.PersonName = people.First(x => x.Id == item.PersonId).Name;
                r.Amount = item.Amount.ToString("##,#");
                r.Quota = item.Quota.ToString("##,#");
                result.Add(r);
            }
            return result;
        }

        public virtual async Task DeleteAsync(long id)
        {
            var list = await _txDetailRepository.GetListAsync(x => x.TxId == id);
            await _txDetailRepository.DeleteManyAsync(list);
            await _txRepository.DeleteAsync(id);
        }
    }
}
