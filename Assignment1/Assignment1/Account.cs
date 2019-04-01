using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment1
{
    /*
     * This class controls the screens and validation for the account level screens.
     * It hangs onto the LedgerRepository and calls upon it when it needs to.
     */
    class Account
    {
        private static String someBlanks = "                             ";
        private static string theErrorMessage = "";
        private static LedgerRepository theLedgerRepository;
        private static string accountNumber;
        private static string userEnteredTransactionDate = null;
        private static string firstDateOfThisYear = "01/01/2019";
        private static string theDateFormat = "MM/dd/yyyy";
        private static string invalidDateMessage = "That is an invalid date.";
        private static string transactionDatePrompt = "Please enter a transaction date in the format " + theDateFormat + ".";
        private static string theExitPrompt = "Please enter \"x\" to exit.";
        private static string theTransactionAmountPrompt = "Now, enter a transaction amount.";
        private static string theTransactionSuccessMessage = "The transaction has been completed.";
        private static int sleepTime = 5000;

        public static void Menu(LedgerRepository aLedgerRepository, string theAccountNumber)
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
                        runAddDepositWithdrawalScreen(true);
                        break;
                    case "2":
                        runAddDepositWithdrawalScreen(false);
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
            decimal theBalance = 0;
            displayCheckBalanceScreen(theBalance);
            bool keepRunning = true;
            while (keepRunning)
            {
                string theInputValue = Console.ReadLine();
                theErrorMessage = "";
                if ("x".Equals(theInputValue))
                {
                    keepRunning = false;
                }
                else {
                    if (getJulianforGregorian(theInputValue) > 0)
                    {
                        userEnteredTransactionDate = theInputValue;
                        theBalance = theLedgerRepository.getAccountBalance(accountNumber, getJulianforGregorian(theInputValue));
                    }
                    else
                    {
                        theErrorMessage = invalidDateMessage;
                    }
                }
                displayCheckBalanceScreen(theBalance);
                userEnteredTransactionDate = null;
            }
        }
        private static void runAddDepositWithdrawalScreen(bool isDeposit)
        {
            decimal theBalance = 0;
            if (isDeposit)
            {
                displayAddDepositScreen();
            }
            else
            {
                displayAddWithdrawalScreen();
            }
            
            bool keepRunning = true;
            while (keepRunning)
            {
                string theInputValue = Console.ReadLine();
                theErrorMessage = "";
                if ("x".Equals(theInputValue))
                {
                    keepRunning = false;
                }
                else
                {
                    int theTransactionDate = getJulianforGregorian(theInputValue);
                    if (theTransactionDate > 0)
                    {
                        userEnteredTransactionDate = theInputValue;
                        theBalance = theLedgerRepository.getAccountBalance(accountNumber, getJulianforGregorian(theInputValue));
                        Console.WriteLine(someBlanks + theTransactionAmountPrompt);
                        bool keepRunningForAmount = true;
                        while (keepRunningForAmount)
                        {
                            string theAmountInputValue = Console.ReadLine();
                            try
                            {
                                decimal theTransactionAmount = decimal.Parse(theAmountInputValue);
                                string theReturnValueForAdd = null;
                                if (isDeposit)
                                {
                                    theReturnValueForAdd = theLedgerRepository.addDeposit(accountNumber, theTransactionDate, theTransactionAmount);
                                }
                                else
                                {
                                    theReturnValueForAdd = theLedgerRepository.addWithdrawal(accountNumber, theTransactionDate, theTransactionAmount);
                                }
                                if (theReturnValueForAdd == null)
                                {
                                    presentSuccessfulTransactionMessage();
                                }
                                else
                                {
                                    presentRedText(theReturnValueForAdd);
                                    Thread.Sleep(sleepTime);
                                }
                                keepRunningForAmount = false;
                                keepRunning = false;
                            }
                            catch (Exception anex)
                            {
                                userEnteredTransactionDate = null;
                                keepRunningForAmount = false;
                            }
                        }
                    }
                    else
                    {
                        theErrorMessage = invalidDateMessage;
                    }
                }
                if (isDeposit)
                {
                    displayAddDepositScreen();
                }
                else
                {
                    displayAddWithdrawalScreen();
                }
                userEnteredTransactionDate = null;
            }
        }
        
        private static void presentSuccessfulTransactionMessage()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(someBlanks + theTransactionSuccessMessage);
            Console.ForegroundColor = ConsoleColor.Green;
            Thread.Sleep(sleepTime);
        }
        private static int getJulianforGregorian(string aDate)
        {
            int aReturnValue = 0;
            DateTime aFirstDateDateTime = DateTime.ParseExact(firstDateOfThisYear, theDateFormat, System.Globalization.CultureInfo.InvariantCulture);
            Transaction theLastTransaction = theLedgerRepository.getLastTransactionForAnAccount(accountNumber);
            int theLastDateJulian = theLastTransaction.getTransactionDate();
            int daysDifference = theLastDateJulian - 1;
            DateTime theVeryLastDateTime = aFirstDateDateTime.AddDays(daysDifference);
            try
            {
                DateTime aDateTime = DateTime.ParseExact(aDate, theDateFormat, System.Globalization.CultureInfo.InvariantCulture);
                TimeSpan aTimeSpan = (aDateTime.Subtract(theVeryLastDateTime));
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
        private static void displayCheckBalanceScreen(decimal theBalance)
        {
            Console.Clear();
            addTopMargin();
            presentRedText(theErrorMessage);
            if (userEnteredTransactionDate != null)
            {
                Console.WriteLine(someBlanks + "Here is your balance: " + theBalance.ToString("C"));
            }
            else
            {
                Console.WriteLine(someBlanks + transactionDatePrompt);                
            }
            Console.WriteLine(someBlanks + theExitPrompt);
            Console.WriteLine();
            theErrorMessage = "";
        }
        private static void displayAddDepositScreen()
        {
            Console.Clear();
            addTopMargin();
            presentRedText(theErrorMessage);
            Console.WriteLine(someBlanks + "Enter transaction details for deposit.");
            if (userEnteredTransactionDate != null)
            {
                //Console.WriteLine(someBlanks + "Here is your balance: " + theBalance);
            }
            else
            {
                Console.WriteLine(someBlanks + transactionDatePrompt);
            }
            Console.WriteLine(someBlanks + theExitPrompt);
            Console.WriteLine();
            theErrorMessage = "";
        }
        private static void displayAddWithdrawalScreen()
        {
            Console.Clear();
            addTopMargin();
            presentRedText(theErrorMessage);
            Console.WriteLine(someBlanks + "Enter transaction details for withdrawal.");
            if (userEnteredTransactionDate != null)
            {
                //Console.WriteLine(someBlanks + "Here is your balance: " + theBalance);
            }
            else
            {
                Console.WriteLine(someBlanks + transactionDatePrompt);
            }
            Console.WriteLine(someBlanks + theExitPrompt);
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
        private static void presentRedText(string theText)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(someBlanks + theText);
            Console.ForegroundColor = ConsoleColor.Green;
        }
    }
}
