namespace Hachette.API.SDK.Common
{
    /// <summary>
    /// Status of adding a record to a collection.
    /// </summary>
    public enum ValidationAddStatus
    {
        Success,
        FailedDuplicateValue,
        FailedValueUnknown,
        FailedEmptyValue
    }
}