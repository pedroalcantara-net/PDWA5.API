using PDWA5.Domain.Models.DTO;

namespace PDWA5.Domain.Models.Entity
{
    public class Review
    {
        public int Id { get; set; }
        public string MovieName { get; set; }
        public int Rate { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }

        public Review()
        {

        }
        public Review(ReviewDto review) : this()
        {
            Id = review.Id;
            MovieName = review.MovieName;
            Rate = review.Rate;
            Text = review.Text;
            Author = review.Author;
        }

        public Review(CreateReviewDto review) : this()
        {
            MovieName = review.MovieName;
            Rate = review.Rate;
            Text = review.Text;
            Author = review.Author;
        }
    }
}
