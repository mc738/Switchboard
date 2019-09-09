using System;
using System.Collections.Generic;
using System.Text;

namespace Switchboard.Profiles
{
    public class ProfileProperty : IProfileProperty
    {
        private string name { get; set; }
        public string Name { get { return name; } }

        public ProfileProperty()
        {

        }

        public static ProfileProperty Create(string name)
        {
            var prop = new ProfileProperty();

            prop.name = name;



            return prop;
        }
    }
}
