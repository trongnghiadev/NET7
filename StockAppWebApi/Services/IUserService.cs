using StockAppWebApi.Models;
using StockAppWebApi.ViewModels;

namespace StockAppWebApi.Services
{
    public interface IUserService
    {
        Task<User?> Register(RegisterViewModel user);
    }
}
