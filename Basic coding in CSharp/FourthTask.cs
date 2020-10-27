// <copyright file="FourthTask.cs" company="MyCompany.com">
// Contains the solutions to tasks of the 'Basic Coding in C#' module.
// </copyright>
// <author>Daryn Akhmetov</author>

namespace Basic_coding_in_CSharp
{
    using System.Linq;

    /// <summary>
    /// Contains implementation of the given by the task algorithm.
    /// </summary>
    public class FourthTask
    {
        /// <summary>
        /// Concatenates two strings, excluding duplicate characters.
        /// </summary>
        /// <param name="latinAlphabetString1">The first string that include only characters from 'a' to 'z'</param>
        /// <param name="latinAlphabetString2">The second string that include only characters from 'a' to 'z'</param>
        /// <returns>A concatenated string, excluding duplicate characters.</returns>
        public static string ConcatenateExcludingDuplicateCharacters(string latinAlphabetString1, string latinAlphabetString2)
        {
            return latinAlphabetString2.Where(character => !latinAlphabetString1.Contains(character))
                .Aggregate(latinAlphabetString1, (current, character) => current + character);
        }
    }
}