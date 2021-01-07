using System;
using Xunit;
using Xunit.Abstractions;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;

namespace time_conversion
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper output;

        public UnitTest1(ITestOutputHelper output)
        {
            this.output = output;
        }
        public string timeConversion(string s) 
        {
            var parsedDate = DateTime.Parse(s);
            var ts = parsedDate.TimeOfDay;
            output.WriteLine(ts.ToString());
            return ts.ToString();
        }
        [Fact]
        public void Test1()
        {
            var result = timeConversion("07:05:45PM");
            Assert.Equal("19:05:45", result);
        }
    }
}
