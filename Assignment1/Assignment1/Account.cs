﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Account
    {
        private static String someBlanks = "                             ";
        private static string theErrorMessage = "";
        public static void optionsMenu()
        {
            displayOptionsScreen();
            bool keepRunning = true;
            while (keepRunning)
            {
                string theInputValue = Console.ReadLine();
                switch (theInputValue)
                {
                    case "1":
                        runDepositScreen();
                        break;
                    case "2":
                        runWithdrawScreen();
                        break;
                    case "3":
                        runCheckBalanceScreen();
                        break;
                    case "4":
                        keepRunning = false;
                        break;
                    default:
                        theErrorMessage = "Please enter a valid menu option.";
                        break;
                }
                displayOptionsScreen();
            }
        }
        private static void displayOptionsScreen()
        {
            Console.Clear();
            addTopMargin();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(someBlanks + theErrorMessage);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(someBlanks + "Please enter a number corresponding to the numbers below.");
            Console.WriteLine(someBlanks + "1. Deposit");
            Console.WriteLine(someBlanks + "2. Withdraw");
            Console.WriteLine(someBlanks + "3. Check Balance");
            Console.WriteLine(someBlanks + "4. Exit");
            Console.WriteLine();
            theErrorMessage = "";
        }
        private static void runDepositScreen()
        {
            Console.WriteLine("Your dep is");
        }
        private static void runWithdrawScreen()
        {
            Console.WriteLine("Please make your withdrawl.");
        }
        private static void runCheckBalanceScreen()
        {
            displayCheckBalanceScreen();
            bool keepRunning = true;
            while (keepRunning)
            {
                string theInputValue = Console.ReadLine();
                if ("x".Equals(theInputValue))
                {
                    keepRunning = false;
                }
                else
                {
                    theErrorMessage = "Please enter an \"x\"";
                }
                displayCheckBalanceScreen();
            }
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
        private static void addTopMargin()
        {
            for (int linecount = 1; linecount < 10; linecount++)
            {
                Console.WriteLine();
            }
        }
    }
}
