using Dongi.Services;
using Dongi.Services.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Dongi.Pages.Persons
{
    public class CreateModalModel : AbpPageModel // PageModel
    {
        [BindProperty]
        public CreateUpdatePersonDto Person { get; set; }

        private readonly IPersonAppService _personAppService;

        public CreateModalModel(IPersonAppService personAppService)
        {
            _personAppService = personAppService;
        }

        public void OnGet()
        {
            Person = new CreateUpdatePersonDto();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _personAppService.CreateAsync(Person);
            return NoContent();
        }
    }
}
