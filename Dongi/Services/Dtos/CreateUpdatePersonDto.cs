using System.ComponentModel.DataAnnotations;

namespace Dongi.Services.Dtos
{
    public class CreateUpdatePersonDto
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
    }
}
