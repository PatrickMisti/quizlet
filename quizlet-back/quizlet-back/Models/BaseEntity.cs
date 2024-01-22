using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace quizlet_back.Models
{
    public class BaseEntity
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        // todo actual don't know if it works
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        [Required]
        public int Id { get; set; }
    }
}
