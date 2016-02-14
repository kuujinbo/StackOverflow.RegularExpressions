using kuujinbo.StackOverflow.RegularExpressions.Html;

namespace kuujinbo.StackOverflow.RegularExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            new TextFieldParseRegex().Go();
            // new SimpleYyyyMmDd().Go();
            //new CountryCity().Go();
            //new NonEscapedCharacter().Go();
        }
    }
}