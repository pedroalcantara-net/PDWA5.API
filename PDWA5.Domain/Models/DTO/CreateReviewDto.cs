using System.ComponentModel.DataAnnotations;

namespace PDWA5.Domain.Models.DTO
{
    /// <summary>
    /// Tipo com informações básicas para cadastro de uma Review.
    /// </summary>
    public class CreateReviewDto
    {
        /// <summary>
        /// Título do filme analisado.
        /// </summary>
        [Required]
        public string MovieName { get; set; }
        /// <summary>
        /// Nota de 1 a 5 do filme analisado.
        /// </summary>
        [Required]
        public int Rate { get; set; }
        /// <summary>
        /// Corpo da Review.
        /// </summary>
        [Required]
        public string Text { get; set; }
        /// <summary>
        /// Autor da Review.
        /// </summary>
        [Required]
        public string Author { get; set; }
    }
}
