using Switchboard;
using Switchboard.Profiles;
using Switchboard.Transformation;
using SwitchboardMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchboardMapperTests
{
    public class TestClient : MapperClient
    {
        private Foo foo { get; set; }
        private Bar bar { get; set; }

        public TestClient() : base()
        {

        }
       
    }
}
