using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uppgift3
{
    class Country
    {
        public Country(string name, int inhabitants, int bnbPerCapita, List<City> cities)
        {
            Name = name;
            Inhabitants = inhabitants;
            BnbPerCapita = bnbPerCapita;
            Cities = cities;
        }

        public string Name { get; private set; } //Landets Namn
        public int Inhabitants { get; set; } //Antal invånare i landet
        public int BnbPerCapita { get; set; }
        public List<City> Cities { get; } = new List<City>();

    }


    

   


}
