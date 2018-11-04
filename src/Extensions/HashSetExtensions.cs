using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Hachette.API.SDK.Extensions
{
    /// <summary>
    /// Simple extension methods for HashSet.
    /// </summary>
    public static class HashSetExtensions
    {
        /// <summary>
        /// Copies a HashSet to a ReadOnlyCollection
        /// </summary>
        /// <param name="hash"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns>ReadOnlyCollection<T></returns>
        public static ReadOnlyCollection<T> AsReadOnly<T>(this HashSet<T> hash) => new ReadOnlyCollection<T>(hash.ToList());
    }
}