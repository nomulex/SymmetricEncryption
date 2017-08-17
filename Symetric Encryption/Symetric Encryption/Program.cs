using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Symetric_Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter string to encrypt:");

            string str = Console.ReadLine();

           Console.WriteLine("You wrote: \n {0}",str);
            var encrypted = Convert.ToBase64String(EncryptionHelper.Encrypt(str)); 
           Console.WriteLine("{0} Encrypted to base 64 string is {1} \n",str, encrypted);
            var decrypted = EncryptionHelper.Decrypt(Convert.FromBase64String(encrypted)); 
           Console.WriteLine("{0} Decrypted back is {1} \n", encrypted, decrypted);

            Console.WriteLine("Press enter to exit");

            string st = Console.ReadLine();


        }
    }
}
