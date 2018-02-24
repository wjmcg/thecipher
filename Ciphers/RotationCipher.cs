using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciphers
{
    public abstract class RotationCipher
    {
        private readonly int offset;

        public RotationCipher(int offset)
        {
            this.offset = offset;
        }

        public string Map(string s)
        {
            StringBuilder sb = new StringBuilder();
            foreach(char character in s) sb.Append(Map(character));
            return sb.ToString();
        }

        public char Map(char input)
        {
            return input;
        }

    }
}
