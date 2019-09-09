using System.Collections.Generic;
using Switchboard.Profiles;

namespace Switchboard.Transformation
{
    public interface IIntermediateObject
    {
        IEnumerable<IIntermediateObject> Children { get; }
        IEnumerable<IObjectProperty> Properties { get; }
        IEnumerable<IPropertyMapItem> PropertyMap { get; }

        void GenerateProperties(params IInput[] inputs);
        void GenerateProperty(IInput input);
    }
}