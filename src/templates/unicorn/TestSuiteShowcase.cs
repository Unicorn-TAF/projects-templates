using System.Collections.Generic;
using Unicorn.Taf.Core.Testing;
using Unicorn.Taf.Core.Testing.Attributes;
using Unicorn.Taf.Core.Utility;
using Unicorn.Taf.Core.Verification;
using Unicorn.Taf.Core.Verification.Matchers;

namespace Company.Tests
{
    [Disabled("This is a demo suite")]
    [Suite("Test suite showcase")]
    [Tag("demo"), Tag("parameterized")]
    [Metadata("Description", "This is a test suite for demonstration of framework abilities")]
    [Parameterized]
    public class TestSuiteShowcase
    {
        private readonly string _suiteParameter;

        public TestSuiteShowcase(string suiteParameter)
        {
            _suiteParameter = suiteParameter;
        }

        [SuiteData]
        public static List<DataSet> SuiteData() =>
            new List<DataSet>
            {
                new DataSet("Set 1", "Some suite parameter"),
                new DataSet("Set 2", "Other suite parameter")
            };

        public List<DataSet> TestData() => DataSetGenerator.CombinationOf(
            new string[] { "value1", "value2" },
            new int[] { 1, 2 });

        [BeforeSuite]
        public void BeforeSuite() { }

        [BeforeTest]
        public void BeforeTest() { }

        [TestCaseId("1")]
        [Author("John Doe")]
        [Category("Smoke")]
        [Test("Simple test")]
        public void SimpleTest()
        {
            Assert.That(_suiteParameter, Is.Not(Is.Null()));
        }

        [TestCaseId("2")]
        [Author("John Doe")]
        [Test("Parameterized test")]
        [TestData(nameof(TestData))]
        public void ParameterizedTest(string stringItem, int intItem)
        {
            Assert.That(stringItem + intItem, Is.EqualTo(stringItem + intItem));
        }

        [TestCaseId("3")]
        [Author("John Doe")]
        [Test("Disabled test")]
        [Disabled("Just disabled")]
        [DependsOn(nameof(SimpleTest))]
        public void DisabledTest() { }

        [AfterTest(runAlways: true, skipTestsOnFail: true)]
        public void AfterTest() { }

        [AfterSuite]
        public void AfterSuite() { }
    }
}
