using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    [Serializable]
    class Salary_Employee : Employee
    {
        public new void menu()
        {
            displayScreen();
            Console.WriteLine(someBlanks + "Are you (S)taff or an (E)xecutive?");
            bool keepRunning = true;
            while (keepRunning)
            {
                string theInputValue = Console.ReadLine();
                if (theInputValue.ToLower().Equals("x"))
                {
                    keepRunning = false;
                }
                else
                {
                    if (theInputValue.ToLower().Equals("s"))
                    {
                        this.gross = 50000;
                    }
                    else
                    {
                        this.gross = 100000;
                    }
                    presentSuccessfulTransactionMessage("The Salary Employee has been added.");
                    this.isFilledOut = true;
                    keepRunning = false;
                }
            }
        }
        private void displayScreen()
        {
            Console.Clear();
            addTopMargin();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(someBlanks + theErrorMessage);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(someBlanks + "Welcome to the Salary Employee Screen or 'X' to exit.");
            theErrorMessage = "";
        }
        public new void computeGross()
        {
           
        }

        public new void computeTax()
        {
            
        }

        public new void computeNet()
        {
            
        }

        public new void computeNetperc()
        {
            
        }
        public new void selectEmployeeDetails()
        {
            base.selectEmployeeDetails();
        }
        protected override void displayEmployeeDetails()
        {
            displayEmployeeDetailsHeader();
/*
 *         protected float rate = 30.0f;
        protected float taxrate = 0.2f;
        protected int hours = 45;
        protected float gross = 0.0f;
        protected float tax = 0.0f;
        protected float net = 0.0f;
        protected float net_percent = 0.0f;
        */
            Console.WriteLine(someBlanks + "Welcome to the Salary Employee Screen");
            Console.WriteLine(someBlanks + "Calculate Gross Pay : " + gross);
            Console.WriteLine(someBlanks + "Calculate Net Pay : " + net);
            Console.WriteLine(someBlanks + "Calculate Net Percent : " + net_percent);
            Console.WriteLine(someBlanks + "Display Employee : ");
            Console.WriteLine();
        }
    }
}
