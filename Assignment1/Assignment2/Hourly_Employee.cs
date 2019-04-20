using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2
{
    class Hourly_Employee : Employee
    {
        
        public new void menu()
        {
            displayScreen();
            bool keepRunning = true;
            while (keepRunning)
            {
                string theInputValue = Console.ReadLine();
                switch (theInputValue.ToLower())
                {
                    case "h":
                        Hourly_Employee anHourlyEmployee = new Hourly_Employee();
                        anHourlyEmployee.menu();
                        break;
                    case "x":
                        keepRunning = false;
                        break;
                    default:
                        theErrorMessage = "Please enter a valid menu option.";
                        break;
                }
                displayScreen();
            }
        }
        private void displayScreen()
        {
            Console.Clear();
            addTopMargin();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(someBlanks + theErrorMessage);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(someBlanks + "Enter");
            Console.WriteLine(someBlanks + "E(X)it");
            Console.WriteLine();
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
