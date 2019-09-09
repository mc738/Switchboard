using Switchboard.Profiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Switchboard.Transformation
{
    public class IntermediateObject : IIntermediateObject
    {
        private Dictionary<string, IPropertyMapItem> propertyMap { get; set; }
        private Dictionary<string, IObjectProperty> properties { get; set; }
        private List<IIntermediateObject> children { get; set; }
        private IProfile from { get; set; }
        private IProfile to { get; set; }

        public IEnumerable<IPropertyMapItem> PropertyMap { get { return propertyMap.Values; } }
        public IEnumerable<IObjectProperty> Properties { get { return properties.Values; } }
        public IEnumerable<IIntermediateObject> Children { get { return children; } }

        private IntermediateObject()
        {
            properties = new Dictionary<string, IObjectProperty>();
            children = new List<IIntermediateObject>();
            propertyMap = new Dictionary<string, IPropertyMapItem>();
        }

        public static IIntermediateObject Create(IProfile from, IProfile to, params IPropertyMapItem[] propertyMapItems)
        {
            var obj = new IntermediateObject();

            obj.from = from;
            obj.to = to;

            foreach (var map in propertyMapItems)
            {
                if (!obj.propertyMap.ContainsKey(map.Name))
                    obj.propertyMap.Add(map.Name, map);
            }

            return obj;
        }


        public void GenerateProperties(params IInput[] inputs)
        {
            foreach (var input in inputs)
            {
                GenerateProperty(input);
            }
        }

        public void GenerateProperty(IInput input)
        {
            if (!propertyMap.ContainsKey(input.MapName))
                return; // Handle better?

            var map = propertyMap[input.MapName];


            if (properties.ContainsKey(input.MapName))
                properties[input.MapName] = ObjectProperty.Create(map.From, map.To, input.Value); //Update current property if exists
            else
                properties.Add(input.MapName, ObjectProperty.Create(map.From, map.To, input.Value)); //Create new property

        }
    }
}
