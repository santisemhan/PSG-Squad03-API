namespace client_app_backend.Core.Models
{
    using client_app_backend.Core.DataTransferObjects;
    using client_app_backend.Core.Enums;
    using System.ComponentModel.DataAnnotations;

    public class Survey
    {
        [Key]
        public string Id { get; set; }

        public string Question { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public List<string> OptionList { get; set; }

        public SurveyOptionType OptionType { get; set; }

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
            OptionList = dto.OptionList;
            OptionType = dto.OptionType;
        }
    }
}
