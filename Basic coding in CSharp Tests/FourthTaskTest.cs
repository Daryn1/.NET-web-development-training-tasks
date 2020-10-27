// <copyright file="FourthTaskTest.cs" company="MyCompany.com">
// Contains the solutions to tasks of the 'Basic Coding in C#' module.
// </copyright>
// <author>Daryn Akhmetov</author>

namespace Basic_coding_in_CSharp_Tests
{
    using System;
    using Basic_coding_in_CSharp;
    using NUnit.Framework;

    /// <summary>
    /// This is a test class for FourthTask and is intended
    /// to contain all FourthTask Unit Tests.
    /// </summary>
    [TestFixture]
    public class FourthTaskTest
    {
        /// <summary>
        /// A test for ConcatenateExcludingDuplicateCharacters.
        /// </summary>
        /// <param name="latinAlphabetString1">The first string that include only characters from 'a' to 'z'</param>
        /// <param name="latinAlphabetString2">The second string that include only characters from 'a' to 'z'</param>
        /// <returns>A concatenated string, excluding duplicate characters.</returns>
        [TestCase("AsdfeAd", "Assqaasssqs", ExpectedResult = "AsdfeAdqaaq")]
        public string ConcatenateExcludingDuplicateCharactersTest(string latinAlphabetString1, string latinAlphabetString2)
        {
            return FourthTask.ConcatenateExcludingDuplicateCharacters(latinAlphabetString1, latinAlphabetString2);
        }
    }
}