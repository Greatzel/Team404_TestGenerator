//// ********************************************************************************
//// Created by:    Jim Wood 
//// Date created:  02/12/2015
//// Reason:
////     ULTI-162179 Jarvis: API for integration testing.
//// ********************************************************************************

using System;
using System.IO;
using Newtonsoft.Json;

namespace Generator.Helpers
{
    /// <summary>
    /// Provides the integration tests with APIs to manage templates (a.k.a. interfaces).
    /// </summary>
    public class FileHelper
    {
        public static string PathTestGenerator = "\\\\denver2\\groups\\Cognuts\\Testing\\Specifications";

        /// <summary>
        /// Returns the contents of the specified interface.
        /// </summary>
        public static string ContentsAsString(string pathName, string specificationName)
        {
            string specificationFile = $"{pathName}\\{specificationName}.xml";
            string filenameWithPath = $"{PathTestGenerator}\\{specificationFile}";
            return FileHelper.ContentsAsString(filenameWithPath);
        }

        /// <summary>
        /// Returns the contents of a file as a string.
        /// </summary>
        public static string ContentsAsString(string filenameWithPath)
        {
            using (StreamReader reader = new StreamReader(filenameWithPath))
            {
                return reader.ReadToEnd();
            }
        }

        public static bool WriteAsJson(string filenameWithPath, object objectToWrite)
        {
            string objectAsJson = JsonConvert.SerializeObject(objectToWrite, Formatting.Indented);
            using (StreamWriter writer = new StreamWriter(filenameWithPath))
            {
                writer.WriteLine(objectAsJson);
            }

            return true;
        }
    }
}
