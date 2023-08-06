using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Utilities.IUilities.ITextUitilies
{
    public interface ITextUtility
    {
        
        public string Base64Decode(string base64Decode);
        public string Base64Encode(string planText);
    }
}
