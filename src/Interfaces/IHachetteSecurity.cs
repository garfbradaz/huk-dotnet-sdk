namespace Hachette.API.SDK.Interfaces
{
    /// <summary>
    /// Security credentials needed to work with Hachetet API's.
    /// </summary>
    public interface IHachetteSecurity
    {
        /// <summary>
        /// These Developer strings are provided by Hachette UK.
        /// </summary>
        /// <value></value>
        string DeveloperKey {get;}
    }
}