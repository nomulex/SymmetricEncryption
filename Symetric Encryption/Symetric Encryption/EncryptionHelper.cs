using System;
using System.IO;
using System.Security.Cryptography;

namespace Symetric_Encryption
{
    public class EncryptionHelper
    {
         
            private static readonly byte[] Key = { 23, 120, 45, 56, 35, 56, 78, 87, 103, 107, 17, 76, 10, 96, 42, 90 };

            private static readonly byte[] InitialisationVector ={26, 19, 18, 90, 117, 17, 87, 43, 23, 103, 11, 44, 18, 113, 93, 14};

            public static string Decrypt(byte[] str)
            {
                string decryptedString = null;
                try
                {
                    using (Aes aes = Aes.Create())
                    {
                        aes.Key = Key;
                        aes.IV = InitialisationVector;

                        ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);


                        using (MemoryStream msDecrypt = new MemoryStream(str))
                        {
                            using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                            {
                                using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                                {

                                    // Read the decrypted bytes from the decrypting stream
                                    // and place them in a string.
                                    decryptedString = srDecrypt.ReadToEnd();
                                }
                            }
                        }

                    }
                }
                catch (Exception e)
                {
                 //handle exceptions 

                }
                return decryptedString;
            }

            public static byte[] Encrypt(string str)
            {


                byte[] encrypted;

                try
                {
                    using (Aes aes = Aes.Create())
                    {
                        aes.Key = Key;
                        aes.IV = InitialisationVector;
                        ICryptoTransform encryptor = aes.CreateEncryptor(Key, aes.IV);
                        using (MemoryStream msEncrypt = new MemoryStream())
                        {
                            using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                            {
                                using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                                {

                                    //Write all data to the stream.
                                    swEncrypt.Write(str);
                                }
                                encrypted = msEncrypt.ToArray();

                            }
                        }

                    }
                    return encrypted;
                }
                catch (Exception e)
                {
           // Log exceptions if any 

                }



                return new byte[] { };


            }
        }

    }
