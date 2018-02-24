using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciphers
{
    public class NullEncryptor : IEncryptor
    {
        private readonly string message;

        public NullEncryptor(string message)
        {
            this.message = message;
        }

        public string Map(string s) => message;

        public char Map(char s) => s;

    }
}
