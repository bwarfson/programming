using System.Reflection;
using System.Collections.Generic;
using System;
using Xunit;
using Xunit.Abstractions;

namespace cb_easy_question_marks
{
    public class QuestionMarksTests
    {
        private readonly ITestOutputHelper output;

        public QuestionMarksTests(ITestOutputHelper output)
        {
            this.output = output;
        }
        public bool QuestionMarks(string str) 
        {
            var numberIndexList = new List<int>();

            for (int i = 0; i < str.Length; i++)
            {
                if(Char.IsNumber(str[i]))
                    numberIndexList.Add(i);
            }

            for (int i = 0; i < numberIndexList.Count - 1; i++)
            {
                var value = (str[numberIndexList[i]] - '0') + (str[numberIndexList[i + 1]] - '0');
                
                if (value == 10)
                {
                    int count = 0;
                    for (int j = numberIndexList[i]; j < numberIndexList[i + 1]; j++)
                    {
                        if (str[j] == '?')
                            count++;
                    }
                    if (count == 3)
                        return true;
                }
            }

            return false;
        }

        [Fact]
        public void Case1()
        {
            var test = "arrb6???4xxbl5???eee5";

            var response = QuestionMarks(test);

            Assert.True(response);
        }

        [Fact]
        public void Case2()
        {
            var test = "9???1???9???1???9";

            var response = QuestionMarks(test);

            Assert.True(response);
        }

        [Fact]
        public void Case3()
        {
            var test = "5??aaaaaaaaaaaaaaaaaaa?5?a??5";

            var response = QuestionMarks(test);

            Assert.True(response);
        }

        [Fact]
        public void Case4()
        {
            var test = "aa6?9";

            var response = QuestionMarks(test);

            Assert.False(response);
        }

        [Fact]
        public void Case5()
        {
            var test = "?";

            var response = QuestionMarks(test);

            Assert.False(response);
        }

        [Fact]
        public void Case6()
        {
            var test = "";

            var response = QuestionMarks(test);

            Assert.False(response);
        }

        [Fact]
        public void Case7()
        {
            var test = "5????5";

            var response = QuestionMarks(test);

            Assert.False(response);
        }
    }
}
