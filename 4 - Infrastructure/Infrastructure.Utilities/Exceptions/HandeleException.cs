using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Utilities.Exceptions
{
    public class HandeleException : Exception
    {
        private readonly int code;

        public HandeleException(int code, string msg) : base(msg)
        {
            this.code = code;
        }
        public int getCode() => code;
    }
}
