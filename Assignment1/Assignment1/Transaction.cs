using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Transaction
    {
        private string accountNumber;
        private int transactionDate;
        private decimal transactionAmount;
        private bool isPositive;
        private string memo;

        public string getAccountNumber()
        {
            return this.accountNumber;
        }
        public Transaction setAccountNumber(string theValue)
        {
            this.accountNumber = theValue;
            return this;
        }
        public int getTransactionDate()
        {
            return this.transactionDate;
        }
        public Transaction setTransactionDate(int theValue)
        {
            this.transactionDate = theValue;
            return this;
        }
        public decimal getTransactionAmount()
        {
            return this.transactionAmount;
        }
        public Transaction setTransactionAmount(decimal theValue)
        {
            this.transactionAmount = theValue;
            return this;
        }
        public bool getIsPositive()
        {
            return this.isPositive;
        }
        public Transaction setIsPositive(bool theValue)
        {
            this.isPositive = theValue;
            return this;
        }
        public string getMemo()
        {
            return this.memo;
        }
        public Transaction setMemo(string theValue)
        {
            this.memo = theValue;
            return this;
        }
    }
}
