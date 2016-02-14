using System;
using System.Linq;
using Microsoft.VisualBasic.FileIO;
using kuujinbo.StackOverflow.RegularExpressions.Utilities;

namespace kuujinbo.StackOverflow.RegularExpressions.CSharp
{
    public class TextFieldParseRegex
    {
        public void Go()
        {
            var inputPath = IO.GetInputFilePath("TextFieldParseRegex.txt");

            using (var parser = new TextFieldParser(inputPath))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(";");
                parser.TrimWhiteSpace = true;
                parser.HasFieldsEnclosedInQuotes = true;

                while (parser.PeekChars(1) != null)
                {
                    var cleanFieldRowCells = parser.ReadFields().Select(
                        f => f.Trim(new[] { ' ', '"' })).ToArray();
                    Console.WriteLine("New Line");
                    for (int i = 0; i < cleanFieldRowCells.Length; ++i)
                    {
                        Console.WriteLine(
                            "Field[{0}]: = [{1}]", i, cleanFieldRowCells[i]
                        );
                    }
                    Console.WriteLine("{0}", new string('=', 40));
                }
            }
        }
    }
}