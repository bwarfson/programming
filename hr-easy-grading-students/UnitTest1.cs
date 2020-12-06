using System;
using Xunit;
using Xunit.Abstractions;
using System.Collections.Generic;
using System.Collections;
using System.Diagnostics;

namespace hr_easy_grading_students
{
    

    public class UnitTest1
    {
        private readonly ITestOutputHelper output;

        public UnitTest1(ITestOutputHelper output)
        {
            this.output = output;
        }

        /// <summary>
        /// Every student receives a grade in the inclusive range from 0 to 100.
        /// Any grade less then 40 is a failing grade.
        /// If the difference between the grade and the next multiple of 5 is less than 3, round grade up to the next multiple of 5.
        /// If the value of grade is less than 38, no rounding occurs as the result will still be a failing grade.
        /// </summary>
        /// <param name="grades"></param>
        /// <returns></returns>
        public List<int> gradingStudents(List<int> grades)
        {
            for(int i = 0; i < grades.Count; i++)
            {
                var grade = grades[i];

                var nextMultipleOfFive = (grade + 4) / 5 * 5;

                if(nextMultipleOfFive < 40)
                    continue;

                if((nextMultipleOfFive - grade) < 3)
                    grades[i] = nextMultipleOfFive;

            }

            return grades;
        }

        [Fact]
        public void Case1()
        {
            List<int> grades = new List<int> {73,67,38,33};

            output.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

            var result = gradingStudents(grades);

            output.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");

            Assert.Equal(75, result[0]);
            Assert.Equal(67, result[1]);
            Assert.Equal(40, result[2]);
            Assert.Equal(33, result[3]);
        }
    }
}
