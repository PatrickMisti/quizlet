using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace quizlet_back.Models
{
    [Serializable, DataContract]
    public class User: BaseEntity
    {
        [EmailAddress]
        [DataMember(Name = "email")]
        public string Email { get; set; } = string.Empty;
        [DataMember(Name = "password")]
        public string Password { get; set; } = string.Empty;
        [DataMember(Name = "role")]
        public Role Role { get; set; } = Role.User;

        [JsonConstructor]
        public User(string email, string password, Role role)
        {
            Email = email;
            Password = password;
            Role = role;
        }

        public User() {}
    }
}
