using System;
using Xunit;
using System.Text.RegularExpressions;

namespace hr_matching_anything_but_a_new_line
{
    /// <summary>
    /// You have a test string S.
    /// Your task is to write a regular expression that matches only and exactly strings of form: abc.def.ghi.jkx,
    /// where each variable a,b,c,d,e,f,g,h,i,j,k,x can be any single character except the newline.
    /// </summary>
    public class UnitTest1
    {
        public bool IsMatch(string s)
        {
            var match = Regex.Match(s, @"^...\....\....\....$");
            return match.Success;
        }

        [Fact]
        public void Case1()
        {
            Assert.True(IsMatch("123.456.abc.def"));
        }

        [Fact]
        public void Case2()
        {
            Assert.False(IsMatch("1123.456.abc.def"));
        }
    }
}
