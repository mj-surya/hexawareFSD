using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.Contexts
{
    public class BookingContext: DbContext
    {
        public BookingContext(DbContextOptions options) : base(options)
        {

        }
        /// <summary>
        /// Creates User table in database
        /// </summary>
        public DbSet<User> Users { get; set; }
    }
}
