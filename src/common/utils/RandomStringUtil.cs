using System;
using System.Linq;

namespace LinnworkTestTask.main.utils
{
    public class RandomStringUtil
    {
        private static Random random = new Random();
        
        public static string RandomAlphaNumericString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}