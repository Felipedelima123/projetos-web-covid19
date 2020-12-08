namespace ProjetosWebCovidApp.Models
{
    public class UserPosition
    {
        public int ID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int UserId { get; set; }
    }
}