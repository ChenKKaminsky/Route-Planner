using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutePlanner.Google
{
    public class DistanceMatrixResponse : GoogleServiceData
    {
        public string[] Destination_Addresses { get; set; }
        public string[] Origin_Addresses { get; set; }
        public Row[] Rows { get; set; }
        public string Status { get; set; }
    }

    public class Row
    {
        public Element[] Elements { get; set; }
    }

    public class Element
    {
        public Item Distance { get; set; }
        public Item Duration { get; set; }
        public string Status { get; set; }
    }

    public class Item
    {
        public string Text { get; set; }
        public int Value { get; set; }
    }
}
