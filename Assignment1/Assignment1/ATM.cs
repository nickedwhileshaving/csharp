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
        private static ConsoleColor theBeginningConsoleColor;
        private static LedgerRepository theLedgerRepository;
        private static string fileLocation;

        static void Main(string[] argumentArray)
        {
            theBeginningConsoleColor = Console.ForegroundColor;
            fileLocation = null;
            if (argumentArray.Length > 0)
            {
                fileLocation = argumentArray[0];
            }
            if (fileLocation != null)
            {
                TopMenu();
            }
            else
            {
                Console.WriteLine("Please pass in the file location where the transactions will be stored.");
            }
            Console.ForegroundColor = theBeginningConsoleColor;
        }
        private static void TopMenu()
        {
            displayMenuScreen();
            bool keepRunning = true;
            while (keepRunning)
            {
                string theInputValue = Console.ReadLine();
                switch (theInputValue)
                {
                    case "1":
                        firstTime();
                        break;
                    case "2":
                        chooseAccounts();
                        break;
                    case "3":
                        keepRunning = false;
                        if (theLedgerRepository != null)
                        {
                            theLedgerRepository.commitToFile();
                        }
                        break;
                    default:
                        theErrorMessage = "Please enter a valid menu option.";
                        break;
                }
                displayMenuScreen();
            }
        }
        private static void firstTime()
        {
            init();
            theLedgerRepository = new LedgerRepository(fileLocation, myList, true);
            theErrorMessage = "Everything has been initialized.";
        }
        private static void chooseAccounts()
        {
            theLedgerRepository = new LedgerRepository(fileLocation, myList, false);
            displayAccountsScreen();
            bool keepRunning = true;
            while (keepRunning)
            {
                string theInputValue = Console.ReadLine();
                switch (theInputValue)
                {
                    case "1":
                    case "2":
                    case "3":
                        string theacct = theInputValue;
                        Account.optionsMenu(theLedgerRepository, theInputValue);
                        break;
                    case "4":
                        keepRunning = false;
                        break;
                    default:
                        theErrorMessage = "Please enter a valid account number.";
                        break;
                }
                displayAccountsScreen();
            }
        }
        private static void displayAccountsScreen()
        {
            Console.Clear();
            addTopMargin();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(someBlanks + theErrorMessage);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(someBlanks + "Please enter your account number.");
            Console.WriteLine(someBlanks + "1. Account #1");
            Console.WriteLine(someBlanks + "2. Account #2");
            Console.WriteLine(someBlanks + "3. Account #3");
            Console.WriteLine(someBlanks + "4. Exit");
            Console.WriteLine();
            theErrorMessage = "";
        }
        private static void displayCheckBalanceScreen()
        {
            Console.Clear();
            addTopMargin();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(someBlanks + theErrorMessage);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(someBlanks + "Here is your balance.");
            Console.WriteLine(someBlanks + "Please enter \"x\" to exit.");
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
            Console.WriteLine(someBlanks + "Please enter a number corresponding to the numbers below.");
            Console.WriteLine(someBlanks + "1. First Time");
            Console.WriteLine(someBlanks + "2. Choose Accounts");
            Console.WriteLine(someBlanks + "3. Exit");
            //Console.WriteLine(someBlanks + "Please enter your account number.");
            //Console.WriteLine(someBlanks + "Your valid account numbers are 0, 1, and 2.");
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
            myList.Add("1");
            myList.Add("2");
            myList.Add("3");
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
