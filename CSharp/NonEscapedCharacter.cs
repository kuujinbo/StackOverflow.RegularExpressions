using System;
using System.Text.RegularExpressions;

// http://stackoverflow.com/questions/35227114
namespace kuujinbo.StackOverflow.RegularExpressions.CSharp
{
    public class NonEscapedCharacter
    {
        string[] testing = new string[]
        {
	        "SOMEKEYWORD:{SOMEVALUE}",
	        "SOMEKEYWORD:{SOMEVALUE/:WITHCOLONESCAPED}",
	        "SOMEKEYWORD:{SOMEVALUE/;WITHSEMICOLONESCAPED}",
	        "SOMEKEYWORD;TYPE={SOMETYPE}:{SOMEVALUE}",
	        "SOMEKEYWORD;TYPE={SOMETYPE}:{SOMEVALUE/:WITHCOLONESCAPED}",
	        "SOMEKEYWORD;TYPE={SOMETYPE}:{SOMEVALUE/;WITHSEMICOLONESCAPED}",
	        "SOMEKEYWORD;ARG1=MYARG1;TYPE={SOMETYPE}:{SOMEVALUE}",
	        "SOMEKEYWORD;ARG1=MYARG1;TYPE={SOMETYPE}:{SOMEVALUE/:WITHCOLONESCAPED}",
	        "SOMEKEYWORD;ARG1=MYARG1;TYPE={SOMETYPE}:{SOMEVALUE/;WITHSEMICOLONESCAPED}",
	        "SOMEKEYWORD;ARG1=MYARG1;TYPE={SOMETYPE};ARG2=MYARG2:{SOMEVALUE}",
	        "SOMEKEYWORD;ARG1=MYARG1;TYPE={SOMETYPE};ARG2=MYARG2:{SOMEVALUE/:WITHCOLONESCAPED}",
	        "SOMEKEYWORD;ARG1=MYARG1;TYPE={SOMETYPE};ARG2=MYARG2:{SOMEVALUE/;WITHSEMICOLONESCAPED}"
        };

        public void Go()
        {
            var regex = new Regex(
                @"
		            (
			            (TYPE=(?<type>[^;]+);[^:]*?)		
			            | 
			            (TYPE=(?<type>.*?))
		            )?
		            :
		            (?<value>.*)$
	            ",
                RegexOptions.Compiled
                | RegexOptions.IgnoreCase
                | RegexOptions.IgnorePatternWhitespace
            );

            // tried to use the fewest number of capture groups for readability
            foreach (var test in testing)
            {
                Match match = regex.Match(test);
                Console.Write(
                    "type: [{0}] || value: [{1}]\n",
                    match.Groups["type"].Value,
                    match.Groups["value"].Value
                );
            }

        }
    }
}