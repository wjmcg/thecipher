using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciphers
{
    public class EncryptRotate : RotationCipher, IStringEncryptor
    {

        public EncryptRotate(int rotation) : base(rotation)
        { }

        public string Map(string s)
        {
            return "Encrypted!";
        }
    }
}
