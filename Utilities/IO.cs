using System;
using System.IO;

namespace kuujinbo.StackOverflow.RegularExpressions.Utilities
{
    public static class IO
    {
        #region IN
        public static string InputDirectory()
        {
            return Path.Combine(
              Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName
              , "_INPUT"
            );
        }

        public static string GetInputFilePath(string fileName)
        {
            return Path.Combine(InputDirectory(), fileName);
        }
        #endregion


    }
}