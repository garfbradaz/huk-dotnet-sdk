using System.Linq;

namespace Hachette.API.SDK.Validation
{
    /// <summary>
    /// Validation object for Division Names to be used 
    /// when passing to filterByImprints.
    /// </summary>
    public sealed class Divisions
    {
        private readonly string orion;
        /// <summary>
        /// Orion division.
        /// </summary>
        public string Orion => orion;

        private readonly string octopus;
        /// <summary>
        /// Orion division.
        /// </summary>
        public string Octopus  => octopus;


        /// <summary>
        /// Private ctor.
        /// </summary>
        private Divisions ()
        {
            this.orion = "Orion Publishing Group";
            this.octopus = "Octopus Publishing Group";
        }

        /// <summary>
        /// Singleton instance.
        /// </summary>
        /// <returns>Thread safe instance.</returns>
        private static readonly Divisions threadSafeSingleton = new Divisions();
        
        /// <summary>
        /// Simple Factory method to create a Imprints object.
        /// </summary>
        /// <returns>Imprints</returns>     
        public static Divisions Create()
        {
            return threadSafeSingleton ?? new Divisions();
        }

        /// <summary>
        /// Validation routine to check if a Imprint Name is valid.
        /// </summary>
        /// <param name="imprintName"></param>
        /// <returns></returns>
        public static bool OneOf(string divisionName)
        {
            if(string.IsNullOrEmpty(divisionName))
                return false;
            if(threadSafeSingleton.orion.ToLower().Split(',').Contains(divisionName.ToLower()))
            {
                return true;
            } else if(threadSafeSingleton.octopus.ToLower().Split(',').Contains(divisionName.ToLower()))
            {
                return true;
            }
            return false;
        }
    }
}