using Switchboard.Mapping;
using Switchboard.Profiles;
using Switchboard.Transformation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Switchboard
{
    public abstract class Client
    {
        private Dictionary<string, IProfile> profiles { get; set; }
       
        public Client()
        {
            profiles = new Dictionary<string, IProfile>();
        }

        protected void AddProfile(IProfile profile)
        {
            if (!profiles.ContainsKey(profile.Name))
                profiles.Add(profile.Name, profile);
        }

        protected abstract IEnumerable<IInput> GetData(Map map);

        protected abstract bool SendData(IIntermediateObject obj);

        protected IIntermediateObject CreateObject(Map map)
        {
            if (!profiles.ContainsKey(map.From) || !profiles.ContainsKey(map.To))
                 return null; // handle better

            var from = profiles[map.From];
            var to = profiles[map.To];

            var propertyMap = new List<PropertyMapItem>();

            foreach (var item in map.Items)
            {
                propertyMap.Add(PropertyMapItem.Create(item.Name, from, to, item.From, item.To));
            }



            var obj = IntermediateObject.Create(from, to, propertyMap.ToArray());
            

          
            //Raise event to get data - populate object
            obj.GenerateProperties(GetData(map).ToArray());


            return obj;
        }

        protected bool TransformObject(IIntermediateObject obj)
        {
            return SendData(obj);
        }

        protected bool ProcessObject(Map map)
        {
            var obj = CreateObject(map);



            return TransformObject(obj);
        }
    }
}
