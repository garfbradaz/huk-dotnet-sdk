using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Hachette.API.SDK.Interfaces;
using Hachette.API.SDK.Extensions;
using Hachette.API.SDK.Validation;

namespace Hachette.API.SDK.Common
{
    /// <summary>
    /// Common Paremeters used in Hachette APIs.
    /// </summary>
    public class CommonParameters : IHachetteCommonParameters
    {
        private static Imprints imprintValidator = Imprints.Create();
        /// <summary>
        /// Default ctor
        /// </summary>
        public CommonParameters()
        {
            Limit = 10;
        }
        private HashSet<string> filterByImprints = new HashSet<string>();

        /// <summary>
        /// Exposed the FilterByImprints object that will be sent (if not empty), 
        /// in the filterByImprints parameter.
        /// </summary>
        public ReadOnlyCollection<string> FilterByImprints { get { return filterByImprints.AsReadOnly();}}
        
        private HashSet<string> filterByDivisions = new HashSet<string>();
        /// <summary>
        /// Exposed the FilterByDivisions object that will be sent (if not empty), 
        /// in the filterByDivisions parameter.
        /// </summary>
        public ReadOnlyCollection<string> FilterByDivisions { get {return filterByDivisions.AsReadOnly();}}
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
        /// <returns>
        /// boolean: If the addition was successful or not.
        /// <see cref="ValidationAddStatus"/> : Determines why the operation failed.false
        /// </returns>
        public (bool,ValidationAddStatus) AddDivision(string division)
        {
            if(string.IsNullOrEmpty(division))
                return (false,ValidationAddStatus.FailedEmptyValue);
            
            var validated = Divisions.OneOf(division);
            if(!validated)
                return (false,ValidationAddStatus.FailedValueUnknown);
            
            var added = this.filterByDivisions.Add(division);
            if(!added)
                return (false,ValidationAddStatus.FailedDuplicateValue);
            
            return (true, ValidationAddStatus.Success);
            
        }

        /// <summary>
        /// Add a imprint to be be included in filterByImprints parameter.
        /// </summary>
        /// <param name="imprint"></param>
        /// <returns>
        /// boolean: If the addition was successful or not.
        /// <see cref="ValidationAddStatus"/> : Determines why the operation failed.false
        /// </returns>
        public (bool,ValidationAddStatus) AddImprint(string imprint)
        {
            if(string.IsNullOrEmpty(imprint))
                return (false,ValidationAddStatus.FailedEmptyValue);
            
            var validated = Imprints.OneOf(imprint);
            if(!validated)
                return (false,ValidationAddStatus.FailedValueUnknown);
            
            var added = this.filterByImprints.Add(imprint);
            if(!added)
                return (false,ValidationAddStatus.FailedDuplicateValue);
            
            return (true, ValidationAddStatus.Success);
        }

        /// <summary>
        /// Remove a division from being sent in the filterByDivisions parameter.
        /// </summary>
        /// <param name="division"></param>
        public void RemoveDivision(string division)
        {
            if(string.IsNullOrEmpty(division))
                return;
            
            this.filterByDivisions.Remove(division);
        }

        /// <summary>
        /// Remove a imprint from being sent in the filterByImprints parameter.
        /// </summary>
        /// <param name="imprint"></param>
        public void RemoveImprint(string imprint)
        {
            if(string.IsNullOrEmpty(imprint))
                return;
            
            this.filterByImprints.Remove(imprint);
        }
    }
}