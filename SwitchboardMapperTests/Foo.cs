using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchboardMapperTests
{
    public class Foo
    {
        public int Id { get; set; }
        public string FooName { get; set; }
        public FooChild Child { get; set; }

        public Foo()
        {
            Child = new FooChild();
        }
    }
}
