using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GGC.TestCaseGenerator.Models
{
    public class InputParameter
    {
        public string Name { get; set; }
        public string Text { get; set; }

        public InputParameter (string name, string text)
        {
            Name = name;
            Text = text;
        }

    }
}