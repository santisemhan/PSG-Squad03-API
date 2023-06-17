namespace client_app_backend.Core.Models
{
    using Microsoft.EntityFrameworkCore.Metadata.Internal;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class User
    {
        [Key]
        public string Email { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Balance { get; set; }

        public List<Survey> VotedSurveys { get; set; } = new List<Survey>();

        private User() { }

        public User(string email, decimal balance)
        {
            Email = email;
            Balance = balance;
        }
    }
}
