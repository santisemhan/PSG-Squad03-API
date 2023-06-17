namespace client_app_backend.Core.Models
{
    using client_app_backend.Core.DataTransferObjects;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Survey
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public string Question { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public List<string> OptionsList { get; set; }

        [RegularExpression("^(SingleOption|MultipleOption)$")]
        public string OptionType { get; set; }

        public List<User> VotedUsers { get; set; } = new List<User>();

        public SurveyDTO ToDTO()
        {
            return new SurveyDTO(this);
        }

        private Survey() { }

        public Survey(SurveyDTO dto)
        {
            Question = dto.Question;
            CreationDate = dto.CreationDate;
            StartDate = dto.StartDate;
            EndDate = dto.EndDate;
            OptionsList = dto.OptionsList;
            OptionType = dto.OptionType;
        }
    }
}
