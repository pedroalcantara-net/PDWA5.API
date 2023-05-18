using System.ComponentModel.DataAnnotations;

namespace PDWA5.Domain.Models.DTO
{
    public class CreateReviewDto
    {
        [Required]
        public string MovieName { get; set; }
        [Required]
        public int Rate { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string Author { get; set; }
    }
}
