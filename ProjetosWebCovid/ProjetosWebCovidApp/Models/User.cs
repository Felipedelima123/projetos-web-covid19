using System.Collections.Generic;

namespace ProjetosWebCovidApp.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public ICollection<UserPosition> UserPositions { get; set; }
    }
}