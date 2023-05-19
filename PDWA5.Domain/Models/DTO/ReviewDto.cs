using PDWA5.Domain.Models.Entity;
using System.ComponentModel.DataAnnotations;

namespace PDWA5.Domain.Models.DTO
{
    /// <summary>
    /// Tipo de retorno de informações de Reviews cadastradas no sistema.
    /// </summary>
    public class ReviewDto
    {
        /// <summary>
        /// Identificador único da Review.
        /// </summary>
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// Nome do filme analisado.
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
        public ReviewDto()
        {

        }
        public ReviewDto(Review review) : this()
        {
            Id = review.Id;
            MovieName = review.MovieName;
            Rate = review.Rate;
            Text = review.Text;
            Author = review.Author;
        }
    }
}
