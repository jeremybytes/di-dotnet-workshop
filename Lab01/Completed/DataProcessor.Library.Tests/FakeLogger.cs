using System;
using System.Collections.Generic;
using System.Text;

namespace DataProcessor.Library.Tests
{
    public class FakeLogger : ILogger
    {
        public void Log(string message, string data)
        {
            // Just a placeholder for testing
        }
    }
}
