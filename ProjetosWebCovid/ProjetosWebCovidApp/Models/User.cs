using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetosWebCovidApp.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public ICollection<UserPosition> UserPositions { get; set; }
    }
}