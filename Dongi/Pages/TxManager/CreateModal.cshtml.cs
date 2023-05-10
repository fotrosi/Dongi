using Dongi.Services;
using Dongi.Services.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Dongi.Pages.TxManager
{
    public class CreateModalModel : AbpPageModel
    {
        [BindProperty]
        public CreateTxViewModel Tx { get; set; } = new CreateTxViewModel();

        private readonly ITxManagerAppService _txManagerAppService;

        public CreateModalModel(ITxManagerAppService txManagerAppService)
        {
            _txManagerAppService = txManagerAppService;
        }

        public async Task OnGet()
        {
            var people = await _txManagerAppService.GetPeopleAsync();
            foreach (var person in people)
            {
                Tx.TxDetails.Add(new TxDetailDto() { Person = person });
            }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var dto = ObjectMapper.Map<CreateTxViewModel, CreateUpdateTxDto>(Tx);
            await _txManagerAppService.CreateAsync(dto);
            return NoContent();
        }
    }

    public class CreateTxViewModel
    {
        [Required]
        public string Description { get; set; } = "";
        [Required]
        public DateTime Date { get; set; } = DateTime.Now;
        public List<TxDetailDto> TxDetails { get; set; } = new List<TxDetailDto>();
    }
}
