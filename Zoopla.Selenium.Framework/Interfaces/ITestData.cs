using System;
using System.Collections.Generic;
using System.Text;

namespace Zoopla.Selenium.Framework.Interfaces
{
    public interface ITestData
    {
        Dictionary<string, string> GetTestParameters(string testCase);
    }

}
