using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic.FileIO;
using kuujinbo.StackOverflow.RegularExpressions.Utilities;

// http://stackoverflow.com/questions/34279853
namespace kuujinbo.StackOverflow.RegularExpressions.CSharp
{
    public class TextFieldParserKeepWhiteSpace
    {
        public void Go()
        {
            var inputPath = IO.GetInputFilePath("TextFieldParserKeepWhiteSpace.txt");

            var separator = new string('=', 40);
            Console.WriteLine(separator);
            // demo only - show the input lines read from a text file 
            var text = File.ReadAllText(inputPath);
            var lines = text.Split(
                new string[] { Environment.NewLine }, 
                StringSplitOptions.None
            );

            using (var textReader = new StringReader(text))
            {
                using (var parser = new TextFieldParser(textReader))
                {
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(",");
                    parser.TrimWhiteSpace = true;
                    parser.HasFieldsEnclosedInQuotes = false;
                    // remove double quotes, since HasFieldsEnclosedInQuotes is false
                    var regex = new Regex(@"
                    # match double quote 
                    \""    
                    # if not immediately followed by a double quote
                    (?!\"")
                    ",
                        RegexOptions.IgnorePatternWhitespace
                    );

                    var rowStart = 0;
                    while (parser.PeekChars(1) != null)
                    {
                        Console.WriteLine(
                            "row {0}: {1}", parser.LineNumber, lines[rowStart]
                        );
                        var fields = parser.ReadFields();
                        for (int i = 0; i < fields.Length; ++i)
                        {
                            Console.WriteLine(
                                "parsed field[{0}] = [{1}]", i,
                                regex.Replace(fields[i], "")
                            );
                        }
                        ++rowStart;
                        Console.WriteLine(separator);
                    }
                }
            }


        }
    }
}
