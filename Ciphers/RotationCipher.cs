using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciphers
{
    public class RotationCipher
    {
        private readonly int offset;

        public RotationCipher(int offset)
        {
            this.offset = offset;
        }

    }
}
