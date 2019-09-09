using System.Collections.Generic;

namespace Switchboard.Profiles
{
    public interface IProfile
    {
        IEnumerable<IProfile> Children { get; }
        string Name { get; }
        IEnumerable<IProfileProperty> Properties { get; }

        void AddChild(IProfile child);
        void AddProperty(IProfileProperty prop);
        IProfileProperty GetProperty(string name);
        IProfile GetChild(string name);

    }
}