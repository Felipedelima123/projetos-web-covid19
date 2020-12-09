using System;
using System.ComponentModel.DataAnnotations;

namespace ProjetosWebCovidApp.Models
{
    public class Neighborhood
    {
        [Key]
        public int ID { get; set; }
        public String Name { get; set; }
        public String Geometry { get; set; }
    }
}