using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uppgift3
{
    class City
    {
        public City(string name, int inhabitants, int middleIncome, int numOfTourists, List<Accommodations> accommodations)
        {
            Name = name;
            Inhabitants = inhabitants;
            MiddleIncome = middleIncome;
            NumOfTourists = numOfTourists;
            Accommodations = accommodations;
            AverageCost = accommodations.Average(a => a.Price);
            CountValues = accommodations.Count();
        }

        public string Name { get; private set; } //Stadens Namn
        public int Inhabitants { get; set; }
        public int MiddleIncome { get; set; } //per invånare
        public int NumOfTourists { get; set; } //per år
        public List<Accommodations> Accommodations { get; } = new List<Accommodations>();
        public int AccommodationsCount
        {
            //Returnerar Antalet Övernattningar
            get { return Accommodations.Count; }
        }
        public double AverageCost { get; set; } //Medelkostnad per natt i AirBnb
        public int CountValues { get; set; }
    }
}
