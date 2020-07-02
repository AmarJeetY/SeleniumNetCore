using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace Zoopla.Selenium.Tests.Hooks
{
    [Binding]
    public class Feature
    {
        [Binding]
        public class BeforeAfterFeature
        {
            [BeforeFeature]
            public static void BeforeFeature()
            {
                
            }

            [AfterFeature]
            public static void AfterFeature()
            {
                
            }
        }
    }
}
