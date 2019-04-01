using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{    
    /*
     * This class is responsible for keeping track of all transactions that are in memory
     * for all accounts.
     * It's responsible for reading the previous data from a disk file.  It is responsible
     * for pushing data out to the text file, too.
     */
    class LedgerRepository
    {
        private string delimiter = "|";
        private ArrayList theTransactionList;
        private bool isFirstTime;
        private ArrayList accountList;
        private string filePath;
        private int firstDayOfTheYear = 1;
        private double interestRate = 0.05;

        public LedgerRepository(string filePathParm, ArrayList accountList, bool isFirstTime)
        {
            this.isFirstTime = isFirstTime;
            this.accountList = accountList;
            this.filePath = filePathParm;
            theTransactionList = new ArrayList();
            if (isFirstTime || !File.Exists(filePath))
            {
                createNewTransactionList();
            }
            else
            {
                populateTransactionListFromFile();
            }
        }
        public decimal getAccountBalance(string theAccountNumber, int theTransactionDate)
        {
            calculateInterest(theAccountNumber, theTransactionDate);
            return getBalance(theAccountNumber, theTransactionDate);
        }
        public decimal getBalance(string theAccountNumber,int thetransactionDate)
        {
            ArrayList aNewArrayList = getListForAnAccount(theAccountNumber);
            decimal theBalance = 0;
            foreach (Transaction item in aNewArrayList)
            {
                if (item.getIsPositive())
                {
                    theBalance = theBalance + item.getTransactionAmount();
                }
                else
                {
                    theBalance = theBalance - item.getTransactionAmount();
                }
            }
            return theBalance;
        }
        public string addDeposit(string theAccountNumber, int theTransactionDate, decimal transactionAmount)
        {
            calculateInterest(theAccountNumber, theTransactionDate);
            Transaction aTransaction = new Transaction();
            aTransaction.setAccountNumber(theAccountNumber)
                .setTransactionDate(theTransactionDate)
                .setTransactionAmount(transactionAmount)
                .setIsPositive(true)
                .setMemo("DEPOSIT");
            theTransactionList.Add(aTransaction);
            return null;
        }
        public string addWithdrawal(string theAccountNumber, int transactionDate, decimal transactionAmount)
        {
            calculateInterest(theAccountNumber, transactionDate);
            decimal theBalance = getBalance(theAccountNumber, transactionDate);
            string theReturn = null;
            if (transactionAmount > theBalance)
            {
                theReturn = "There are not enough funds in the account to execute the transaction.";
            }
            else
            {
                Transaction aTransaction = new Transaction();
                aTransaction.setAccountNumber(theAccountNumber)
                    .setTransactionDate(transactionDate)
                    .setTransactionAmount(transactionAmount)
                    .setIsPositive(false)
                    .setMemo("WITHDRAWAL");
                theTransactionList.Add(aTransaction);
            }
            return theReturn;
        }
        public void commitToFile()
        {
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            using (StreamWriter aStreamWriter = File.CreateText(filePath))
            {
                foreach (Transaction anItem in theTransactionList)
                {
                    aStreamWriter.WriteLine(anItem.getAccountNumber() + delimiter +
                        anItem.getTransactionDate() + delimiter +
                        anItem.getTransactionAmount().ToString("0.00") + delimiter +
                        anItem.getIsPositive() + delimiter +
                        anItem.getMemo());
                }
            }
        }
        public Transaction getLastTransactionForAnAccount(string anAccountNumber)
        {
            ArrayList aNewArrayList = getListForAnAccount(anAccountNumber);
            Transaction aTransaction = (Transaction)aNewArrayList[aNewArrayList.Count - 1];
            return aTransaction;
        }
        private ArrayList getListForAnAccount(string accountNumber)
        {
            ArrayList anArrayList = new ArrayList();
            foreach (Transaction item in theTransactionList)
            {
                if (item.getAccountNumber().Equals(accountNumber))
                {
                    anArrayList.Add(item);
                }
            }
            return anArrayList;
        }
        private void calculateInterest(string theAccountNumber, int theTransactionDate)
        {
            Transaction aTransaction = getLastTransactionForAnAccount(theAccountNumber);
            int differenceInDays = theTransactionDate - aTransaction.getTransactionDate();
            if (differenceInDays != 0)
            {
                decimal theCurrentBalance = getBalance(theAccountNumber, theTransactionDate);
                double someIntermediateValue = differenceInDays / (double)365 * Decimal.ToDouble(theCurrentBalance) * interestRate;
                decimal interestTransactionAmount = Decimal.Multiply((decimal)someIntermediateValue,(decimal)someIntermediateValue);
                Transaction anInterestTransaction = new Transaction();
                anInterestTransaction.setAccountNumber(theAccountNumber)
                    .setTransactionAmount(interestTransactionAmount)
                    .setTransactionDate(theTransactionDate)
                    .setIsPositive(true)
                    .setMemo("INTEREST");
                theTransactionList.Add(anInterestTransaction);
            }
        }
        private void populateTransactionListFromFile()
        {
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                //process each record
                //store into  arrayList
                string[] words = line.Split('|');
                Transaction aTransaction = new Transaction();
                aTransaction.setAccountNumber(words[0])
                    .setTransactionDate(Int32.Parse(words[1]))
                    .setTransactionAmount(Convert.ToDecimal(words[2]))
                    .setIsPositive(Convert.ToBoolean(words[3]))
                    .setMemo((words[4]));
                theTransactionList.Add(aTransaction);
                //make sure to use true/false
            }
        }
        private void createNewTransactionList()
        {
            Transaction aTransaction;
            foreach (string item in accountList)
            {
                aTransaction = new Transaction();
                aTransaction.setAccountNumber(item)
                    .setIsPositive(true)
                    .setTransactionAmount(Convert.ToDecimal("100.00"))
                    .setTransactionDate(firstDayOfTheYear)
                    .setMemo("INITIALIZE");
                theTransactionList.Add(aTransaction);
            }
        }
    }
}
