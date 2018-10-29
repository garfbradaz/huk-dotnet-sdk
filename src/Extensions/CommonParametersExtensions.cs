using System;
using System.Collections.ObjectModel;
using Hachette.API.SDK.Interfaces;

namespace Hachette.API.SDK.Extensions
{
    /// <summary>
    /// Extension Utility Methods for <see cref="IHachetteCommonParameters.cs" />
    /// </summary>
    public static class CommonParametersExtensions
    {
        private static string divisionQueryName = "filterByDivisions";
        private static string imprintQueryName = "filterByImprints";
        /// <summary>
        /// Utility method to build the Query String for a Common Parameters.
        /// </summary>
        /// <param name="queryStringParameters"></param>
        /// <returns>Query String</returns>
        public static string BuildQueryString(this IHachetteCommonParameters queryStringParameters)
        {
            string queryString = string.Empty;
            bool firstQueryBuilt = false;

            BuildFromReadonOnlyCollection(queryStringParameters.FilterByDivisions,
                                          ref queryString, 
                                          ref firstQueryBuilt,
                                          ref divisionQueryName);

            BuildFromReadonOnlyCollection(queryStringParameters.FilterByImprints, 
                                          ref queryString, 
                                          ref firstQueryBuilt,
                                          ref imprintQueryName);

            BuildFromDateTimeOffset(queryStringParameters.FilterByTimestamp, 
                                          ref queryString, 
                                          ref firstQueryBuilt,
                                          nameof(queryStringParameters.FilterByTimestamp));
            return queryString;
        }

        /// <summary>
        /// Build Query String parts from values held in <see cref="ReadOnlyCollection" />
        /// </summary>
        /// <param name="collection"></param>
        /// <param name="queryString"></param>
        /// <param name="firstQueryBuilt"></param>
        /// <param name="queryName"></param>
        private static void BuildFromReadonOnlyCollection(ReadOnlyCollection<string> collection,
                                                          ref string queryString, 
                                                          ref bool firstQueryBuilt,
                                                          ref string queryName)
        {
            if (collection.Count > 0)
            {
                foreach (string item in collection)
                {
                    if (!firstQueryBuilt)
                    {
                        queryString = $"?{queryName}={item}";
                        firstQueryBuilt = true;
                    }
                    else
                    {
                        queryString = queryString + $"&{queryName}={item}";
                    }
                }
            }
        }
        
        /// <summary>
        /// Build Query String from <see cref="DateTimeOffset" />
        /// </summary>
        /// <param name="date"></param>
        /// <param name="queryString"></param>
        /// <param name="firstQueryBuilt"></param>
        /// <param name="queryName"></param>
        private static void BuildFromDateTimeOffset(DateTimeOffset date,
                                        ref string queryString, 
                                        ref bool firstQueryBuilt,
                                        string queryName)
        {
            if(queryName == null)
            {
                throw new ArgumentNullException(nameof(queryName));
            }

            queryName = Char.ToLowerInvariant(queryName[0]) + queryName.Substring(1);

            if (date != null)
            {
                if (!firstQueryBuilt)
                {
                    //TODO:: Need to do Type Checking for ToString() DateTimeOffset format.
                    queryString = $"?{queryName}={date.ToString("o")}";
                    firstQueryBuilt = true;
                }
                else
                {
                    queryString = queryString + $"&{queryName}={date.ToString("o")}";
                }
            }
        }
        /// <summary>
        /// Build Query String from Nullable <see cref="DateTimeOffset" />
        /// </summary>
        /// <param name="date"></param>
        /// <param name="queryString"></param>
        /// <param name="firstQueryBuilt"></param>
        /// <param name="queryName"></param>
        private static void BuildFromDateTimeOffset(DateTimeOffset? date,
                                        ref string queryString, 
                                        ref bool firstQueryBuilt,
                                        string queryName)
        {
            if(queryName == null)
            {
                throw new ArgumentNullException(nameof(queryName));
            }

            queryName = Char.ToLowerInvariant(queryName[0]) + queryName.Substring(1);

            if (date != null)
            {
                if (!firstQueryBuilt)
                {
                    //TODO:: Need to do Type Checking for ToString() DateTimeOffset format.
                    queryString = $"?{queryName}={date.GetValueOrDefault().ToString("o")}";
                    firstQueryBuilt = true;
                }
                else
                {
                    queryString = queryString + $"&{queryName}={date.GetValueOrDefault().ToString("o")}";
                }
            }
        }
        /// <summary>
        /// Generic Query String Builder.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="queryString"></param>
        /// <param name="firstQueryBuilt"></param>
        /// <param name="queryName"></param>
        /// <typeparam name="T"></typeparam>
        private static void GenericBuild<T>(T obj,
                                        ref string queryString, 
                                        ref bool firstQueryBuilt,
                                        string queryName)
        {
            if(queryName == null)
            {
                throw new ArgumentNullException(nameof(queryName));
            }

            queryName = Char.ToLowerInvariant(queryName[0]) + queryName.Substring(1);

            if (obj != null)
            {
                if (!firstQueryBuilt)
                {
                    //TODO:: Need to do Type Checking for ToString() DateTimeOffset format.
                    queryString = $"?{queryName}={obj.ToString()}";
                    firstQueryBuilt = true;
                }
                else
                {
                    queryString = queryString + $"&{queryName}={obj.ToString()}";
                }
            }
        }
    }
}