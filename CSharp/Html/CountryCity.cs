using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

// http://stackoverflow.com/questions/35219965
namespace kuujinbo.StackOverflow.RegularExpressions.CSharp.Html
{
    public class CountryCity
    {
        string HTML = @"
<table style='width:100%'>
    <tr><td class='country'>Germany</td></tr>
    <tr><td class='city'>Berlin</td></tr>
    <tr><td class='city'>Cologne</td></tr>
    <tr><td class='city'>Munich</td></tr>
    <tr><td class='country'>France</td></tr>
    <tr><td class='city'>Paris</td></tr>
    <tr><td class='country'>USA</td></tr>
    <tr><td class='city'>New York</td></tr>
    <tr><td class='city'>Las Vegas</td></tr>
</table>
        ";
 
        public void Go()
        {
            var regex = new Regex(
                @"
                    class=[^>]*?
                    (?<class>[-\w\d_]+)
                    [^>]*>
                    (?<text>[^<]+)
                    <
                ",
                RegexOptions.Compiled | RegexOptions.IgnoreCase 
                | RegexOptions.IgnorePatternWhitespace
            );

            var country = string.Empty;
            var Countries = new Dictionary<string, List<string>>();
            foreach (Match match in regex.Matches(HTML))
            {
                string countryCity = match.Groups["class"].Value.Trim();
                string text = match.Groups["text"].Value.Trim();
                if (countryCity.Equals("country", StringComparison.OrdinalIgnoreCase))
                {
                    country = text;
                    Countries.Add(text, new List<string>());
                }
                else
                {
                    Countries[country].Add(text);
                }
            }

            foreach (var kvp in Countries)
            {
                Console.WriteLine(
                    "Country: {0} || Cities: {1}",
                    kvp.Key, string.Join(", ", kvp.Value.ToArray())
                );
            }
        }



    }
}