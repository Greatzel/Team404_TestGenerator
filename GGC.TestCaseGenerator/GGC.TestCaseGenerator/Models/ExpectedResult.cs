using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GGC.TestCaseGenerator.Models
{
    /// <summary>
    /// Class that encapsulates a test specification's expected result.
    /// </summary>
    public class ExpectedResult
    {

        /// <summary>
        /// Specifies text for the GIVEN constraint on the expected result.
        /// </summary>
        public string Given { get; set; }

        /// <summary>
        /// The name of the expected result from the XML file.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The text associated with the expected result from the XML file.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The boolean expression associated with the expected result from the XML file.
        /// </summary>
        public Expression ConditionExpression { get; set; }

        /// <summary>
        /// The boolean expression represented as a string (INFIX notation).
        /// </summary>
        public string Condition { get; set; }

        /// <summary>
        /// Constructs and initializes an instance object of the class ExpectedResult.
        /// </summary>
        public ExpectedResult()
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
        public bool Set(string given, string name, string text, Expression condition)
        {
            Given = given;
            Name = name;
            Text = text;
            ConditionExpression = condition;
            return true;
        }

        /// <summary>
        /// Writes the expected result as a string and returns it.
        /// </summary>
        public string WriteAsString()
        {
            return $"{Text} ";
        }

        /// <summary>
        /// Parses the string containing the boolean expression. Returns true if successful.
        /// </summary>
        /// <returns></returns>
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
            bool validate = true;
            if ((Condition == null) || (ConditionExpression == null))
            {
                errors.Add($"expected result {Name} is defined by no condition");
                validate = false;
            }

            return validate;
        }
    }
}