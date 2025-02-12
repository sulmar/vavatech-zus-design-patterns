using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace FactoryPattern.Models
{
    public class Test
    {
        public void DoWork()
        {            
            Coordinate coordinate = Coordinate.Factory.NewFromWkt("POINT (1, 2)");
        }
    }


    public partial class Coordinate
	{
		// Długość geograficzna	
		public double Longitude { get; }

		// Szerokość geograficzna
		public double Latitude { get; }

		public Coordinate(double lng, double lat)
		{
			this.Longitude = lng;
			this.Latitude = lat;
		}

        public class Factory
        {
            public static Coordinate NewFromWkt(string wkt)
            {
                const string pattern = @"POINT \((\d*)\s(\d*)\)";

                Regex regex = new Regex(pattern);

                Match match = regex.Match(wkt);

                if (match.Success)
                {
                    double lng = double.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture);
                    double lat = double.Parse(match.Groups[2].Value, CultureInfo.InvariantCulture);

                    return new Coordinate(lng, lat);
                }
                else
                {
                    throw new FormatException();
                }
            }

            public static Coordinate NewFromGeoJson(string geojson)
            {
                const string pattern = @"\[(\d*), (\d*)\]";

                Regex regex = new Regex(pattern);


                Match match = regex.Match(geojson);

                if (match.Success)
                {

                    double lng = double.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture);
                    double lat = double.Parse(match.Groups[2].Value, CultureInfo.InvariantCulture);

                    return new Coordinate(lng, lat);
                }
                else
                {
                    throw new FormatException();
                }
            }
        }

    }
}
