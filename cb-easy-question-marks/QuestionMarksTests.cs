using System.Reflection;
using System.Collections.Generic;
using System;
using System.Linq;
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

        public static string QuestionsMarksDave(string str) 
        {
            var result= "false";
    
            int firstIndex = -1;
            int secondIndex = -1;
            int firstNumber = -1;
            int secondNumber = -1;
            int number = -1;
            int qCount = 0;
            string substring = string.Empty;
            bool couldParse = false;
            str.ToList().ForEach(x => 
            {      
                couldParse = int.TryParse(x.ToString(), out number);
                
                firstIndex = couldParse && firstIndex == -1 ? str.IndexOf(x) : firstIndex;
                secondIndex = couldParse && secondIndex == -1 && firstIndex != str.IndexOf(x) ? str.IndexOf(x) : secondIndex;
                firstNumber = firstIndex != -1 ? number : firstIndex;
                secondNumber = secondIndex != -1 ? number : secondIndex;
                substring = firstIndex != -1 && secondIndex != -1 ? str.Substring(firstIndex, (secondIndex - firstIndex)) : string.Empty;
                qCount = substring.ToList().Where(c => c == '?').Count();
                result = firstNumber + secondNumber == 10 ? (qCount == 3 ? "true" : "false") : "false";
            });
            return result;
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

        [Fact]
        public void Case8()
        {
            var test = "arrb6???4xxbl5???eee5";

            var response = QuestionsMarksDave(test);

            Assert.Equal("true", response);
        }

        [Fact]
        public void Case9()
        {
            var test = "9???1???9???1???9";

            var response = QuestionsMarksDave(test);

            Assert.Equal("true", response);
        }

        [Fact]
        public void Case10()
        {
            var test = "5??aaaaaaaaaaaaaaaaaaa?5?a??5";

            var response = QuestionsMarksDave(test);

            Assert.Equal("true", response);
        }

        [Fact]
        public void Case11()
        {
            var test = "aa6?9";

            var response = QuestionsMarksDave(test);

            Assert.Equal("false", response);
        }

        [Fact]
        public void Case12()
        {
            var test = "?";

            var response = QuestionsMarksDave(test);

            Assert.Equal("false", response);
        }

        [Fact]
        public void Case13()
        {
            var test = "";

            var response = QuestionsMarksDave(test);

            Assert.Equal("false", response);
        }

        [Fact]
        public void Case14()
        {
            var test = "5????5";

            var response = QuestionsMarksDave(test);

            Assert.Equal("false", response);
        }
    }
}
