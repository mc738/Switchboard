using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchboardMapperTests
{
    public class Bar
    {
        public int Id { get; set; }
        public string BarName { get; set; }
        public BarChild Child { get; set; }

        public Bar()
        {
            Child = new BarChild();
        }
    }
}
