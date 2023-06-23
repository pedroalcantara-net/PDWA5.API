using PDWA5.Domain.Exceptions;
using PDWA5.Domain.Interface.Repository;
using PDWA5.Domain.Interface.Service;
using PDWA5.Domain.Models.DTO;
using PDWA5.Domain.Models.Entity;

namespace PDWA5.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        public ReviewService(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public ReviewDto Add(CreateReviewDto review)
        {
            var entity = new Review(review);
            entity = _reviewRepository.Add(entity);
            return new ReviewDto(entity);
        }

        public void DeleteById(int id)
        {
            var entity = _reviewRepository.GetById(id);
            if (entity == null) throw new NotFoundException("Review not found.");

            _reviewRepository.DeleteById(id);
        }

        public IEnumerable<ReviewDto> Get() => _reviewRepository.Get().Select(x => new ReviewDto(x));

        public ReviewDto GetById(int id)
        {
            var review = _reviewRepository.GetById(id);
            return new ReviewDto(review);
        }

        public ReviewDto Update(ReviewDto reviewDto)
        {
            var entity = _reviewRepository.GetById(reviewDto.Id);
            if (entity == null) throw new NotFoundException("Review not found.");

            var review = new Review(reviewDto);
            review = _reviewRepository.Update(review);
            return new ReviewDto(review);
        }
    }
}
