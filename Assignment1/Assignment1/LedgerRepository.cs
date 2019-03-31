using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{    
    class LedgerRepository
    {
        private string delimiter = "|";
        private ArrayList theTransactionList;
        private bool isFirstTime;
        private ArrayList accountList;
        private string filePath;
        private int firstDayOfTheYear = 1;
        public LedgerRepository(string filePathParm, ArrayList accountList, bool isParmTime)
        {
            this.isFirstTime = isParmTime;
            this.accountList = accountList;
            this.filePath = filePathParm;
            if (isParmTime || !File.Exists(filePath))
            {
                createNewTransactionList();
            }
            else
            {
                populateTransactionListFromFile();
            }
        }
        public double getBalance(string theAccountNumber)
        {
            ArrayList aNewArrayList = getListForAnAccount(theAccountNumber);
            double theBalance = 0.00;
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
        public string addDeposit(string theAccountNumber, int transactionDate, double transactionAmount)
        {
            Transaction aTransaction = new Transaction(theAccountNumber, transactionDate, transactionAmount, true);
            theTransactionList.Add(aTransaction);
            return null;
        }
        public string addWithdrawal(string theAccountNumber, int transactionDate, double transactionAmount)
        {
            double theBalance = getBalance(theAccountNumber);
            string theReturn = null;
            if (transactionAmount > theBalance)
            {
                theReturn = "There are not enough funds in the account to execute the transaction.";
            }
            else
            {
                Transaction aTransaction = new Transaction(theAccountNumber, transactionDate, transactionAmount, false);
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
            StreamWriter aFile = new StreamWriter(filePath, true);
            foreach (Transaction anItem in theTransactionList)
            {
                aFile.WriteLine(anItem.getAccountNumber() + delimiter +
                    anItem.getTransactionDate() + delimiter +
                    anItem.getTransactionAmount() + delimiter +
                    anItem.getIsPositive());
            }
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
                    .setTransactionAmount(Convert.ToDouble(words[2]))
                    .setIsPositive(Convert.ToBoolean(words[3]));
                theTransactionList.Add(aTransaction);
                //make sure to use true/false
            }
        }
        private void createNewTransactionList()
        {
            theTransactionList = new ArrayList();
            Transaction aTransaction;
            foreach (string item in accountList)
            {
                aTransaction = new Transaction();
                aTransaction.setAccountNumber(item)
                    .setIsPositive(true)
                    .setTransactionAmount(100.00)
                    .setTransactionDate(firstDayOfTheYear);
                theTransactionList.Add(aTransaction);
            }
        }
    }
}
