#if (ReportPortal)
using Unicorn.Reporting.ReportPortal;
#endif
#if (Allure)
using Unicorn.Reporting.Allure;
#endif
#if (TestIT)
using Unicorn.Reporting.TestIt;
#endif
#if (HasReporting)
using Unicorn.Taf.Api;
#endif
using Unicorn.Taf.Core.Testing.Attributes;

namespace Company.Tests
{
    /// <summary>
    /// Actions performed before and/or after all tests execution.
    /// </summary>
    [TestAssembly]
    public class TestAssembly
    {
#if (HasReporting)
        private static ITestReporter reporter;
#endif

        /// <summary>
        /// Actions before all tests execution.
        /// The method should be static.
        /// </summary>
        [RunInitialize]
        public static void InitRun()
        {
#if (ReportPortal)
            // Initialize built-in Report Portal reporter with automatic subscription to all testing events.
            // ReportPortal.config.json should exist in binaries directory.
            reporter = new ReportPortalReporter();
#endif
#if (Allure)
            // Initialize built-in Allure reporter with automatic subscription to all testing events.
            // allureConfig.json should exist in binaries directory.
            reporter = new AllureReporter();
#endif
#if (TestIT)
            // Initialize built-in TestIT reporter with automatic subscription to all testing events.
            // Tms.config.json should exist in binaries directory.
            reporter = new TestItReporter();
#endif
        }

        /// <summary>
        /// Actions after all tests execution.
        /// The method should be static.
        /// </summary>
        [RunFinalize]
        public static void FinalizeRun()
        {
#if (HasReporting)
            // Unsubscribe reporter from unicorn events.
            reporter?.Dispose();
            reporter = null;
#endif
        }
    }
}