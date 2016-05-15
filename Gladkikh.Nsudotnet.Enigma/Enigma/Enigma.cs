using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace Gladkikh.Nsudotnet.Enigma
{
    class Enigma
    {
        public static void encrypt(string inputFile, string _algorithm, string outputFile)
        {
            var algorithm = getAlgorithmName(_algorithm);

            algorithm.GenerateKey();
            algorithm.GenerateIV();
            
            byte[] rgbKey = algorithm.Key;
            byte[] rgbIV = algorithm.IV;
            string base64rgbKey = Convert.ToBase64String(rgbKey);
            string base64rgbIV = Convert.ToBase64String(rgbIV);

            var encryptor = algorithm.CreateEncryptor(rgbKey, rgbIV);

            using (var outputFileStream = new FileStream(outputFile, FileMode.Create))
            {
                using (var cryptoStream = new CryptoStream(outputFileStream, encryptor, CryptoStreamMode.Write))
                {
                    using (var inputFileStream = new FileStream(inputFile, FileMode.Open))
                    {
                        inputFileStream.CopyTo(cryptoStream);
                    }
                }
            }

            string path = Path.GetDirectoryName(inputFile);
            string keyFilePath = Path.Combine(path, "file.key.txt");
            string[] info = {base64rgbKey, base64rgbIV};
            File.WriteAllLines(keyFilePath, info);
        }

        public static void decrypt(string inputFile, string _algorithm, string keyFile, string outputFile)
        {
            var cryptAlgorithm = getAlgorithmName(_algorithm);

            string[] info = File.ReadAllLines(keyFile);
            byte[]rgbKkey = Convert.FromBase64String(info[0]);
            byte[] rgbIV = Convert.FromBase64String(info[1]);
                    
            var decryptor = cryptAlgorithm.CreateDecryptor(rgbKkey, rgbIV);

            using (var inputFileStream = new FileStream(inputFile, FileMode.Open))
            {
                using (var outputFileStream = new FileStream(outputFile, FileMode.Create))
                {
                    using (
                        var cryptoStream = new CryptoStream(inputFileStream, decryptor, CryptoStreamMode.Read))
                    {
                        cryptoStream.CopyTo(outputFileStream);
                    }
                }
            }
        }

        private static SymmetricAlgorithm getAlgorithmName(string _algorithm)
        {
            SymmetricAlgorithm algorithm;
            
            switch (_algorithm)
            {
                case "aes":
                    algorithm = new AesManaged();
                    break;
                case "des":
                    algorithm = new DESCryptoServiceProvider();
                    break;
                case "rc2":
                    algorithm = new RC2CryptoServiceProvider();
                    break;
                case "rijndael":
                    algorithm = new RijndaelManaged();
                    break;
                default:
                    Console.WriteLine("Wrong algorithm name. Type, please, one from this: aes, des, rc2, rijndael");
                    return null;
            }
            return algorithm;
        }
    }
}
