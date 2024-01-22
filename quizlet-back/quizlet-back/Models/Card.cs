using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace quizlet_back.Models
{
    [Serializable, DataContract]
    public class Card : BaseEntity
    {
        [Required]
        [Column("de")]
        [DataMember(Name = "germanTranslate")]
        public string GermanTranslate { get; set; } = string.Empty;
        [Required]
        [Column("en")]
        [DataMember(Name = "englishTranslate")]
        public string EnglishTranslate { get; set; } = String.Empty;

        [JsonConstructor]
        public Card(string germanTranslate, string englishTranslate)
        {
            GermanTranslate = germanTranslate;
            EnglishTranslate = englishTranslate;
        }

        public Card() { }
    }
}
