using System;

namespace ProjetosWebCovidApp.Models
{
    public class InfectedData
    {
        public int ID { get; set; }
        public int Idade { get; set; }
        public string Sexo { get; set; }
        public string TpPaciente { get; set; }
        public string Bairro { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataNotificacao { get; set; }
        public DateTime DataRecuperacao { get; set; }
        public DateTime DataObito { get; set; }
    }
}