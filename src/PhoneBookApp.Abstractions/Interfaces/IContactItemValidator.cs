namespace PhoneBookApp.Abstractions
{
    /// <summary>
    /// Contact Item Validator
    /// </summary>
    public interface IContactItemValidator
    {
        /// <summary>
        /// Validated whether IContactItem has been completed (filled in)
        /// </summary>
        /// <param name="contactItem">IContactItem to validate</param>
        /// <returns>Whether the IContactItem is completed</returns>
        bool ContactItemIsComplete(IContactItem contactItem);

        /// <summary>
        /// Validates whether IContactItem has changed compared to initial value
        /// </summary>
        /// <param name="originalItem">Original IContactItem (Point of reference)</param>
        /// <param name="comparisonItem">Comparison IContactItem (Point of comparison)</param>
        /// <returns>Whether the IContactItem has changed</returns>
        bool ContactItemHasChanged(IContactItem originalItem, IContactItem comparisonItem);
    }
}
