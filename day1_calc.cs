using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.PortableExecutable;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode1
{
    public class Day1_calc
    {
        public double? Sum => Codes.Sum();
        public double? Sum_Part2 => Codes_Part2.Sum();

        public List<double> Codes = new List<double>();
        public List<double> Codes_Part2 = new List<double>();

        public static List<(string str, int num)> digits =
            [("one", 1), ("two", 2), ("three", 3), ("four", 4), ("five", 5), ("six", 6), ("seven", 7), ("eight", 8), ("nine", 9),
             ("1", 1), ("2", 2), ("3", 3), ("4", 4), ("5", 5), ("6", 6), ("7", 7), ("8", 8), ("9", 9)];

        public void Parser()
        {
            StreamReader sr = new StreamReader("FilePath");
            while(!sr.EndOfStream) {
                Codes.Add(CalcLine(sr.ReadLine()!));
            }
            sr.Close();
        }

        //public void Parser_Part2() //Replace Lösung die funktioniert, außer bei Zeichenketten wie: xtwone3four
        //{
        //    StreamReader sr = new StreamReader("FilePath");
        //    while (!sr.EndOfStream)
        //    {
        //        string formatted_read = sr.ReadLine()!;
        //        foreach(var d in digits)
        //        {
        //            formatted_read= formatted_read.Replace(d.str, d.num);
        //        }
        //        Codes_Part2.Add(CalcLine(formatted_read));
        //    }
        //}

        public void Parser_Part2()
        {
            StreamReader sr = new StreamReader("FilePath");
            while (!sr.EndOfStream)
            {
                string read = sr.ReadLine()!;
                List<(int value, int index)> formatted_strings = new List<(int value, int index)>();
                for (int i = 0; i < read.Length; i++)
                {
                    foreach (var d in digits)
                    {
                        if (read.Substring(i).StartsWith(d.str))
                        {
                            formatted_strings.Add((d.num, i));
                            break;
                        }
                    }
                }
                formatted_strings.OrderByDescending(f => f.index);
                string? output = default;
                foreach(var s in formatted_strings)
                {
                    output += s.value.ToString();
                }
                Codes_Part2.Add(CalcLine(output!));
            }
        }

        public double CalcLine(string input)
        {
            if (input is null) return 0;
            char first = input.First(c => char.IsDigit(c));
            char last = input.Last(c => char.IsDigit(c));
            string erg = first.ToString() + last.ToString();
            return int.Parse(erg);
        }
    }
}
