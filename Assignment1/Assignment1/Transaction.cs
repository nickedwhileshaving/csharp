﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    /*
     * This class is a holder of a single transaction and it's data.  
     * It does nothing
     */
    class Transaction
    {
        private string accountNumber;
        private int transactionDate;
        private double transactionAmount;
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
        public double getTransactionAmount()
        {
            return this.transactionAmount;
        }
        public Transaction setTransactionAmount(double theValue)
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
