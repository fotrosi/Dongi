using Dongi.Entities;
using Dongi.Services.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Dongi.Services
{
    public class PersonAppService :
    CrudAppService<
        Person,
        PersonDto,
        int,
        PagedAndSortedResultRequestDto,
        CreateUpdatePersonDto>, IPersonAppService
    {
        public PersonAppService(IRepository<Person, int> repository) : base(repository)
        {
        }
    }
}
