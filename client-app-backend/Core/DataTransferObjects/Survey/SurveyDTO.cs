namespace client_app_backend.Core.DataTransferObjects
{
    using client_app_backend.Core.Models;

    public class SurveyDTO
    {
        public string Owner { get; set; }

        public string Question { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string OptionsList { get; set; }

        public string OptionType { get; set; }

        public SurveyDTO() { }

        public SurveyDTO(Survey surveyEntity)
        {
            Owner = surveyEntity.Owner;
            Question = surveyEntity.Question;
            CreationDate = surveyEntity.CreationDate;
            StartDate = surveyEntity.StartDate;
            EndDate = surveyEntity.EndDate;
            OptionsList = string.Join(",", surveyEntity.OptionsList);
            OptionType = surveyEntity.OptionType;
        }

        public Survey ToEntity()
        {
            return new Survey(this);
        }
    }
}
