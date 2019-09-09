using System;
using System.Collections.Generic;
using System.Text;

namespace Switchboard.Profiles
{
    public class Profile : IProfile
    {
        private string name { get; set; }
        private Dictionary<string, IProfileProperty> properties { get; set; }
        private Dictionary<string, IProfile> children { get; set; }

        public string Name { get { return name; } }
        public IEnumerable<IProfileProperty> Properties { get { return properties.Values; } }
        public IEnumerable<IProfile> Children { get { return children.Values; } }

        public Profile()
        {
            properties = new Dictionary<string, IProfileProperty>();
            children = new Dictionary<string, IProfile>();
        }

        public static IProfile Create(string name, params IProfileProperty[] props)
        {
            var profile = new Profile();

            profile.name = name;


            foreach (var prop in props)
            {
                profile.properties.Add(prop.Name, prop);
            }

            return profile;
        }

        public void AddChild(IProfile child)
        {
            if (!children.ContainsKey(child.Name))
                children.Add(child.Name, child);
        }

        public void AddProperty(IProfileProperty prop)
        {
            if (!properties.ContainsKey(prop.Name))
                properties.Add(prop.Name, prop);
        }

        public IProfileProperty GetProperty(string name)
        {
            if (properties.ContainsKey(name))
                return properties[name];

            return null;
        }

        public IProfile GetChild(string name)
        {
            if (children.ContainsKey(name))
                return children[name];

            return null;
        }

    }
}
