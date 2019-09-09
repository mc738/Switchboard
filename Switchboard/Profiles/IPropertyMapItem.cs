namespace Switchboard.Profiles
{
    public interface IPropertyMapItem
    {
        IProfileProperty From { get; }
        string Name { get; }
        IProfileProperty To { get; }
    }
}