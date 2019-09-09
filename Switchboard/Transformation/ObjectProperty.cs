using Switchboard.Profiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Switchboard.Transformation
{
    public class ObjectProperty : IObjectProperty
    {
        private IProfileProperty from { get; set; }
        private IProfileProperty to { get; set; }
        private object value { get; set; }


        public IProfileProperty From { get { return from; } }
        public IProfileProperty To { get { return to; } }
        public object Value { get { return value; } }


        public ObjectProperty()
        {

        }

        public static IObjectProperty Create(IProfileProperty from, IProfileProperty to, object value)
        {
            var prop = new ObjectProperty();

            prop.from = from;
            prop.to = to;
            prop.value = value;

            return prop;
        }

        public T GetValue<T>()
        {
            if (value is T)
            {
                return (T)value;
            }
            try
            {
                return (T)Convert.ChangeType(value, typeof(T));
            }
            catch (InvalidCastException)
            {
                return default(T);
            }
        }


    }
}
