namespace Dongi.Services.Dtos
{
    public class CreateUpdateTxDto
    {
        public string Description { get; set; } = "";
        public DateTime Date { get; set; }
        public List<TxDetailDto> TxDetails { get; set; } = new List<TxDetailDto>();
    }
}
