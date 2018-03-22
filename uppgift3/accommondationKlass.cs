using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uppgift3
{
    class Accommodations
    {
        public Accommodations(int roomID, int hostID, string roomType,
            string borough, string neighborhood, int reviews,
            double overallSatisfaction, int accomodates, double bedrooms,
            double price, int minStay, double latitude, double longitude,
            string lastModified)
        {
            RoomId = roomID;
            HostId = hostID;
            RoomType = roomType;
            Borough = borough;
            Neighborhood = neighborhood;
            Reviews = reviews;
            OverallSatisfaction = overallSatisfaction;
            Accomodates = accomodates;
            Bedrooms = bedrooms;
            Price = price;
            MinStay = minStay;
            Latitude = latitude;
            Longitude = longitude;
            Last_Modified = lastModified;
        }


        public int RoomId { get; set; }
        public int HostId { get; set; }
        public string RoomType { get; set; }
        public string Borough { get; set; }
        public string Neighborhood { get; set; }
        public int Reviews { get; set; }
        public double OverallSatisfaction { get; set; }
        public int Accomodates { get; set; }
        public double Bedrooms { get; set; }
        public double Price { get; set; }
        public int MinStay { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Last_Modified { get; set; }



    }
}
