namespace client_app_backend.Core.Repository.Interfaces
{
    using client_app_backend.Core.Models;

    public interface IUserRepository
    {
        Task<User?> Get(string email);

        Task Create(string email, decimal balance);

        Task<int> Save();
    }
}
