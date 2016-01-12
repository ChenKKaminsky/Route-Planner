using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutePlanner.Google
{
    public class DirectionsResponse
    {
        public GeocodedWaypoint[] Geocoded_Waypoints { get; set; }
        public Route[] Routes { get; set; }
        public string Status { get; set; }
    }
    
    public class GeocodedWaypoint
    {
        public string Geocoder_status { get; set; }
        public string place_id { get; set; }
        public string[] types { get; set; }
    }

    public class Route
    {
        public Bound Bounds { get; set; }
        public string Copyrights { get; set; }
        public Leg[] Legs { get; set; }
        public Polyline Overview_Polyline { get; set; }
        public string Summary { get; set; }
        public string[] Warnings { get; set; }
        public int[] Waypoint_Order { get; set; }
    }

    public class Bound
    {
        public Point Northeast { get; set; }
        public Point Southwest { get; set; }
    }

    public class Point
    {
        public string lat { get; set; }
        public string lng { get; set; }
    }

    public class Leg
    {
        public Item Distance { get; set; }
        public Item Duration { get; set; }
        public string End_Address { get; set; }
        public Point End_Location { get; set; }
        public string Start_Address { get; set; }
        public Point Start_Location { get; set; }
        public Step[] Steps { get; set; }
        public int Via_Waypoints { get; set; }
    }

    public class Step
    {
        public Item Distance { get; set; }
        public Item Duration { get; set; }
        public Point End_Location { get; set; }
        public string Html_Instructions { get; set; }
        public Polyline Polyline { get; set; }
        public Point Start_Location { get; set; }
        public string Travel_Mode { get; set; }
    }

    public class Polyline
    {
        public string Points { get; set; }
    }

    //class Item
    //{
    //    public string Text { get; set; }
    //    public int Value { get; set; }
    //}
}
