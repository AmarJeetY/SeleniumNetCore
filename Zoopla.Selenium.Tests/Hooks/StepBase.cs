using TechTalk.SpecFlow;
using Zoopla.Selenium.Framework.Interfaces;
using Zoopla.Selenium.Framework.Utilities;

namespace Zoopla.Selenium.Tests.Hooks
{
    public class StepBase : Steps
    {
        protected ISeleniumDriver _seleniumDriver;
        protected ITestData _testData;

        public void BeforeScenario()
        {
            _seleniumDriver = IOC.Resolve<ISeleniumDriver>(FeatureContext.FeatureContainer);
            _testData = IOC.Resolve<ITestData>(FeatureContext.FeatureContainer);
        }

        public static void BeforeFeatureStep(FeatureContext featureContext)
        {
            IOC.Register(featureContext.FeatureContainer);
        }

        [StepArgumentTransformation(@"(true|false|present|not present)")]
        public bool BooleanTransform(string value)
        {
            return value == "true" || value == "present";
        }
    }
}