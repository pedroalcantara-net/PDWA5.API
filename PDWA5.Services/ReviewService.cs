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
            _reviewRepository.DeleteById(id);
        }

        public IEnumerable<ReviewDto> Get()
        {
            var reviews = _reviewRepository.Get().Select(x => new ReviewDto(x));
            return reviews ?? throw new NotFoundException("Registros não encontrados.");
        }

        public ReviewDto GetById(int id)
        {
            var entity = _reviewRepository.GetById(id);
            return entity == null ? throw new NotFoundException("Registro não encontrado.") : new ReviewDto(entity);
        }

        public ReviewDto Update(ReviewDto review)
        {
            var entity = new Review(review);
            entity = _reviewRepository.Update(entity);
            return new ReviewDto(entity);
        }
    }
}
