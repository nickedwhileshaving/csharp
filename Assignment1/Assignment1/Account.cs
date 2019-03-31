﻿using System;
using System.Collections;
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
        private static LedgerRepository theLedgerRepository;
        private static string accountNumber;
        private static string userEnterTransactionDate = null;
        private static string firstDateOfThisYear = "01/01/2019";
        private static string theDateFormat = "MM/dd/yyyy";
        
        public static void optionsMenu(LedgerRepository aLedgerRepository, string theAccountNumber)
        {
            accountNumber = theAccountNumber;
            theLedgerRepository = aLedgerRepository;
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
            double theBalance = theLedgerRepository.getAccountBalance(accountNumber, 100);
            displayCheckBalanceScreen(theBalance);
            bool keepRunning = true;
            while (keepRunning)
            {
                string theInputValue = Console.ReadLine();
                //userEnterTransactionDate
                theErrorMessage = "";
                if ("x".Equals(theInputValue))
                {
                    keepRunning = false;
                }
                else {
                    if (getJulianforGregorian(theInputValue) > 0)
                    {
                        theErrorMessage = getJulianforGregorian(theInputValue) + "";
                    }
                    else
                    {
                        theErrorMessage = "That is an invalid date.";
                    }
                }
                displayCheckBalanceScreen(theBalance);
            }
        }
        private static int getJulianforGregorian(string aDate)
        {
            int aReturnValue = 0;
            DateTime aFirstDateDateTime = DateTime.ParseExact(firstDateOfThisYear, theDateFormat, System.Globalization.CultureInfo.InvariantCulture);
            try
            {

                DateTime aDateTime = DateTime.ParseExact(aDate, theDateFormat, System.Globalization.CultureInfo.InvariantCulture);
                TimeSpan aTimeSpan = (aDateTime.Subtract(aFirstDateDateTime));
                if (aTimeSpan.Hours >= 0)
                {
                    aReturnValue = aTimeSpan.Days + 1;
                }
            }
            catch (Exception x)
            {

            }
            return aReturnValue;
        }
        private static void displayCheckBalanceScreen(double theBalance)
        {
            Console.Clear();
            addTopMargin();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(someBlanks + theErrorMessage);
            Console.ForegroundColor = ConsoleColor.Green;
            if (userEnterTransactionDate != null)
            {
                Console.WriteLine(someBlanks + "Here is your balance: " + theBalance);
            }
            else
            {
                Console.WriteLine(someBlanks + "Please enter a transaction date in the format " + theDateFormat + ".");                
            }
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
