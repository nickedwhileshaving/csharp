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
