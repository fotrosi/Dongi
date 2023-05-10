using Dongi.Services;
using Dongi.Services.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Dongi.Pages.Persons
{
    public class EditModalModel : AbpPageModel
    {
        [HiddenInput]
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }

        [BindProperty]
        public CreateUpdatePersonDto Person { get; set; }

        private readonly IPersonAppService _personAppService;

        public EditModalModel(IPersonAppService personAppService)
        {
            _personAppService = personAppService;
        }

        public async Task OnGetAsync()
        {
            var personDto = await _personAppService.GetAsync(Id);
            Person = ObjectMapper.Map<PersonDto, CreateUpdatePersonDto>(personDto);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _personAppService.UpdateAsync(Id, Person);
            return NoContent();
        }
    }
}
