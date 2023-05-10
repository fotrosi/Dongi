using Dongi.Services;
using Dongi.Services.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Dongi.Pages.TxManager
{
    public class DetailModalModel : AbpPageModel
    {
        [BindProperty]
        public List<TxDetailListDto> TxDetails { get; set; } = new List<TxDetailListDto>();

        private readonly ITxManagerAppService _txManagerAppService;

        public DetailModalModel(ITxManagerAppService txManagerAppService)
        {
            _txManagerAppService = txManagerAppService;
        }

        public async Task OnGet(long id)
        {
            TxDetails = await _txManagerAppService.GetDetailAsync(id);
        }
    }
}
