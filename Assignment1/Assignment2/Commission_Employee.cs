using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Commission_Employee : Employee
    {
        private int numberOfItemsSold;
        private decimal unitPriceOfItem;

        public new void menu()
        {
            displayScreen();
            Console.WriteLine(someBlanks + "Enter the number of items sold");
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
                    this.numberOfItemsSold = Int32.Parse(theInputValue);
                    Console.WriteLine(someBlanks + "Enter the unit price of items sold");
                    while (keepRunning)
                    {
                        theInputValue = Console.ReadLine();
                        this.unitPriceOfItem = Convert.ToDecimal(theInputValue);
                        presentSuccessfulTransactionMessage("The Commission Employee has been added.");
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
            Console.WriteLine(someBlanks + "Welcome to the Commission Employee Screen or 'X' to exit.");
            Console.WriteLine(someBlanks + "Or 'X' to exit n.");
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
