using PDWA5.Data.Context;
using PDWA5.Domain.Interface.Repository;
using PDWA5.Domain.Models.Entity;

namespace PDWA5.Data.Repository
{
    public class ReviewRepository : BaseRepository<Review>, IReviewRepository
    {
        public ReviewRepository(ReviewContext context) : base(context)
        {
        }
    }
}
