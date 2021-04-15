using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GGC.TestCaseGenerator.Models;
using GGC.TestCaseGenerator.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace GGC.TestCaseGenerator.Tests
{
    [TestClass]
    public class TestAddSpecification
    {
        [TestMethod]
        public void Add()
        {
            ModelInterfaceController model = new ModelInterfaceController();
            CoverageGroup group1 = new CoverageGroup();
            CoverageGroup group2 = new CoverageGroup();
            CoverageGroup group3 = new CoverageGroup();
            InputParameter inputParam = new InputParameter();
            ExpectedResult result = new ExpectedResult();
            IList<CoverageGroup> groups = new List<CoverageGroup>();
            IDictionary<string, InputParameter> inputParameters = new Dictionary<string, InputParameter>();
            IDictionary<string, ExpectedResult> expectedResults = new Dictionary<string, ExpectedResult>();
            groups.Add(group1);
            groups.Add(group2);
            groups.Add(group3);

            inputParameters.Add("InputKey1", inputParam);
            expectedResults.Add("ResultKey1", result);

            TestSpecification test = new TestSpecification();

            string given = "TestParam1";
            string name = "Member1,Member2,Member3";
            string text = "Test Param 1 Description";

            Assert.IsTrue(test.Set(given, name, text, groups, inputParameters, expectedResults));
        }
    }
}