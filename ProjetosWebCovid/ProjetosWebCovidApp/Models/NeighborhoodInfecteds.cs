using System.Collections.Generic;

namespace ProjetosWebCovidApp.Models
{
    public class NeighborhoodInfecteds
    {
        public NeighborhoodInfecteds(Neighborhood neighborhood, List<InfectedData> InfectedsData)
        {
            Neighborhood = neighborhood;
            Infecteds = InfectedsData;
        }

        public Neighborhood Neighborhood { get; set; }
        public List<InfectedData> Infecteds { get; set; }


    }
}