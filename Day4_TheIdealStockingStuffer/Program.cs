using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Day4_TheIdealStockingStuffer
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isNumberFound = false;

            decimal number = 0;

            while (!isNumberFound)
            {


                string source = "bgvyzdsv" + number.ToString();


                using (MD5 md5Hash = MD5.Create())
                {
                    string hash = GetMd5Hash(md5Hash, source);

                    if (hash.StartsWith("000000"))
                    {
                        Console.WriteLine("The MD5 hash of " + source + " is: " + hash + ".");
                        Console.WriteLine("Verifying the hash...");

                        if (VerifyMd5Hash(md5Hash, source, hash))
                        {
                            Console.WriteLine("The hashes are the same.");
                        }
                        else
                        {
                            Console.WriteLine("The hashes are not same.");
                        }

                        isNumberFound = true;
                    }

                    else
                        ++number;
                }  
            }
           



        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



    }
}
