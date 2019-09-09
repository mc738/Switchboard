using System;
using System.Collections.Generic;
using System.Text;

namespace Switchboard.Profiles
{
    public class Input : IInput
    {
        private string mapName { get; set; }
        private object value { get; set; }

        public string MapName { get { return mapName; } }
        public object Value { get { return value; } }

        private Input()
        {

        }

        public static Input Create(string mapName, object value)
        {
            var input = new Input();

            input.mapName = mapName;
            input.value = value;

            return input;
        }
    }
}
