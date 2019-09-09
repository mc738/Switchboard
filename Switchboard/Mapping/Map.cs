using System;
using System.Collections.Generic;
using System.Text;

namespace Switchboard.Mapping
{
    public class Map
    {
        private string from { get; set; }
        private string to { get; set; }



       
        private List<MapItem> items { get; set; }
        private List<Map> children { get; set; }


        public List<MapItem> Items { get { return items; } }
        public List<Map> Children { get { return children; } }

        public string From { get { return from; } }
        public string To { get { return to; } }

        private Map()
        {
            items = new List<MapItem>();
            children = new List<Map>();
        }

        public static Map Create(string from, string to, params string[] itemStrs)
        {
            var items = new List<MapItem>();

            foreach (var item in itemStrs)
            {
                var splitItem = item.Split(' ');
                items.Add(MapItem.Create(splitItem[0], splitItem[1], splitItem[2]));
            }

            return Create(from, to, items.ToArray());
        }

        public static Map Create(string from, string to, params MapItem[] items)
        {
            var map = new Map();

            map.from = from;
            map.to = to;

            foreach (var item in items)
            {
                map.items.Add(item);
            }

            return map;
        }
    }
}
