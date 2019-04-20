﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
   public class Employee
        {
        protected bool isFilledOut;
        protected String someBlanks = "                             ";
        protected string theErrorMessage;
        /*********************
             Attributes
        *********************/
        float rate = 30.0f;
        float taxrate = 0.2f;
        int hours = 45;
        float gross = 0.0f;
        float tax = 0.0f;
        float net = 0.0f;
        float net_percent = 0.0f;

        //End Attributes

        /********************
            Constructors
    ********************/
        public Employee()
        {

        }

        /********************
                Methods
        ********************/
        public void menu()
        {

        }

        public void computeGross()
        {
            gross = rate * hours;
        }

        public void computeTax()
        {
            tax = gross * taxrate;
        }

        public void computeNet()
        {
            net = gross - tax;
        }

        public void computeNetperc()
        {
            net_percent = (net / gross) * 100;
        }

        public void displayEmployee()
        {
            Console.WriteLine("Hours: " + hours);
            Console.WriteLine("Rate: " + rate);
            Console.WriteLine("Gross: " + gross);
            Console.WriteLine("Net: " + net);
            Console.WriteLine("Net%: " + net_percent + "%");
        }
        protected void addTopMargin()
        {
            for (int linecount = 1; linecount < 10; linecount++)
            {
                Console.WriteLine();
            }
        }

        public bool getIsFilledOut()
        {
            return isFilledOut;
        }

        protected void setIsFilledOut(bool pIsFilledOut)
        {
            isFilledOut = pIsFilledOut;
        }
    }
}
