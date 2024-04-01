using System.ComponentModel.DataAnnotations;

namespace todoAPI.models
{
    public class ListForUpdateDto
    {
        [Required(ErrorMessage = "A Name value is Required")]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
    }
}
