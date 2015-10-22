using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace structuredCode
{
    //Right Version
    class Phone
    {

        public string phoneNumber;
        public int size;
        Dictionary<string, string> savedNumbers = new Dictionary<string, string>();

        private Dictionary<string, string> FormatPhoneBook(string toClean)
        {
            string temp = toClean.Replace("{", "").Replace("}", "");
            Dictionary<string, string> returnValue = new Dictionary<string, string>();
            List<string> tempPhoneBook = temp.Split(';').ToList();
            foreach (var item in tempPhoneBook)
            {
                string[] tempVal = item.Split('=');
                returnValue.Add(tempVal[0], tempVal[1]);
            }
            return returnValue;
        }

        public Phone()
        {
            phoneNumber = "";
            size = 0;
            string numbersFromConfig = ConfigurationManager.AppSettings["StoredNumbers"].ToString();
            savedNumbers = FormatPhoneBook(numbersFromConfig);
        }

        public string RemoveCharacters(string phoneNumber)
        {
            for (int i = 1; i < phoneNumber.Length; i++)
            {
                if (phoneNumber.Contains("(") || phoneNumber.Contains(")") || phoneNumber.Contains("-") || phoneNumber.Contains(" "))
                {
                    phoneNumber = phoneNumber.Replace("(", "");
                    phoneNumber = phoneNumber.Replace(")", "");
                    phoneNumber = phoneNumber.Replace("-", "");
                    phoneNumber = phoneNumber.Replace(" ", "");
                }
            }
            return phoneNumber;
        }

        public void GetPhoneNumber(string phoneNumber)
        {
            while (size < 10)
            {
                size = phoneNumber.Length;

                if (size != 10 || size > 10)
                {
                    Console.WriteLine("Entered nubmers should be 10 digits long");
                    Console.WriteLine("\nPlease enter the number you wish to dial");
                    phoneNumber = Console.ReadLine();
                    phoneNumber = RemoveCharacters(phoneNumber);
                    size = 0;
                }
                else
                {
                    checkCode(phoneNumber);
                }
            }
        }

        public void checkCode(string phoneNum)
        {
            if (phoneNum.StartsWith("012") || phoneNum.StartsWith("083") || phoneNum.StartsWith("069") ||
                phoneNum.StartsWith("011") || phoneNum.StartsWith("072") || phoneNum.StartsWith("073"))
            {
                successfullyDial(phoneNum);
            }
            else
            {
                Console.WriteLine("Only numbers starting with 012 , 011, 083, 072, 069 and 073 are allowed");
                Console.WriteLine("\nPlease enter the number you wish to dial");
                phoneNum = Console.ReadLine();
                size = 0;
                phoneNum = RemoveCharacters(phoneNum);
                GetPhoneNumber(phoneNum);
            }
        }

        public void successfullyDial(string phoneNumber)
        {
            if (phoneNumber.All(Char.IsDigit))
            {
                if (savedNumbers.ContainsKey(phoneNumber))
                {
                    Console.WriteLine("Successfully dialed {" + savedNumbers[phoneNumber] + "}");
                }
                else
                {
                    Console.WriteLine("Successfully dialed {" + phoneNumber + "}");
                }
            }
            else
            {
                Console.WriteLine("Invalid number, Please use numeric digits only.");
                size = 0;
            }
        }

    }
}
