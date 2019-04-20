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
    }
}
