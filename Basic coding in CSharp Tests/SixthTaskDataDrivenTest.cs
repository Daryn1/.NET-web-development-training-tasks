// <copyright file="SixthTaskDataDrivenTest.cs" company="MyCompany.com">
// Contains the solutions to tasks of the 'Basic Coding in C#' module.
// </copyright>
// <author>Daryn Akhmetov</author>

namespace Basic_coding_in_CSharp_Tests
{
    using System;
    using System.Collections.Generic;
    using System.Data.OleDb;
    using System.IO;
    using System.Linq;
    using Basic_coding_in_CSharp;
    using NUnit.Framework;

    /// <summary>
    /// This is a test class for SixthTask and is intended
    /// to contain all SixthTask Unit Tests.
    /// </summary>
    [TestFixture]
    public class SixthTaskDataDrivenTest
    {
        /// <summary>
        /// A test for FilterDigit with correct input.
        /// </summary>
        /// <param name="inputArray">Input array of integers.</param>
        /// <param name="digitForFiltering">Digit used for filtering.</param>
        /// <param name="expectedResult">The expected result that method returns.</param>
        [Test, TestCaseSource(typeof(ExcelDataParser), nameof(ExcelDataParser.TestData)), Category("1")]
        public void FilterDigitTest(int[] inputArray, int digitForFiltering, int[] expectedResult)
        {
            // Run the method under test.
            int[] actualResult = SixthTask.FilterDigit(inputArray, digitForFiltering);

            // Verify the result.
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        /// <summary>
        /// This class reads the excel file by calling the method readExcelData() from the class ExcelReader. Taken from here:
        /// https://stackoverflow.com/questions/44260816/c-sharp-nunit-3-data-driven-from-excel
        /// </summary>
        private class ExcelDataParser
        {
            /// <summary>
            /// Path to the assembly.
            /// </summary>
            private static string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;

            /// <summary>
            /// Path to the excel files.
            /// </summary>
            private static string excelPath = new Uri(path.Substring(0, path.LastIndexOf("bin"))).LocalPath;

            /// <summary>
            /// Gets the data from excel file.
            /// </summary>
            public static IEnumerable<TestCaseData> TestData
            {
                get
                {
                    List<TestCaseData> testCaseDataList = new ExcelReader().ReadExcelData(excelPath + "TestData.xlsx");

                    if (testCaseDataList != null)
                    {
                        foreach (TestCaseData testCaseData in testCaseDataList)
                        {
                            yield return testCaseData;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Contains the method ReadExcelData that converts every row from the excel file to a TestCaseData. Taken from here:
        /// https://stackoverflow.com/questions/44260816/c-sharp-nunit-3-data-driven-from-excel
        /// </summary>
        private class ExcelReader
        {
            /// <summary>
            /// Reads data from Excel file.
            /// </summary>
            /// <param name="excelFile">Excel filename.</param>
            /// <param name="cmdText">Should be "SELECT * FROM [NameOfSheet$]".</param>
            /// <returns>List of TestCaseData.</returns>
            public List<TestCaseData> ReadExcelData(string excelFile, string cmdText = "SELECT * FROM [Dataset$]")
            {
                if (!File.Exists(excelFile))
                {
                    throw new Exception($"File name: {excelFile}", new FileNotFoundException());
                }

                var connectionStr = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={excelFile};Extended Properties=\"Excel 12.0 Xml;HDR=YES\";";
                var ret = new List<TestCaseData>();
                using (var connection = new OleDbConnection(connectionStr))
                {
                    connection.Open();
                    var command = new OleDbCommand(cmdText, connection);
                    var reader = command.ExecuteReader();

                    if (reader == null)
                    {
                        throw new Exception($"No data return from file, file name:{excelFile}");
                    }

                    while (reader.Read())
                    {
                        var fieldCount = reader.FieldCount;

                        if (reader.GetValue(0).ToString() == string.Empty)
                        {
                            break;
                        }

                        var inputArrayAsString = reader.GetValue(0).ToString().Split(", ");
                        var digitForFiltering = int.Parse(reader.GetValue(1).ToString());
                        var expectedResultAsString = reader.GetValue(2).ToString().Split(", ");

                        var inputArray = inputArrayAsString.Select(int.Parse).ToArray();
                        var expectedResult = expectedResultAsString.Select(int.Parse).ToArray();

                        ret.Add(new TestCaseData(inputArray, digitForFiltering, expectedResult));
                    }
                }
                
                return ret;
            }
        }
    }
}
