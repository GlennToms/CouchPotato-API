using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CouchPotato
{
    internal static class Util
    {
        public static string ReplaceSpecial(string String)
        {
            var myString = Regex.Replace(String, @"[^0-9a-zA-Z]+", " ");

            return myString;
        }
    }
}
