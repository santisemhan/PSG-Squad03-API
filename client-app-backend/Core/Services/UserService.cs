namespace client_app_backend.Core.Services
{
    using client_app_backend.Core.DataTransferObjects.User;
    using client_app_backend.Core.Repository.Interfaces;
    using client_app_backend.Core.Services.Interface;

    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<BalanceDTO> GetBalance(string email)
        {
            var user = await _userRepository.Get(email);
            return new BalanceDTO(email, user == null ? 0 : user.Balance);
        }

        public async Task UpdateBalance(string email, decimal balance)
        {
            var user = await _userRepository.Get(email);
            if(user == null)
            {
                await _userRepository.Create(email, balance);
            }
            else
            {
                user.Balance = balance;
            }
            await _userRepository.Save();
        }
    }
}
