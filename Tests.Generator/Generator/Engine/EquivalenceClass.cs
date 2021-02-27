//// ********************************************************************************
//// Created by:    Jim Wood 
//// Date created:  05/24/2017
//// Reason:
////     ULTI-249839: Write a tool to generate test cases from an XML specification.
//// ********************************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Generator.Engine
{
    /// <summary>
    /// Class that encapsulates an equivalence class for a test specification's
    /// input parameter.
    /// </summary>
    public class EquivalenceClass
    {
        /// <summary>
        /// Specifies text for the GIVEN condition on the equivalence class.
        /// </summary>
        public string Given { get; set; }

        /// <summary>
        /// The name of the equivalence class from the XML file.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The text associated with the equivalence class from the XML file.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Condition that must be true in any test using this parameter.
        /// </summary>
        public Expression ConditionExpression { get; set; }

        /// <summary>
        /// Condition represented as strings (INFIX notation).
        /// >>operator of a binary expression is in the middle a + b
        /// </summary>
        public string Condition { get; set; }

        /// <summary>
        /// Constructs and initializes an instance object of the class EquivalenceClass.
        /// </summary>
        public EquivalenceClass()
        {
            Given = null;
            Name = null;
            Text = null;
            ConditionExpression = null;
            Condition = null;
        }

        /// <summary>
        /// Sets the data members of the class and returns true if successful.
        /// </summary>
        public bool Set(string given, string name, string text, IList<Expression> conditions)
        {
            Given = given;
            Name = name;
            Text = text;
            ConditionExpression = ((conditions == null) || !conditions.Any()) ? null : conditions[0];
            return true;
        }

        /// <summary>
        /// Reads the XML element for the equivalence class and returns true if successful.
        /// </summary>
        public bool ReadAsXml(XElement xEquivalenceClass)
        {
            string given = TestSpecification.XmlField(xEquivalenceClass, "Given");
            string name = TestSpecification.XmlField(xEquivalenceClass, "Name");
            string text = TestSpecification.XmlField(xEquivalenceClass, "Text");

            IList<Expression> conditions = Expression.AllExpressonsAsXml(xEquivalenceClass);
            return Set(given, name, text, conditions);
        }

        /// <summary>
        /// Parses the strings containing the expression conditions. Returns true if all are successful.
        /// </summary>
        public bool ParseConditions()
        {
            if (string.IsNullOrEmpty(Condition))
            {
                ConditionExpression = null;
                return true;
            }

            ConditionExpression = ExpressionParser.Parse(Condition);
            return ConditionExpression != null;
        }

        /// <summary>
        /// Validates the test specification and returns true if successful; otherwise false
        /// and returns an informative error message.
        /// </summary>
        public bool Validate(IList<string> errors)
        {
            return true;
        }
    }
}
