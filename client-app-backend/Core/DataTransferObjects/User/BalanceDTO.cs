namespace client_app_backend.Core.DataTransferObjects.User
{
    public class BalanceDTO
    {
        public string Email { get; set; }

        public decimal Balance { get; set; }

        public string Symbol { get; set; }

        public BalanceDTO() { }

        public BalanceDTO(string email, decimal balance)
        {
            Email = email;
            Balance = balance;
            Symbol = "PSG";
        }
    }
}
