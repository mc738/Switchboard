using Switchboard;
using Switchboard.Mapping;
using Switchboard.Profiles;
using Switchboard.Transformation;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace SwitchboardMapper
{
    public class MapperClient : Client
    {
        private object input { get; set; }
        private object output { get; set; }
        private bool straightThrought { get; set; }




        public MapperClient() : base()
        {

        }

        /// <summary>
        /// Create from a list of mapped strings. 
        /// Syntax: '[]:Id FooName Child.FooChildName'
        /// </summary>
        /// <param name="mappingStrings"></param>
        /// <returns></returns>
        public static MapperClient Create(params string[] mappingStrings)
        {
            
            var client = new MapperClient();

            foreach (var item in mappingStrings)
            {

                var splitItem = item.Split(':');

                var props = new List<ProfileProperty>();

                foreach (var propStr in splitItem[1].Split(' '))
                {
                    props.Add(ProfileProperty.Create(propStr));
                }
                          
                var profile = Profile.Create(splitItem[0],
                    props.ToArray());

                client.AddProfile(profile);
            }

            return client;
        }

        public static MapperClient Create(params IProfile[] profiles)
        {
            var client = new MapperClient();

            foreach (var profile in profiles)
            {
                client.AddProfile(profile);
            }

            return client;
        }

        public T2 Map<T1, T2>(T1 from, T2 to, Map map)
        {
            //Set input and output
            input = from;
            output = to;

            ProcessObject(map);

            //Update from output
            to = (T2)output;

            //Clear up input and output
            input = null;
            output = null;

            return to;
        }

        protected override IEnumerable<IInput> GetData(Map map)
        {
            //create 
            var inputs = new List<IInput>();

            var type = input.GetType();

            foreach (var item in map.Items)
            {
                var name = item.From;

                var value = new object();

                GetValue(input, item.From, out value);

                inputs.Add(Input.Create(item.Name, value));

            }

            return inputs;
        }

        private bool GetValue(object currentObject, string pathName, out object fieldValue)
        {
            string[] fieldNames = pathName.Split('.');

            foreach (string fieldName in fieldNames)
            {
                // Get type of current record 
                Type curentRecordType = currentObject.GetType();
                PropertyInfo property = curentRecordType.GetProperty(fieldName);

                if (property != null)
                {
                    currentObject = property.GetValue(currentObject, null);
                }
                else
                {
                    fieldValue = null;
                    return false;
                }
            }
            fieldValue = currentObject;
            return true;
        }

        private bool GetProp(object currentObject, string pathName, out PropertyInfo propInfo, out object lastObject)
        {
            string[] fieldNames = pathName.Split('.');

            propInfo = currentObject.GetType().GetProperty(fieldNames[0]);
            lastObject = currentObject;

            foreach (string fieldName in fieldNames)
            {

                // Get type of current record 
                Type curentRecordType = currentObject.GetType();
                PropertyInfo property = curentRecordType.GetProperty(fieldName);

                if (property != null)
                {
                    lastObject = currentObject;
                    currentObject = property.GetValue(currentObject, null);
                    propInfo = property;
                }
                else
                {
                    propInfo = null;
                    return false;
                }
            }

            return true;
        }

        protected override bool SendData(IIntermediateObject obj)
        {
            var type = output.GetType();

            //Set the values from the from object
            foreach (var item in obj.Properties)
            {
                var prop = type.GetProperty(item.To.Name);
                var o = new object();

                GetProp(output, item.To.Name, out prop, out o);

                var value = item.Value;

                prop.SetValue(o, value, null);          
            }

            return true;
        }
    }
}
