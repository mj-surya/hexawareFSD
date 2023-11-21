using HotelBookingAPI.Models;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace HotelBookingAPI.Contexts
{
    public class BookingContext : DbContext
    {
        public BookingContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomAmenity> RoomAmenities { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>()
           .HasOne(e => e.room)
           .WithMany()
           .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
