using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciphers.Test
{
    [TestClass]
    public class AcceptanceTests
    {
        [TestMethod]
        public void TestEncryptDecrypt()
        {
            string testString = "This is a test string969692465!*leusndlYHFBSPWP\"";
            int rotation = 3;

            IEncryptor encryptor = new EncryptRotate(rotation);
            IEncryptor decryptor = new DecryptRotate(rotation);

            string encryptedString = encryptor.Map(testString);
            string decryptedString = decryptor.Map(encryptedString);

            Assert.AreEqual(testString, decryptedString, false, "String not equal after encrypt/decrypt");
            Assert.AreNotEqual(encryptedString, decryptedString, false, "Encryption failed as the input and output are the same.");
        }
    }
}
