using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace structuredCode
{
    class MainProgram
    {
        static void Main(string[] args)
        {
            Phone phone = new Phone();
            string phoneNumber;

            Console.WriteLine("\nPlease enter the number you wish to dial");
            phoneNumber = Console.ReadLine();
            phoneNumber = phone.RemoveCharacters(phoneNumber);
            phone.GetPhoneNumber(phoneNumber);
            Console.ReadKey();
        }
    }
}
