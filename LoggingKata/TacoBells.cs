using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingKata
{
    public class TacoBells : ITrackable
    {
        public string Name;
        public double lat;
        public double longi;

        public TacoBells(string name, double lat, double longi)
        {
            this.Name = name;
            this.lat = lat;
            this.longi = longi;
        }
        public TacoBells(){}

        string ITrackable.Name { get; set; }
        Point ITrackable.Location { get; set; }

    }
}
