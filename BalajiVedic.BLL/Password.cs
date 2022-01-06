﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Security.Cryptography;
//using System.Security.Cryptography.X509Certificates;

namespace BalajiVedic.BLL
{
    public class Password
    {
        private static byte[] inputVector = { 120, 122, 203, 107, 23, 242, 251, 98, 41, 192, 200, 47, 62, 121, 84, 221 };
        private static byte[] cryptKey = { 33, 228, 79, 4, 144, 123, 222, 191, 113, 198, 227, 25, 162, 142, 105, 176 };

        public static string ComputeHash(string plainText, string hashAlgorithm, byte[] saltBytes)
        {
            // If salt is not specified, generate it.
            if (saltBytes == null)
            {
                // Define min and max salt sizes.
                int minSaltSize = 4;
                int maxSaltSize = 8;

                // Generate a random number for the size of the salt.
                Random random = new Random();
                int saltSize = random.Next(minSaltSize, maxSaltSize);

                // Allocate a byte array, which will hold the salt.
                saltBytes = new byte[saltSize];

                // Initialize a random number generator.
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

                // Fill the salt with cryptographically strong byte values.
                rng.GetNonZeroBytes(saltBytes);
            }

            // Convert plain text into a byte array.
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            // Allocate array, which will hold plain text and salt.
            byte[] plainTextWithSaltBytes =
                    new byte[plainTextBytes.Length + saltBytes.Length];

            // Copy plain text bytes into resulting array.
            for (int i = 0; i < plainTextBytes.Length; i++)
                plainTextWithSaltBytes[i] = plainTextBytes[i];

            // Append salt bytes to the resulting array.
            for (int i = 0; i < saltBytes.Length; i++)
                plainTextWithSaltBytes[plainTextBytes.Length + i] = saltBytes[i];


            HashAlgorithm hash;

            // Make sure hashing algorithm name is specified.
            if (hashAlgorithm == null)
                hashAlgorithm = "";

            // Initialize appropriate hashing algorithm class.
            switch (hashAlgorithm.ToUpper())
            {

                case "SHA384":
                    hash = new SHA384Managed();
                    break;

                case "SHA512":
                    hash = new SHA512Managed();
                    break;

                default:
                    hash = new MD5CryptoServiceProvider();
                    break;
            }

            // Compute hash value of our plain text with appended salt.
            byte[] hashBytes = hash.ComputeHash(plainTextWithSaltBytes);

            // Create array which will hold hash and original salt bytes.
            byte[] hashWithSaltBytes = new byte[hashBytes.Length +
                                                saltBytes.Length];

            // Copy hash bytes into resulting array.
            for (int i = 0; i < hashBytes.Length; i++)
                hashWithSaltBytes[i] = hashBytes[i];

            // Append salt bytes to the result.
            for (int i = 0; i < saltBytes.Length; i++)
                hashWithSaltBytes[hashBytes.Length + i] = saltBytes[i];

            // Convert result into a base64-encoded string.
            string hashValue = Convert.ToBase64String(hashWithSaltBytes);

            // Return the result.
            return hashValue;
        }

        public static bool VerifyHash(string plainText, string hashAlgorithm, string hashValue)
        {

            // Convert base64-encoded hash value into a byte array.
            byte[] hashWithSaltBytes = Convert.FromBase64String(hashValue);

            // We must know size of hash (without salt).
            int hashSizeInBits, hashSizeInBytes;

            // Make sure that hashing algorithm name is specified.
            if (hashAlgorithm == null)
                hashAlgorithm = "";

            // Size of hash is based on the specified algorithm.
            switch (hashAlgorithm.ToUpper())
            {

                case "SHA384":
                    hashSizeInBits = 384;
                    break;

                case "SHA512":
                    hashSizeInBits = 512;
                    break;

                default: // Must be MD5
                    hashSizeInBits = 128;
                    break;
            }

            // Convert size of hash from bits to bytes.
            hashSizeInBytes = hashSizeInBits / 8;

            // Make sure that the specified hash value is long enough.
            if (hashWithSaltBytes.Length < hashSizeInBytes)
                return false;

            // Allocate array to hold original salt bytes retrieved from hash.
            byte[] saltBytes = new byte[hashWithSaltBytes.Length - hashSizeInBytes];

            // Copy salt from the end of the hash to the new array.
            for (int i = 0; i < saltBytes.Length; i++)
                saltBytes[i] = hashWithSaltBytes[hashSizeInBytes + i];

            // Compute a new hash string.
            string expectedHashString = ComputeHash(plainText, hashAlgorithm, saltBytes);

            // If the computed hash matches the specified hash,
            // the plain text value must be correct.
            return (hashValue == expectedHashString);
        }

        public static string GetUniqueKey(int maxSize)
        {
            char[] chars = new char[62];
            //chars ="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890()@#$%^&*-_".ToCharArray();
            chars = "ABCDEFGHIJKLMNPQRSTUVWXYZ123456789".ToCharArray();
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[maxSize];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        } 

        public static string EncryptPassword(string UnEncryptedPassword)
        {
            System.IO.MemoryStream mStream = new System.IO.MemoryStream();
            System.Security.Cryptography.RijndaelManaged RMCrypto = new System.Security.Cryptography.RijndaelManaged();
            System.Security.Cryptography.CryptoStream cStream = new System.Security.Cryptography.CryptoStream(mStream, RMCrypto.CreateEncryptor(cryptKey, inputVector), System.Security.Cryptography.CryptoStreamMode.Write);
            System.IO.StreamWriter SWriter = new System.IO.StreamWriter(cStream);
            SWriter.Write(UnEncryptedPassword);
            SWriter.Flush();
            cStream.FlushFinalBlock();
            mStream.Flush();
            return Convert.ToBase64String(mStream.GetBuffer(), 0, (int)mStream.Length);
        }

        public static string UnEncryptPassword(string EncryptedPassword)
        {
            byte[] bufr = Convert.FromBase64String(EncryptedPassword);
            System.IO.MemoryStream mStream = new System.IO.MemoryStream(bufr);
            System.Security.Cryptography.RijndaelManaged RMCrypto = new System.Security.Cryptography.RijndaelManaged();
            System.Security.Cryptography.CryptoStream cStream = new System.Security.Cryptography.CryptoStream(mStream, RMCrypto.CreateDecryptor(cryptKey, inputVector), System.Security.Cryptography.CryptoStreamMode.Read);
            System.IO.StreamReader sReader = new System.IO.StreamReader(cStream);
            return sReader.ReadToEnd();
        }

        public static string Encrypt(string text)
        {
            text = text.Replace("0", "A0A").Replace("1", "B1B").Replace("2", "C2C").Replace("3", "D3D").Replace("4", "E4E").Replace("5", "F5F").Replace("6", "G6G").Replace("7", "H7H").Replace("8", "I8I").Replace("9", "J9J");
            return text;
        }

        public static string Decrypt(string text)
        {
            text = text.Replace("A0A", "0").Replace("B1B", "1").Replace("C2C", "2").Replace("D3D", "3").Replace("E4E", "4").Replace("F5F", "5").Replace("G6G", "6").Replace("H7H", "7").Replace("I8I", "8").Replace("J9J", "9");
            return text;
        }
    }
}
