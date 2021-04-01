using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GGC.TestCaseGenerator.Models
{
    public class TestSpecification
    {
        public IList<CoverageGroup> CoverageGroups { get; set; }

        public TestSpecification()
        {

            CoverageGroups = null;

        }

    }
}