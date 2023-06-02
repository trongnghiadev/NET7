using StockAppWebApi.Models;
using StockAppWebApi.ViewModels;

namespace StockAppWebApi.Repository
{
    public interface IUserRepository
    {
        Task<User?> GetById(int id);
        Task<User?> GetByUsername(string username);
        Task<User?> GetByEmail(string email);
        Task<User?> Create(RegisterViewModel registerViewModel);

    }
}
