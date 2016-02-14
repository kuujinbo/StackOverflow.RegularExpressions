using System;
using System.Linq;
using Microsoft.VisualBasic.FileIO;
using kuujinbo.StackOverflow.RegularExpressions.Utilities;

// http://stackoverflow.com/questions/35389302
namespace kuujinbo.StackOverflow.RegularExpressions.CSharp
{
    public class TextFieldParseRegex
    {
        public void Go()
        {
            var inputPath = IO.GetInputFilePath("TextFieldParseRegex.txt");
            var line = new string('=', 40);
            Console.WriteLine(line);
            using (var parser = new TextFieldParser(inputPath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                parser.TrimWhiteSpace = true;
                parser.HasFieldsEnclosedInQuotes = true;

                while (parser.PeekChars(1) != null)
                {
                    Console.WriteLine("Line {0}: ", parser.LineNumber);
                    var cleanFieldRowCells = parser.ReadFields().Select(
                        f => f.Trim(new[] { ' ', '"' })).ToArray();
                    for (int i = 0; i < cleanFieldRowCells.Length; ++i)
                    {
                        Console.WriteLine(
                            "Field[{0}] = [{1}]", i, cleanFieldRowCells[i]
                        );
                    }
                    Console.WriteLine(line);
                }
            }
        }
    }
}