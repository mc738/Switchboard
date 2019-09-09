using System;
using System.Collections.Generic;
using System.Text;

namespace Switchboard.Profiles
{
    public class PropertyMapItem : IPropertyMapItem
    {
        private string name { get; set; }
        private IProfileProperty from { get; set; }
        private IProfileProperty to { get; set; }

        public string Name { get { return name; } }
        public IProfileProperty From { get { return from; } }
        public IProfileProperty To { get { return to; } }

        private PropertyMapItem()
        {

        }

        public static PropertyMapItem Create(string name, IProfileProperty from, IProfileProperty to)
        {
            var map = new PropertyMapItem();

            map.name = name;
            map.to = to;
            map.from = from;

            return map;
        }

        public static PropertyMapItem Create(string name, IProfile from, IProfile to, string fromName, string toName)
        {
            var map = new PropertyMapItem();

            map.name = name;
            map.to = to.GetProperty(toName);
            map.from = from.GetProperty(fromName);

            return map;
        }

    }
}
