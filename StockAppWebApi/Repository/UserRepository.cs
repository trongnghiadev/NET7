using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StockAppWebApi.Models;
using StockAppWebApi.ViewModels;
using System.Diagnostics.Metrics;
using System.Numerics;

namespace StockAppWebApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly StockAppContext _dbContext;

        public UserRepository(StockAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User?> GetById(int id)
        {
            return await _dbContext.Users.FindAsync(id);
        }

        public async Task<User?> GetByUsername(string username)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> Create(RegisterViewModel registerViewModel)
        {
            //Đoạn này sẽ gọi 1 procedure trong SQL
            string sql = "EXECUTE dbo.RegisterUser @username, " +
                            "@password, " +
                            "@email, " +
                            "@phone, " +
                            "@full_name, " +
                            "@date_of_birth, " +
                            "@country";
            IEnumerable<User> result = await _dbContext.Users.FromSqlRaw(sql,
                        new SqlParameter("@username", registerViewModel.Username ?? ""),
                        new SqlParameter("@password", registerViewModel.Password),
                        new SqlParameter("@email", registerViewModel.Email),
                        new SqlParameter("@phone", registerViewModel.Phone ?? ""),
                        new SqlParameter("@full_name", registerViewModel.FullName ?? ""),
                        new SqlParameter("@date_of_birth", registerViewModel.DateOfBirth),
                        new SqlParameter("@country", registerViewModel.Country)).ToListAsync();

            User? user = result.FirstOrDefault();
            return user;
        }
    }
}
