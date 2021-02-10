//// ********************************************************************************
//// Created by:    Jim Wood 
//// Date created:  01/15/2016
//// Reason:
////     ULTI-161882 Jarvis: create framework for full-scale integration testing.
//// ********************************************************************************

using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Generator.Helpers
{
    /// <summary>
    /// Provides methods and data to extract data from XML input files.
    /// </summary>
    public class XmlHelper
    {
        /// <summary>
        /// Returns the root element of the XML in the given file.
        /// </summary>
        public static XDocument Document(string observedXml)
        {
            return XDocument.Parse(observedXml);
        }

        /// <summary>
        /// Returns the root element of the XML in the given file.
        /// </summary>
        public static XElement Root(string observedXml, string rootName)
        {
            XDocument xmlDocument = Document(observedXml);
            if (xmlDocument == null)
            {
                return null;
            }

            return xmlDocument.Element(rootName);
        }

        /// <summary>
        /// Returns the string value of the child element in the given XML element.
        /// </summary>
        public static string ElementOf(XElement element, string attribute)
        {
            if ((element == null) || string.IsNullOrEmpty(attribute))
            {
                return string.Empty;
            }

            XElement attributeElement = element.Element(attribute);
            if (attributeElement == null)
            {
                return null;
            }

            return attributeElement.Value;
        }

        /// <summary>
        /// Returns the string value of the child attribute in the given XML element.
        /// </summary>
        public static string AttributeOf(XElement element, string attribute)
        {
            if ((element == null) || string.IsNullOrEmpty(attribute))
            {
                return string.Empty;
            }

            XAttribute attributeObject = element.Attribute(attribute);
            if (attributeObject == null)
            {
                return null;
            }

            return attributeObject.Value;
        }

        /// <summary>
        /// Returns the list of children (first-level descendants only) of a given name from the given XML element.
        /// </summary>
        public static IEnumerable<XElement> Children(XElement element, string childName)
        {
            if (element == null)
            {
                return null;
            }

            return string.IsNullOrEmpty(childName)
                ? element.Elements()
                : element.Elements(childName);
        }
    }
}
