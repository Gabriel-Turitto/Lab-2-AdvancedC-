using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_2_C__Data_Structures
{
    public class Videogames : IComparable<Videogames>
    {
        public string Name { get; set; }
        public string Platform { get; set; }
        public int Year { get; set; }
        public string Genre { get; set; }
        public string Publisher { get; set; }
        public double NA_Sales { get; set; }
        public double EU_Sales { get; set; }
        public double JP_Sales { get; set; }
        public double Other_Sales { get; set; }
        public double Global_Sales { get; set; }

        public Videogames() { }

        public Videogames(string name, string platform, int year, string genre, string publisher, double naSales, double euSales, double jpSales, double otherSales, double globalSales)
        {
            this.Name = name;
            this.Platform = platform;
            this.Year = year;
            this.Genre = genre;
            this.Publisher = publisher;
            this.NA_Sales = naSales;
            this.EU_Sales = euSales;
            this.JP_Sales = jpSales;
            this.Other_Sales = otherSales;
            this.Global_Sales = globalSales;
        }

        public int CompareTo(Videogames? other)
        {
            return Name.CompareTo(other.Name);
        }



        public override string ToString()
        {
            string msg = "";
            msg += $"Name: {Name}\n";
            msg += $"Platform: {Platform}\n";
            msg += $"Year: {Year} \n";
            msg += $"Genre: {Genre} \n";
            msg += $"Publisher: {Publisher} \n";
            msg += $"NA Sales: {NA_Sales} \n";
            msg += $"EU Sales: {EU_Sales} \n";
            msg += $"JP Sales: {JP_Sales} \n";
            msg += $"Other Sales: {Other_Sales} \n";
            msg += $"Global Sales: {Global_Sales}  \n";


            return msg;
        }
    }
}
