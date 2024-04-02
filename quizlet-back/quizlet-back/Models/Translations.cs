using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using quizlet_back.Repository.DbModel;

namespace quizlet_back.Models
{
    [Serializable, DataContract]
    public class Translations
    {
        [DataMember(Name = "currentLanguage")]
        [Required]
        public Card CurrentLanguage { get; set; }

        [DataMember(Name = "translateLanguage")]
        [Required]
        public Card TranslateLanguage { get; set; }


        public Translations() { }

        [JsonConstructor]
        public Translations(Card currentLanguage, Card translateLanguage)
        {
            CurrentLanguage = currentLanguage;
            TranslateLanguage = translateLanguage;
        }

        public Translations(TranslationHistory history)
        {
            CurrentLanguage = history.CurrentCard;
            TranslateLanguage = history.OtherCard;
        }
    }
}
