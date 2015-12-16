using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputFile = new FileInfo("input.txt");
            var outputFile = new FileInfo("output.txt");
            var decryptedFile = new FileInfo("decrypted.txt");

            // delete files if they already exists
            if (inputFile.Exists) inputFile.Delete();
            if (outputFile.Exists) outputFile.Delete();
            if (decryptedFile.Exists) decryptedFile.Delete();

            // write test data to input file
            using (var writer = new StreamWriter(inputFile.Create()))
                writer.WriteLine("Some plain text which is not already encrypted");

            // initialise des algorithm
            var desProvider = new DESCryptoServiceProvider();

            // get des generated key and initialization vector
            var key = desProvider.Key;
            var initialisationVector = desProvider.IV;
            Console.WriteLine("Key: {0}\n", Convert.ToBase64String(key));

            Console.WriteLine("Begin encryption ...");
            // encrypt data from input file to output file
            using (var inputStream = inputFile.OpenRead())
            using (var encryptor = desProvider.CreateEncryptor(key, initialisationVector))
            using (var cryptostream = new CryptoStream(outputFile.Create(), encryptor, CryptoStreamMode.Write))
            {
                var bytes = new byte[inputStream.Length - 1];
                inputStream.Read(bytes, 0, bytes.Length);
                Console.WriteLine("Data in input file before encryption: {0}", Encoding.UTF8.GetString(bytes));
                cryptostream.Write(bytes, 0, bytes.Length);
            }

            Console.WriteLine("Encryption finished!");

            // print encryption result
            using (var reader = new StreamReader(outputFile.OpenRead()))
                Console.WriteLine("Encryption result: {0}\n\n", reader.ReadToEnd());

            Console.WriteLine("Begin decryption ...");
            // decrypt data from output file to result file
            using (var outputStream = new StreamWriter(decryptedFile.Create()))
            using (var decryptor = desProvider.CreateDecryptor())
            using (var cryptostream = new StreamReader(new CryptoStream(
                    outputFile.OpenRead(), decryptor, CryptoStreamMode.Read)))
                outputStream.Write(cryptostream.ReadToEnd());

            Console.WriteLine("Decryption finished!");

            // print decryption result
            using (var reader = new StreamReader(decryptedFile.OpenRead()))
                Console.WriteLine("Decryption result: {0}", reader.ReadToEnd());

        }
    }
}
