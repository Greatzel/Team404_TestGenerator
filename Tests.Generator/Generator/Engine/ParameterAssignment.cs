//// ********************************************************************************
//// Created by:    Jim Wood 
//// Date created:  05/24/2017
//// Reason:
////     ULTI-249839: Write a tool to generate test cases from an XML specification.
//// ********************************************************************************

using System;

namespace Generator.Engine
{
    /// <summary>
    /// Class that encapsulates the data of a parameter assignment in a test case.
    /// </summary>
    public class ParameterAssignment
    {
        /// <summary>
        /// Specifies text for the GIVEN condition on the input parameter.
        /// </summary>
        public string Given { get; set; }

        /// <summary>
        /// The name of the input parameter from the XML file.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The text associated with the input parameter from the XML file.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The selected equivalence class for this parameter in this test case.
        /// </summary>
        public EquivalenceClass SelectedEquivalenceClass { get; set; }

        /// <summary>
        /// Constructs and initializes an instance object of the class ParameterAssignment.
        /// </summary>
        public ParameterAssignment()
        {
            Given = null;
            Name = null;
            Text = null;
            SelectedEquivalenceClass = null;
        }

        /// <summary>
        /// Sets the data members of the class and returns true if successful.
        /// </summary>
        public bool Set(string given, string name, string text, EquivalenceClass selectedEquivalenceClass)
        {
            Given = given;
            Name = name;
            Text = text;
            SelectedEquivalenceClass = selectedEquivalenceClass;
            return true;
        }

        /// <summary>
        /// Writes the parameter assignment as a string and returns it.
        /// </summary>
        public string WriteAsString()
        {
            return $"{Text} is {SelectedEquivalenceClassText()} ";
        }
        
        /// <summary>
        /// Returns the normalized name value of the selected equivalence class.
        /// </summary>
        public string SelectedEquivalenceClassName()
        {
            return (SelectedEquivalenceClass == null)
                ? "(unassigned)"
                : string.IsNullOrEmpty(SelectedEquivalenceClass.Name) ? "''" : SelectedEquivalenceClass.Name;
        }

        /// <summary>
        /// Returns the normalized text value of the selected equivalence class.
        /// </summary>
        public string SelectedEquivalenceClassText()
        {
            return (SelectedEquivalenceClass == null)
                ? "(unassigned)"
                : string.IsNullOrEmpty(SelectedEquivalenceClass.Text) ? "''" : SelectedEquivalenceClass.Text;
        }
    }
}
