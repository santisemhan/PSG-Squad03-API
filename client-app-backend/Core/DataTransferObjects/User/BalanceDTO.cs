namespace client_app_backend.Core.DataTransferObjects.User
{
    public class BalanceDTO
    {
        public decimal Balance { get; set; }

        public BalanceDTO() { }

        public BalanceDTO(decimal balance)
        {
            Balance = balance;
        }
    }
}
