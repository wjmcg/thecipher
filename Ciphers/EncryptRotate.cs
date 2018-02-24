using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciphers
{
    public class EncryptRotate : RotationCipher, IEncryptor
    {

        public EncryptRotate(int rotation) : base(rotation)
        { }

    }
}
