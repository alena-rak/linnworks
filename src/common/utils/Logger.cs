using System;

namespace LinnworkTestTask.main.utils
{
    public class Logger
    {
        //ok, inventing some my own bicycle here instead of using existing logger frameworks

        public static void Info(String message)
        {
            Console.WriteLine(String.Format("{0}: {1}", DateTime.Now.ToString("MM/dd/yyyy HH:mm"), message));
        }
    }
}