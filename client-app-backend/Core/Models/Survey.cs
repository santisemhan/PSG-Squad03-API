namespace client_app_backend.Core.Models
{
    using client_app_backend.Core.DataTransferObjects;
    using System.ComponentModel.DataAnnotations;

    public class Survey
    {
        [Key]
        public int Id { get; set; }

        public string Question { get; set; }

        public string Owner { get; set; }

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
            Id = dto.Id;
            Question = dto.Question;
            Owner = dto.Owner;
            CreationDate = dto.CreationDate;
            StartDate = dto.StartDate;
            EndDate = dto.EndDate;
            OptionsList = dto.OptionsList.Split(",").ToList();
            OptionType = dto.OptionType;
        }
    }
}
