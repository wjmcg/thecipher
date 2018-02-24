using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciphers
{
    public class DecryptRotate :  RotationCipher, IEncryptor
    {
        public DecryptRotate(int rotation) : base(-rotation)
        { }
    }
}
