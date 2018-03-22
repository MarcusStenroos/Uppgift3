//Inlämningsuppgift 3
//Elev:         Marcus Stenroos
//Lärare:       Leo Carlsson
//Inlämningsdag:2018-03-22



using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient;



namespace uppgift3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }


        private void Form1_Load(object sender, EventArgs e)

        {


            //Skapar en lista med städerna
            List<string> cityNames = new List<string>
            {
                "Boston", "Amsterdam", "Barcelona"
            };
            List<City> cities = new List<City>();

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = "Data Source = DESKTOP-5PLMH55\\MARCUSSQL;Initial Catalog=Inlämningsuppgift_3_Csharp_Dashboard_Plug_in;Integrated Security=True";


            foreach (var item in cityNames)
            {


                try
                {
                    conn.Open();

                    SqlCommand myQuery = new SqlCommand("SELECT * FROM " + item + ";", connection: conn);

                    SqlDataReader myReader = myQuery.ExecuteReader();


                    List<Accommodations> accommodationsList = new List<Accommodations>();

                    int room_id;
                    int host_id;
                    string room_Type;
                    string borough;
                    string neighborhood;
                    int reviews;
                    double overall_Satisfaction; //Kolla
                    int accommodates;
                    double bedrooms;
                    double price;
                    int minStay;
                    double latitude;
                    double longitude;
                    string last_Modified;

                    string letOS;
                    string letBed;
                    string letLatitud;
                    string letLongitud;
                    string letPrice;
                    bool myMinStay;


                    //Skapar en lista som är lokal som finns bara just i den här metoden

                    while (myReader.Read())
                    {
                        room_id = (int)myReader["room_id"];
                        host_id = (int)myReader["host_id"];
                        room_Type = (string)myReader["room_Type"];
                        borough = myReader["borough"].ToString();
                        neighborhood = myReader["neighborhood"].ToString();
                        reviews = (int)myReader["reviews"];
                        letOS = myReader["Overall_Satisfaction"].ToString();
                        overall_Satisfaction = double.Parse(letOS);
                        accommodates = (int)myReader["accommodates"];
                        letBed = myReader["bedrooms"].ToString();
                        bedrooms = double.Parse(letBed);
                        letPrice = myReader["price"].ToString();
                        price = double.Parse(letPrice);
                        myMinStay = int.TryParse(Convert.ToString(myReader["minStay"]), out minStay);
                        if (myMinStay == false)
                        {
                            minStay = 0;
                        }
                        else
                        {
                            minStay = (int)myReader["minStay"];
                        }
                        letLatitud = myReader["latitude"].ToString();
                        latitude = double.Parse(letLatitud);
                        letLongitud = myReader["longitude"].ToString();
                        longitude = double.Parse(letLongitud);
                        last_Modified = myReader["last_Modified"].ToString();

                        //Skapar ett nytt objekt
                        Accommodations accommodations = new Accommodations(
                            room_id,
                            host_id,
                            room_Type,
                            borough,
                            neighborhood,
                            reviews,
                            overall_Satisfaction,
                            accommodates,
                            bedrooms,
                            price,
                            minStay,
                            latitude,
                            longitude,
                            last_Modified
                            );
                        //Lägger in objekten en efter en. Listan används till att räkna fram medelpris
                        accommodationsList.Add(accommodations);

                    }



                    //Använder Linq för att ta fram medelvärdet
                    City city = new City(item, 0, 0, 0, accommodationsList);
                    cities.Add(city);

                }


                catch (Exception ex)
                {

                    Console.WriteLine(ex);
                }
                finally
                {
                    conn.Close();
                }
                }

            //Går genom listorna mha foreach för att hitta alla priser per stad
            foreach (City c in cities)
            {
                switch (c.Name)
                {
                    case "Boston":
                        foreach (Accommodations ac in c.Accommodations.Where(y => y.RoomType == "Private room"))
                        {
                            boston1.Series["BOSTON"].Points.AddY(ac.Price);
                        };

                        break;
                    case "Amsterdam":
                        foreach (Accommodations ac in c.Accommodations.Where(y => y.RoomType == "Private room"))
                        {
                            amsterdam1.Series["AMSTERDAM"].Points.AddY(ac.Price);
                        };

                        break;

                    case "Barcelona":
                        foreach (Accommodations ac in c.Accommodations.Where(y => y.RoomType == "Private room"))
                        {
                            barcelona1.Series["BARCELONA"].Points.AddY(ac.Price);
                        };

                        break;
                    default:
                        break;
                }
                //Går genom listorna mha foreach för att hitta alla priser per stad och overall-satisfaction
                foreach (City cc in cities)
                {
                    switch (cc.Name)
                    {
                        case "Boston": //Vill ej ha med 0 värden
                            foreach (Accommodations ac in cc.Accommodations.Where(y => y.OverallSatisfaction < 4.5 && y.OverallSatisfaction != 0))
                            {
                                boston2.Series["BOSTON"].Points.AddXY(ac.OverallSatisfaction, ac.Price);
                            };

                            break;

                        case "Amsterdam": //Vill ej ha med 0 värden
                            foreach (Accommodations ac in cc.Accommodations.Where(y => y.OverallSatisfaction < 4.5 && y.OverallSatisfaction != 0))
                            {
                                amsterdam2.Series["AMSTERDAM"].Points.AddXY(ac.OverallSatisfaction, ac.Price);
                            };

                            break;

                        case "Barcelona": //Vill ej ha med 0 värden
                            foreach (Accommodations ac in cc.Accommodations.Where(y => y.OverallSatisfaction < 4.5 && y.OverallSatisfaction != 0))
                            {
                                barcelona2.Series["BARCELONA"].Points.AddXY(ac.OverallSatisfaction, ac.Price );
                            };

                            break;
                        default:
                            break;
                    }

                }

            }

            //Ritar upp diagrammen form "Histogram" och lägger till namnen på axlarna
            boston1.Series["BOSTON"].ChartType = SeriesChartType.Column;
            boston1.Titles.Add ("Price spread on Private Rooms in Boston");
            boston1.ChartAreas[0].AxisX.Title = ("Single-Room");
            boston1.ChartAreas[0].AxisY.Title = ("Price");


            amsterdam1.Series["AMSTERDAM"].ChartType = SeriesChartType.Column;
            amsterdam1.Titles.Add("Price spread on Private Rooms in Amsterdam");
            amsterdam1.ChartAreas[0].AxisX.Title = ("Single-Room");
            amsterdam1.ChartAreas[0].AxisY.Title = ("Price");

            barcelona1.Series["BARCELONA"].ChartType = SeriesChartType.Column;
            barcelona1.Titles.Add("Price spread on Private Rooms in Barcelona");
            barcelona1.ChartAreas[0].AxisX.Title = ("Single-Room");
            barcelona1.ChartAreas[0].AxisY.Title = ("Price");


            //Ritar upp diagrammen form "Point dvs scatter plot" och lägger till namnen på axlarna
            boston2.Series["BOSTON"].ChartType = SeriesChartType.Point;
            boston2.Titles.Add("Overall-Satisfaction VS Price in Boston");
            boston2.ChartAreas[0].AxisX.Title = ("Satisfaction");
            boston2.ChartAreas[0].AxisY.Title = ("Price");

            amsterdam2.Series["AMSTERDAM"].ChartType = SeriesChartType.Point;
            amsterdam2.Titles.Add("Overall-Satisfaction VS Price in Amsterdam");
            amsterdam2.ChartAreas[0].AxisX.Title = ("Satisfaction");
            amsterdam2.ChartAreas[0].AxisY.Title = ("Price");

            barcelona2.Series["BARCELONA"].ChartType = SeriesChartType.Point;
            barcelona2.Titles.Add("Overall-Satisfaction VS Price in Barcelona");
            barcelona2.ChartAreas[0].AxisX.Title = ("Satisfaction");
            barcelona2.ChartAreas[0].AxisY.Title = ("Price");
        }

    }
    

}