using Microsoft.VisualStudio.TestTools.UnitTesting;
using Switchboard.Mapping;
using Switchboard.Profiles;
using SwitchboardMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace SwitchboardMapperTests.UnitTests
{
    [TestClass]
    public class CreateObjectUnitTests
    {
        [TestMethod]
        public void CreateObject_MapObjectToObject_Success()
        {

            var map = Map.Create("FooProfile", "BarProfile",
                MapItem.Create("Id", "Id", "Id"),
                MapItem.Create("Name", "FooName", "BarName"));

            var fooProfile = Profile.Create("FooProfile",
                ProfileProperty.Create("Id"),
                ProfileProperty.Create("FooName"));

            var barProfile = Profile.Create("BarProfile",
                ProfileProperty.Create("Id"),
                ProfileProperty.Create("BarName"));


            var client = MapperClient.Create(fooProfile, barProfile);

            var foo = new Foo()
            {
                Id = 1,
                FooName = "Hello World!"
            };

            var bar = new Bar();


            bar = client.Map(foo, bar, map);

            Assert.AreEqual(foo.Id, bar.Id);
            Assert.AreEqual(foo.FooName, bar.BarName);

        }

        [TestMethod]
        public void CreateObject_MapChildToObject_Success()
        {
            var foo = new Foo();

            foo.Child.FooChildName = "Hello World!";

            var bar = new Bar();


            var map = Map.Create("FooProfile", "BarProfile",
             MapItem.Create("Name", "Child.FooChildName", "BarName"));

            var fooProfile = Profile.Create("FooProfile",
                ProfileProperty.Create("Child.FooChildName"));

            var barProfile = Profile.Create("BarProfile",
                ProfileProperty.Create("BarName"));

            var client = MapperClient.Create(fooProfile, barProfile);

            bar = client.Map(foo, bar, map);

            Assert.AreEqual(foo.Child.FooChildName, bar.BarName);
        }

        [TestMethod]
        public void CreateObject_MapObjectToChild_Success()
        {
            var foo = new Foo();

            foo.FooName = "Hello World!";

            var bar = new Bar();

            var map = Map.Create("FooProfile", "BarProfile",
            MapItem.Create("Name", "FooName", "Child.BarChildName"));

            var fooProfile = Profile.Create("FooProfile",
                ProfileProperty.Create("FooName"));

            var barProfile = Profile.Create("BarProfile",
                ProfileProperty.Create("Child.BarChildName"));

            var client = MapperClient.Create(fooProfile, barProfile);

            bar = client.Map(foo, bar, map);

            Assert.AreEqual(foo.FooName, bar.Child.BarChildName);
        }

        [TestMethod]
        public void CreateObject_MapChildToChild_Success()
        {
            var foo = new Foo();

            foo.Child.FooChildName = "Hello World!";

            var bar = new Bar();

            var map = Map.Create("FooProfile", "BarProfile",
                    MapItem.Create("Name", "Child.FooChildName", "Child.BarChildName"));

            var fooProfile = Profile.Create("FooProfile",
                ProfileProperty.Create("Child.FooChildName"));

            var barProfile = Profile.Create("BarProfile",
                ProfileProperty.Create("Child.BarChildName"));

            var client = MapperClient.Create(fooProfile, barProfile);

            bar = client.Map(foo, bar, map);

            Assert.AreEqual(foo.Child.FooChildName, bar.Child.BarChildName);
        }

        [TestMethod]
        public void CreateObject_MapFullObjectToFullObject_Success()
        {
            var foo = new Foo();

           
            foo.FooName = "Hello World!";
            foo.Id = 1;
            foo.Child.FooChildName = "Foo Child";

            var bar = new Bar();

            var map = Map.Create("FooProfile", "BarProfile",
                    "Id Id Id",
                    "Name FooName BarName",
                    "ChildName Child.FooChildName Child.BarChildName");

            var client = MapperClient.Create("FooProfile:Id FooName Child.FooChildName",
                "BarProfile:Id BarName Child.BarChildName");

            bar = client.Map(foo, bar, map);

            Assert.AreEqual(foo.Id, bar.Id);
            Assert.AreEqual(foo.FooName, bar.BarName);
            Assert.AreEqual(foo.Child.FooChildName, bar.Child.BarChildName);
        }
    }
}
