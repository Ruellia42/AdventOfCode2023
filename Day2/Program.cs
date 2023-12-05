using System.Text.RegularExpressions;
using System.Xml.XPath;
using Microsoft.VisualBasic;

namespace Day2
{
    class Program
    {    
        static readonly string textFile = "test.txt";
        static readonly string[] colors = {"red", "green", "blue"};
        static readonly int[] numbers = {12, 13, 14};

        static void Main()
        {
            part1();

            void part1()
            {
                int IDsum = 0;
                string[] lines = File.ReadAllLines(textFile);
                foreach (string line in lines)
                {
                    int currentID = FindID(line);
                    Console.WriteLine(line + " ID " + currentID);
                    if(IsValidGame(line))
                    {
                        IDsum += currentID;
                    }
                }
                Console.WriteLine("Result: " + IDsum);
            }

            bool IsValidGame(string line)
            {
                foreach (string color in colors)
                {
                    string regexInput = "[0-9]+ " + color;
                    string result = GetValueOfRegex(line, regexInput); //this only gets the first instance of each color...
                    if (result != null)
                    {
                        int count = Int32.Parse(GetValueOfRegex(result, "[0-9]+"));
                        if (count > 14)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            
            int FindID(string line)
            {
                string word = GetValueOfRegex(line, "Game [0-9]+:");
                if(word != null)
                {
                    string id = GetValueOfRegex(word, "[0-9]+");
                    return Int32.Parse(id);
                }
                else
                {
                    return 0;
                };
            }

            string GetValueOfRegex(string line, string regexInput)
            {
                Regex regex = new Regex(regexInput, RegexOptions.IgnoreCase);
                if(regex.IsMatch(line))
                {
                    Match m = regex.Match(line);
                    return m.Value;
                }
                else
                {
                    return null;
                }
            }
        }

    }
}