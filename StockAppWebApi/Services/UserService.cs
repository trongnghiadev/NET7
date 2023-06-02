using StockAppWebApi.Models;
using StockAppWebApi.Repository;
using StockAppWebApi.ViewModels;

namespace StockAppWebApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User?> GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> Register(RegisterViewModel registerViewModel)
        {


            var existingUserByUsername = await _userRepository.GetByUsername(registerViewModel.Username ?? "");
            if (existingUserByUsername != null)
            {
                throw new Exception("Tên đăng nhập đã tồn tại.");
            }
            var existingUserByEmail = await _userRepository.GetByEmail(registerViewModel.Email ?? "");
            if (existingUserByEmail != null)
            {
                throw new Exception("Email đã tồn tại.");
            }

            // Thực hiện tạo mới người dùng
            return await _userRepository.Create(registerViewModel);
        }

  
    }
}
