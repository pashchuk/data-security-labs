using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    class Program
    {
        private static RSAParameters _privateKey;
        private static RSAParameters _publicKey;
        static void Main(string[] args)
        {
            var rsa = new RSACryptoServiceProvider();
            _publicKey = rsa.ExportParameters(false);
            _privateKey = rsa.ExportParameters(true);
            Console.WriteLine("\n********* Public key info *******************");
            printInfo(_publicKey);
            Console.WriteLine("\n********* Private key info *******************");
            printInfo(_privateKey);

            var message = "I am a plain text message";
            var messageContent = Encoding.UTF8.GetBytes(message.ToCharArray());

            Console.WriteLine("**** Plain Message ****");
            Console.WriteLine(Encoding.UTF8.GetString(messageContent));

            var encrypter = new RSACryptoServiceProvider();
            encrypter.ImportParameters(_publicKey);
            var encryptedMessage = encrypter.Encrypt(messageContent, true);

            Console.WriteLine("**** Encrypted Message ****");
            Console.WriteLine(Convert.ToBase64String(encryptedMessage));

            var decrypter = new RSACryptoServiceProvider();
            decrypter.ImportParameters(_privateKey);
            var decryptedMessage = decrypter.Decrypt(encryptedMessage, true);

            Console.WriteLine("**** Decrypted Message ****");
            Console.WriteLine(Encoding.UTF8.GetString(decryptedMessage));

        }

        static void printInfo(RSAParameters param)
        {
            Console.WriteLine($"Modulus: {new BigInteger(param.Modulus)}");
            Console.WriteLine($"Exponent: {new BigInteger(param.Exponent)}");
            if (param.P == null) return;
            Console.WriteLine("Private params");
            Console.WriteLine($"P: {new BigInteger(param.P)}");
            Console.WriteLine($"Q: {new BigInteger(param.Q)}");
            Console.WriteLine($"D: {new BigInteger(param.D)}");
            Console.WriteLine($"DP: {new BigInteger(param.DP)}");
            Console.WriteLine($"DQ: {new BigInteger(param.DQ)}");
            Console.WriteLine($"Inverse Q: {new BigInteger(param.InverseQ)}");
        }


    }
}
