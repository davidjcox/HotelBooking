using System;
using Microsoft.Extensions.Configuration;


namespace HotelBooking.Utilities
{
    internal static class ProjectConfiguration
    {
        /// <summary>
        /// Reads project configuration strings from the project appconfig.xml file.
        /// </summary>
        /// <returns>configuration</returns>
        internal static IConfigurationRoot GetProjectConfiguration()
        {
            IConfigurationRoot configuration = null;

            try
            {
                configuration = new ConfigurationBuilder()
                .SetBasePath(InputOutput.GetProjectPath())
                .AddXmlFile("appconfig.xml", optional: false, reloadOnChange: false)
                .Build();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }

            return configuration;
        }
    }
}
