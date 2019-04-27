using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment2
{
    [Serializable]
    public class Employee
    {
        protected bool isFilledOut;
        protected String someBlanks = "                             ";
        protected string theErrorMessage;
        private int sleepTime = 1000;
        /*********************
             Attributes
        *********************/
        protected float rate = 30.0f;
        protected float taxrate = 0.2f;
        protected int hours = 45;
        protected float gross = 0.0f;
        protected float tax = 0.0f;
        protected float net = 0.0f;
        protected float net_percent = 0.0f;

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
        protected void presentSuccessfulTransactionMessage(string theTransactionSuccessMessage)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(someBlanks + theTransactionSuccessMessage);
            Console.ForegroundColor = ConsoleColor.Green;
            Thread.Sleep(sleepTime);
        }
        private void selectEmployeeDetails()
        {
            displayEmployeeDetails();
            bool keepRunning = true;
            while (keepRunning)
            {
                string theInputValue = Console.ReadLine();
                switch (theInputValue)
                {
                    case "x":
                        keepRunning = false;
                        break;
                    default:
                        theErrorMessage = "Please enter a valid menu option.";
                        break;
                }
                displayEmployeeDetails();
            }
        }
        private void displayEmployeeDetails()
        {
            displayEmployeeDetailsHeader();
        }
        private void displayEmployeeDetailsHeader()
        {
            Console.Clear();
            addTopMargin();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(someBlanks + theErrorMessage);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(someBlanks + "Employee Details screen");
            Console.WriteLine();
            theErrorMessage = "";
        }
    }
}
