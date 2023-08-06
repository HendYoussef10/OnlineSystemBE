using Service.Utilities.IUilities.ITextUitilies;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Service.Utilities.Utilities.TextUtilities
{
    public class TextUtility : ITextUtility
    {

      

        private TextUtility()
        {

        }

        public string Base64Encode(string planText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(planText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public string Base64Decode(string base64Decode)
        {
            try
            {
                var base64EncodedBytes = System.Convert.FromBase64String(base64Decode);
                return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
            }
            catch (Exception)
            {
                return "";
            }
        }

        internal static TextUtility Getinstance()
        {
            return new TextUtility();
        }
    }
}
