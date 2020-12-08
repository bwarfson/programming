using System.Xml;
using System.Xml.Linq;
using System.Reflection;
using System;
using Xunit;
using Xunit.Abstractions;
using System.Collections.Generic;

namespace hr_easy_ransom_note
{
    
    public class RansomNote
    {
        private readonly ITestOutputHelper output;

        public RansomNote(ITestOutputHelper output)
        {
            this.output = output;
        }

        string checkMagazine(string[] magazine, string[] note) 
        {
            var wordDictionary = new Dictionary<string, int>();
            int value;
            foreach(var word in magazine) 
            {
                if(!wordDictionary.TryGetValue(word, out value))
                    wordDictionary.Add(word, 1);
                else
                    wordDictionary[word] = value + 1;
            }
            
            foreach(var word in note)
            {
                bool keyExists = wordDictionary.ContainsKey(word) && wordDictionary[word]>0;
                if(!keyExists)
                {
                    return "No";
                }
                else 
                {
                    wordDictionary[word]--;
                }    
                
            }
            
            return "Yes";
        }

        [Fact]
        public void Case0()
        {
            string[] magazine = "give me one grand today night".Split(' ');
            string[] note = "give one grand today".Split(' ');

            var response = checkMagazine(magazine, note);
            output.WriteLine(response);
            Assert.Equal("Yes", response);
        }

        [Fact]
        public void Case1()
        {
            string[] magazine = "two times three is not four".Split(' ');
            string[] note = "two times two is four".Split(' ');

            var response = checkMagazine(magazine, note);
            output.WriteLine(response);
            Assert.Equal("No", response);
        }

        [Fact]
        public void Case2()
        {
            string[] magazine = "ive got a lovely bunch of coconuts".Split(' ');
            string[] note = "ive got some coconuts".Split(' ');

            var response = checkMagazine(magazine, note);
            output.WriteLine(response);
            Assert.Equal("No", response);
        }
    
    }
}
