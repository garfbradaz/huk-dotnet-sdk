using System;
using System.Collections.Generic;
using Hachette.API.SDK.Interfaces;

namespace Hachette.API.SDK.Common
{
    /// <summary>
    /// Common Paremeters used in Hachette APIs.
    /// </summary>
    public class CommonParameters : IHachetteCommonParameters
    {
        /// <summary>
        /// Default ctor
        /// </summary>
        public CommonParameters()
        {
            Limit = 10;
            FilterByDivisions = new HashSet<string>();
            FilterByImprints = new HashSet<string>();
        }
        
        /// <summary>
        /// Exposed the FilterByImprints object that will be sent (if not empty), 
        /// in the filterByImprints parameter.
        /// </summary>
        public HashSet<string> FilterByImprints { get ; private set;}
        /// <summary>
        /// Exposed the FilterByDivisions object that will be sent (if not empty), 
        /// in the filterByDivisions parameter.
        /// </summary>
        public HashSet<string> FilterByDivisions { get ; private set; }
        /// <summary>
        /// Filter by Date since the resource was last updated.
        /// </summary>
        public DateTimeOffset? FilterByTimestamp { get ; set ; }
        /// <summary>
        /// Gets InActive or Active records.
        /// </summary>
        public bool? FilterByIsActive { get ; set ; }
        /// <summary>
        /// Set a limit of how many records are returned.
        /// </summary>
        public int? Limit { get ; set ; }
        /// <summary>
        /// If Paging a large record set, pass in the Page number on where for the Hachette API
        /// to continue from (or start if the beginning of the query).
        /// </summary>
        public int? Page { get ; set ; }

        /// <summary>
        /// Add a division to be be included in filterByDivisions parameter.
        /// </summary>
        /// <param name="division"></param>
        public void AddDivision(string division)
        {
            if(string.IsNullOrEmpty(division))
                return;
            
            this.FilterByDivisions.Add(division);
        }

        /// <summary>
        /// Add a imprint to be be included in filterByImprints parameter.
        /// </summary>
        /// <param name="imprint"></param>
        public void AddImprint(string imprint)
        {
            if(string.IsNullOrEmpty(imprint))
                return;
            
            this.FilterByDivisions.Add(imprint);
        }

        /// <summary>
        /// Remove a division from being sent in the filterByDivisions parameter.
        /// </summary>
        /// <param name="division"></param>
        public void RemoveDivision(string division)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Remove a imprint from being sent in the filterByImprints parameter.
        /// </summary>
        /// <param name="imprint"></param>
        public void RemoveImprint(string imprint)
        {
            throw new NotImplementedException();
        }
    }
}