using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    [Serializable]
    class Hourly_Employee : Employee
    {
        public new void menu()
        {
            displayScreen();
            Console.WriteLine(someBlanks + "Enter Hours");
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
                    this.hours = Int32.Parse(theInputValue);
                    Console.WriteLine(someBlanks + "Enter Rate");
                    while (keepRunning)
                    {
                        theInputValue = Console.ReadLine();
                        this.rate = float.Parse(theInputValue, CultureInfo.InvariantCulture.NumberFormat);
                        presentSuccessfulTransactionMessage("The Hourly Employee has been added.");
                        this.isFilledOut = true;
                        keepRunning = false;
                    }
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
            Console.WriteLine(someBlanks + "Welcome to the Hourly Employee Screen or 'X' to exit.");
            theErrorMessage = "";
        }
        public new void selectEmployeeDetails()
        {
            base.selectEmployeeDetails();
        }
        protected override void displayEmployeeDetails()
        {
            displayEmployeeDetailsHeader();
            computeGross();
            computeTax();
            computeNet();
            computeNetperc();
            Console.WriteLine(someBlanks + "Hourly Employee Details");
            Console.WriteLine(someBlanks + "Hours: " + hours + " Pay Rate: " + rate + " Tax Rate: " + taxrate);
            Console.WriteLine(someBlanks + "Calculate Gross Pay : " + gross);
            Console.WriteLine(someBlanks + "Calculate Tax : " + tax);
            Console.WriteLine(someBlanks + "Calculate Net Pay : " + net);
            Console.WriteLine(someBlanks + "Calculate Net Percent : " + net_percent);
            Console.WriteLine();
        }
        public new void computeGross()
        {
            float standardgrosspay;
            float overtimegrosspay = 0f;
            int hoursOverForty = hours - 40;
            standardgrosspay = 40 * rate;
            if (hoursOverForty > 0)
            {
                overtimegrosspay = hoursOverForty * rate * 1.5f;
            }
            gross = standardgrosspay + overtimegrosspay;
        }
    }
}
