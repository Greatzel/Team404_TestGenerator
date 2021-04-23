using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace GGC.TestCaseGenerator.Helpers
{
    /// <summary>
    /// Provides the integration tests with APIs to manage templates (a.k.a. interfaces).
    /// </summary>
    public class FileHelper
    {
        public static string PathTestGenerator = @"C:\Users\rober\Documents\Software Development 2\git\GGC.TestCaseGenerator\Specifications";

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