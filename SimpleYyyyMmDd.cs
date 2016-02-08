using System;
using System.Text.RegularExpressions;

// http://stackoverflow.com/questions/35260469
namespace kuujinbo.StackOverflow.RegularExpressions
{
    public class SimpleYyyyMmDd
    {
        public void Go()
        {
            var stringToValidate = "0001-04-30";
            // FEB / APR / JUN / SEP / NOV fail or overflow, 
            // depending on how you construct DateTime
            // single line Regex, formatted below for readability:
            // "\d{3}[1-9]-(0[1-9]|1[012])-(0[1-9]|1\d|2\d|3[01])"
            var regexSimple = new Regex(
                @"
		            # DateTime.MinValue => '0001-01-01'
		            \d{3}[1-9]
		            - 
		            (0[1-9] | 1[012])
		            -
		            (0[1-9] | 1\d | 2\d | 3[01])
	            ",
                RegexOptions.Compiled
                | RegexOptions.IgnorePatternWhitespace
            );

            // FEB fails on leap years, 
            // single line Regex, formatted below for readability:
            // "\d{3}[1-9]-(([0][13578]-(0[1-9]|1[012]|2\d|3[01]))|([0][469]-(0[1-9]|1[012]|2\d|3[0]))|(02-(0[1-9]|1[012]|2[0-8]))|(11-(0[1-9]|1[012]|2\d|30))|(12-(0[1-9]|1[012]|2\d|3[01])))"
            var regexAllButFeb = new Regex(
                @"
		            # DateTime.MinValue => '0001-01-01'
		            \d{3}[1-9]
		            - 
		            (
			            # JAN / MAR / MAY / JUL/ AUG
			            ([0][13578]-(0[1-9] | 1[012] | 2\d | 3[01]))
			            | 
			            # APR / JUN / SEP / NOV
			            ([0][469]-(0[1-9] | 1[012] | 2\d | 30))
			            |
			            # FEB
			            (02-(0[1-9] | 1[012] | 2[0-8]))
			            #	or replace with [0-9] - ^^^^^
			            |
			            # NOV
			            (11-(0[1-9] | 1[012] | 2\d | 30))
			            |
			            # DEC
			            (12-(0[1-9] | 1[012] | 2\d | 3[01]))
		            )
	            ",
                RegexOptions.Compiled
                | RegexOptions.IgnorePatternWhitespace
            );

            Console.WriteLine("regexSimple: {0}", regexSimple.IsMatch(stringToValidate));
            Console.WriteLine("regexAllButFeb: {0}", regexAllButFeb.IsMatch(stringToValidate));
        }
    }
}