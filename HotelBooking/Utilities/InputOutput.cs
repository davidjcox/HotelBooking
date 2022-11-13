using System;
using System.IO;


namespace HotelBooking.Utilities
{
    internal static class InputOutput
    {
        /// <summary>
        /// Gets the project file path relative to the project deployment filesystem location.
        /// </summary>
        /// <returns>full project path as string</returns>
        internal static string GetProjectPath()
        {
            DirectoryInfo projectPath = null;

            try
            {
                projectPath = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.Parent;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            return projectPath.FullName;
        }

        /// <summary>
        /// Gets the project test report file path relative to the project location.
        /// </summary>
        /// <returns>full test report path as string</returns>
        internal static string GetTestReportPath()
        {
            string[] testReportPathSegments = new string[] { GetProjectPath(), @"TestReports" };
            string testReportPath = string.Empty;

            try
            {
                testReportPath = CombineSegmentsToPath(testReportPathSegments);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            return testReportPath;
        }

        /// <summary>
        /// Gets the test test report name to be used for the test report.
        /// </summary>
        /// <returns>test report name as string</returns>
        internal static string GetTestReportName()
        {
            string todaysDate = DateTime.Now.ToFormattedString();
            string currentTestReportName = $"{todaysDate}_HotelBooking.html";
            string[] testReportNameSegments = new string[] { GetTestReportPath(), currentTestReportName };
            string testReportName = string.Empty;

            try
            {
                testReportName = CombineSegmentsToPath(testReportNameSegments);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            return testReportName;
        }

        /// <summary>
        /// Combines the passed file path segments into one full file path.
        /// </summary>
        /// <param name="segments"></param>
        /// <returns>combined file path as string</returns>
        internal static string CombineSegmentsToPath(string[] segments)
        {
            string path = string.Empty;

            try
            {
                path = Path.Combine(segments);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            return path;
        }
    }
}
