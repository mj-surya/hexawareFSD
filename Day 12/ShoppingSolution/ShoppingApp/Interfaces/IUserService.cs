using ShoppingApp.Models.DTOs;

namespace ShoppingApp.Interfaces
{
    public interface IUserService
    {
        UserVewModel Login(UserVewModel userDTO);
        UserVewModel Register(UserVewModel userDTO);
    }
}