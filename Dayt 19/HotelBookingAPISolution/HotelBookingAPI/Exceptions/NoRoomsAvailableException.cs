using System.Runtime.Serialization;

namespace HotelBookingAPI.Services
{
    [Serializable]
    internal class NoRoomsAvailableException : Exception
    {
        string message;
        public NoRoomsAvailableException()
        {
            message = "No rooms are availble to display";
        }
        public override string Message => message;
    }
}
