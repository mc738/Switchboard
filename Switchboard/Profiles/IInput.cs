namespace Switchboard.Profiles
{
    public interface IInput
    {
        string MapName { get; }
        object Value { get; }
    }
}