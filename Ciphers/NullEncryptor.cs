using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciphers
{
    public class NullEncryptor : IStringEncryptor
    {
        private readonly string message;

        public NullEncryptor(string message)
        {
            this.message = message;
        }

        public string Map(string s)
        {
            return message;
        }
    }
}
