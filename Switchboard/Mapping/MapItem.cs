using System;
using System.Collections.Generic;
using System.Text;

namespace Switchboard.Mapping
{
    public class MapItem
    {
        private string from { get; set; }
        private string to { get; set; }
        private string name { get; set; }


        public string From { get { return from; } }
        public string To { get { return to; } }
        public string Name { get { return name; } }

        private MapItem()
        {

        }

        public static MapItem Create(string name, string from, string to)
        {
            var item = new MapItem();

            item.name = name;
            item.to = to;
            item.from = from;

            return item;
        }
    }
}
