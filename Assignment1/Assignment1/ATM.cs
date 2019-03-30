using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class ATM
    {
        private static String someBlanks = "                             ";
        private static ArrayList myList = new ArrayList();
        private static string theErrorMessage = "";

        static void Main(string[] args)
        {
            init();
           
            displayMenuScreen();
            while (1 == 1)
            {
                string theInputValue = Console.ReadLine();
                if (isAccountInList(theInputValue))
                {
                    optionsMenu();
                }
                else
                {
                    theErrorMessage = "The account number you entered is invalid.";
                }
                displayMenuScreen();
            }
        }
        private static void optionsMenu()
        {
            displayOptionsScreen();
            while (1 == 1)
            {
                string theInputValue = Console.ReadLine();
                if (isAccountInList(theInputValue))
                {
                    Console.WriteLine("working");
                    Thread.Sleep(5000);
                }
                else
                {
                    theErrorMessage = "The account number you entered is invalid.";
                }
                displayMenuScreen();
            }
        }
        private static void displayOptionsScreen()
        {
            /*
1.	Deposit
2.	Withdraw
3.	Check Balance
4.	Exit – this will bust out of loop and take you back to the Top Menu in ATM

    */
            Console.Clear();
            addTopMargin();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(someBlanks + theErrorMessage);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(someBlanks + "1. Deposit");
            Console.WriteLine(someBlanks + "2. Withdraw");
            Console.WriteLine(someBlanks + "3. Check Balance");
            Console.WriteLine(someBlanks + "4. Exit")
            Console.WriteLine();
            theErrorMessage = "";
        }
        private static void displayMenuScreen()
        {
            Console.Clear();
            addTopMargin();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(someBlanks + theErrorMessage);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(someBlanks + "Welcome to Niki's ATM!");
            Console.WriteLine(someBlanks + "Please enter your account number.");
            Console.WriteLine(someBlanks + "Your valid account numbers are 0, 1, and 2.");
            Console.WriteLine();
            theErrorMessage = "";
        }
        private static bool isAccountInList(string inputvalue)
        {
            bool theReturnValue = false;
            foreach (string item in myList)
            {
                if (item.Equals(inputvalue))
                {
                    theReturnValue = true;
                }
            }
            return theReturnValue;
        }
        private static void init()
        {
            myList.Add("0");
            myList.Add("1");
            myList.Add("2");
        }
        private static void addTopMargin()
        {
            for (int linecount = 1; linecount < 10; linecount++)
            {
                Console.WriteLine();
            }
        }
    }
}
