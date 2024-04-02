using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using quizlet_back.Repository.DbModel.Base;

namespace quizlet_back.Repository.DbModel
{
    [Serializable, DataContract]
    public class Card : BaseEntity
    {
        [Required]
        [DataMember(Name = "languageCode")]
        public LanguageCode LanguageCode { get; set; }

        [Required]
        [DataMember(Name = "text"), MaxLength(254)]
        public string Text { get; set; } = string.Empty;

        [DataMember(Name = "description"), MaxLength(254)]
        public string Description { get; set; } = string.Empty;

        [JsonConstructor]
        public Card(LanguageCode languageCode, string text, string description)
        {
            LanguageCode = languageCode;
            Text = text;
            Description = description;
        }

        public Card() { }
    }
}
