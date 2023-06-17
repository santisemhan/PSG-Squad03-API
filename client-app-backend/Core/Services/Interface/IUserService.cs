namespace client_app_backend.Core.Services.Interface
{
    using client_app_backend.Core.DataTransferObjects.User;

    public interface IUserService
    {
        Task<BalanceDTO> GetBalance(string email);

        Task UpdateBalance(string email, decimal balance);
    }
}
