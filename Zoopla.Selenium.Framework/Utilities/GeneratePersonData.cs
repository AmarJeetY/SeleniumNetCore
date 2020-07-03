using System;
using System.Linq;

namespace Zoopla.Selenium.Framework.Utilities
{
    public static class GeneratePersonData
    {
        private static Random random = new Random();
        public static string RandomEmail(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray()) + "+blacklist@test.com";
        }

    }
}
