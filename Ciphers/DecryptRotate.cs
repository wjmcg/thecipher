using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciphers
{
    public class DecryptRotate :  RotationCipher, IStringEncryptor
    {
        public DecryptRotate(int rotation) : base(rotation)
        { }

        public string Map(string s)
        {
            return "Decrypted!";
        }
    }
}
