using Microsoft.EntityFrameworkCore;
using PDWA5.Domain.Models.Entity;

namespace PDWA5.Data.Context
{
    public class ReviewContext : DbContext
    {
        public ReviewContext(DbContextOptions<ReviewContext> options) : base(options)
        {
        }

        public virtual DbSet<Review> Reviews { get; set; }
    }
}
