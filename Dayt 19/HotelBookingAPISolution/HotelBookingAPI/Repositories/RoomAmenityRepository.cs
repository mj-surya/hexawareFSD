using HotelBookingAPI.Contexts;
using HotelBookingAPI.Interfaces;
using HotelBookingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBookingAPI.Repositories
{
    public class RoomAmenityRepository : IRepository<int, RoomAmenity>
    {
        private readonly BookingContext _context;

        public RoomAmenityRepository(BookingContext context)
        {
            _context = context;
        }
        public RoomAmenity Add(RoomAmenity entity)
        {
            _context.RoomAmenities.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public RoomAmenity Delete(int key)
        {
            var amenity = GetById(key);
            if (amenity != null)
            {
                _context.RoomAmenities.Remove(amenity);
                _context.SaveChanges();
                return amenity;
            }
            return null;
        }

        public IList<RoomAmenity> GetAll()
        {
            if(_context.RoomAmenities.Count() == 0)
                return null;
            return _context.RoomAmenities.ToList();
        }

        public RoomAmenity GetById(int key)
        {
            var amenity = _context.RoomAmenities.SingleOrDefault(u => u.RoomAmenityId == key);
            return amenity;
        }

        public RoomAmenity Update(RoomAmenity entity)
        {
            var amenity = GetById(entity.RoomAmenityId);
            if (amenity != null)
            {
                _context.Entry<RoomAmenity>(amenity).State = EntityState.Modified;
                _context.SaveChanges();
                return amenity;
            }
            return null;
        }
    }
}
