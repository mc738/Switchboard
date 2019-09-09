using Switchboard.Profiles;

namespace Switchboard.Transformation
{
    public interface IObjectProperty
    {
        IProfileProperty From { get; }
        IProfileProperty To { get; }
        object Value { get; }

        T GetValue<T>();
    }
}