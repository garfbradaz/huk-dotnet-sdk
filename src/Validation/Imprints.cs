using System.Linq;

namespace Hachette.API.SDK.Validation
{
    /// <summary>
    /// Validation object for Imprint Names to be used 
    /// when passing to filterByImprints.
    /// </summary>
    public sealed class Imprints
    {
        private readonly string wAndN;
        /// <summary>
        /// W&N Imprint Name.
        /// </summary>
        public string WAndN => wAndN;
        private readonly string gollancz;
        /// <summary>
        /// Gollancz Imprint Name.
        /// </summary>
        public string Gollancz => gollancz;
        private readonly string sciFiGateway;
        /// <summary>
        /// SciFi Gateway Imprint Name.
        /// </summary>
        public string SciFiGateway => sciFiGateway;

        /// <summary>
        /// Private ctor.
        /// </summary>
        private Imprints ()
        {
            this.wAndN = "wandn,w&n";
            this.gollancz = "gollancz";
            this.sciFiGateway = "gateway";
        }

        /// <summary>
        /// Singleton instance.
        /// </summary>
        /// <returns>Thread safe instance.</returns>
        private static readonly Imprints threadSafeSingleton = new Imprints();
        
        /// <summary>
        /// Simple Factory method to create a Imprints object.
        /// </summary>
        /// <returns>Imprints</returns>     
        public static Imprints Create()
        {
            return threadSafeSingleton ?? new Imprints();
        }

        /// <summary>
        /// Validation routine to check if a Imprint Name is valid.
        /// </summary>
        /// <param name="imprintName"></param>
        /// <returns></returns>
        public static bool OneOf(string imprintName)
        {
            if(string.IsNullOrEmpty(imprintName))
                return false;
            if(threadSafeSingleton.wAndN.ToLower().Split(',').Contains(imprintName.ToLower()))
            {
                return true;
            }else if(threadSafeSingleton.gollancz.ToLower().Split(',').Contains(imprintName.ToLower()))
            {
                return true;
            }else if(threadSafeSingleton.sciFiGateway.ToLower().Split(',').Contains(imprintName.ToLower()))
            {
                return true;
            }
            return false;
        }
    }
}