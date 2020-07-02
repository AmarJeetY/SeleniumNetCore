using TechTalk.SpecFlow;
using Zoopla.Selenium.Framework.Utilities;

namespace Zoopla.Selenium.Tests.Hooks
{
    public class StepBase
    {
       // protected IQuoteEngineClient _quoteEngineClient;
       
        public void BeforeScenario()
        {
           // _quoteEngineClient = IOC.Resolve<IQuoteEngineClient>(FeatureContext.FeatureContainer);
            
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


