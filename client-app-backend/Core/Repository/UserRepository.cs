namespace client_app_backend.Core.Repository
{
    using client_app_backend.Core.Models;
    using client_app_backend.Core.Repository.Interfaces;
    using client_app_backend.Data;
    using Microsoft.EntityFrameworkCore;
    using System.Threading.Tasks;

    public class UserRepository : IUserRepository
    {
        private readonly DataContext _dbContext;

        public UserRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User?> Get(string email)
        {
            return await _dbContext.User
                .FirstOrDefaultAsync(user => user.Email == email);
        }

        public async Task Create(string email, decimal balance)
        {
            await _dbContext.User
                .AddAsync(new User(email, balance));
        }

        public async Task<int> Save()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
