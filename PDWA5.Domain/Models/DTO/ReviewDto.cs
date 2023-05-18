using PDWA5.Domain.Models.Entity;

namespace PDWA5.Domain.Models.DTO
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public int Rate { get; set; }
        public string Text { get; set; }
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
