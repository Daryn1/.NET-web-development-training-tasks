// <copyright file="ThirdTask.cs" company="MyCompany.com">
// Contains the solutions to tasks of the 'Methods in detail' module.
// </copyright>
// <author>Daryn Akhmetov</author>

namespace Methods_in_detail
{
    /// <summary>
    /// Contains implementation of the given by the task algorithm.
    /// </summary>
    public static class ThirdTask
    {
        /// <summary>
        /// Gets a value indicating whether a given null-able variable is equal to null.
        /// </summary>
        /// <param name="nullableVariable">Variable of null-able type.</param>
        /// <returns>true if a given null-able variable is equal to null; otherwise false.</returns>
        public static bool IsNull(this object nullableVariable)
        {
            return nullableVariable == null;
        }
    }
}