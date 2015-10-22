using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace structuredCode
{

    class Phone
    {    
        public string phoneNumber;
        public int size;
        public int found;
        Dictionary<string, string> savedNumbers = new Dictionary<string, string>();
        public string[] savedName;

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
            found = -1;
            string numbersFromConfig = ConfigurationManager.AppSettings["StoredNumbers"].ToString();
            savedNumbers = FormatPhoneBook(numbersFromConfig);
        }
        public Phone(string _phoneNumber, int _size, int _found)
        {
            phoneNumber = _phoneNumber;
            size = _size;
            found = _found;//used to search for the numbers in the phone book
        }
        public string secMethod(string phoneNumber)//this method remove the following characters, ()- and a space from entered phone number 
        {
            for (int i = 1; i < phoneNumber.Length; i++)
            {
                if (phoneNumber.Contains("(") || phoneNumber.Contains(")") || phoneNumber.Contains("-") || phoneNumber.Contains(" "))
                {
                    string tempNumber = phoneNumber.Replace("(", "");
                    phoneNumber = tempNumber;
                    tempNumber = phoneNumber.Replace(")", "");
                    phoneNumber = tempNumber;
                    tempNumber = phoneNumber.Replace("-", "");
                    phoneNumber = tempNumber;
                    tempNumber = phoneNumber.Replace(" ", "");
                    phoneNumber = tempNumber;
                }
            }
            return phoneNumber;
        }
      public void ManipulateContac(string phoneNumber)
        {
            while (size < 10)
            {
                size = phoneNumber.Length;

                if (size != 10 || size > 10)
                {
                    Console.WriteLine("Entered nubmers should be 10 digits long");
                    Console.WriteLine("\nPlease enter the number you wish to dial");
                    phoneNumber = Console.ReadLine();
                    phoneNumber = secMethod(phoneNumber);
                    size = 0;
                }
                else
                {
                    //checking that the number starts with 012 , 011, 083, 072, 069 or 073 only 
                    if (phoneNumber.StartsWith("012") || phoneNumber.StartsWith("083") || phoneNumber.StartsWith("069") ||
                        phoneNumber.StartsWith("011") || phoneNumber.StartsWith("072") || phoneNumber.StartsWith("073"))
                    {
                        //check if the number contains digits only
                        if (phoneNumber.All(Char.IsDigit))
                        {
                            if (savedNumbers.ContainsKey(phoneNumber))
                            {
                                Console.WriteLine("Successfully dialed {" + savedNumbers[phoneNumber] + "}");
                                //fetch the name if the entered number exists in savedNumbers array in the config file
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
                    else
                    {
                        Console.WriteLine("Only numbers starting with 012 , 011, 083, 072, 069 and 073 are allowed");
                        size = 0;
                        Console.WriteLine("\nPlease enter the number you wish to dial");
                        phoneNumber = Console.ReadLine();
                        phoneNumber = secMethod(phoneNumber);

                    }
                }
            }
        }
    }


    class Program
        {
            static void Main(string[] args)
            {
                Phone phoneOBJ = new Phone();
                string phoneNumber;

                Console.WriteLine("\nPlease enter the number you wish to dial");
                phoneNumber = Console.ReadLine();//capture the entered number 
                phoneNumber = phoneOBJ.secMethod(phoneNumber);
                phoneOBJ.ManipulateContac(phoneNumber);/*

            }
        }
        }
    }
    








