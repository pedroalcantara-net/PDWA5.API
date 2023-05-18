using PDWA5.Domain.Models.DTO;

namespace PDWA5.Domain.Interface.Service
{
    public interface IReviewService
    {
        ReviewDto GetById(int id);
        IEnumerable<ReviewDto> Get();
        ReviewDto Add(CreateReviewDto review);
        ReviewDto Update(ReviewDto review);
        void DeleteById(int id);
    }
}
