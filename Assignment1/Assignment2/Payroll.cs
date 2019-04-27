using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Threading;

namespace Assignment2
{
    class Payroll
    {
        public String ID;
        public String Name;
        private string fileLocation;
        private static ConsoleColor theBeginningConsoleColor;
        private ArrayList anEmployeeArrayList;
        private string theErrorMessage;
        private String someBlanks = "                             ";
        private int sleepTime = 3000;

        public Payroll()
        {
             anEmployeeArrayList = new ArrayList();
        }

        static void Main(string[] argumentArray)
        {
            theBeginningConsoleColor = Console.ForegroundColor;
            string fileLocation = null;
            if (argumentArray.Length > 0)
            {
                fileLocation = argumentArray[0];
            }
            if (fileLocation != null)
            {
                Payroll aPayroll = new Payroll();
                aPayroll.setFileLocation(fileLocation);
                /*
                aPayroll.ID = "THE ID";
                aPayroll.Name = "THE NAME";
                anArrayList.Add(aPayroll);
                */
                aPayroll.Menu();
            }
            else
            {
                Console.WriteLine("Please pass in the file location where the transactions will be stored.");
            }
            Console.ForegroundColor = theBeginningConsoleColor;
        }
        private void Menu()
        {
            displayMenuScreen();
            bool keepRunning = true;
            while (keepRunning)
            {
                string theInputValue = Console.ReadLine();
                switch (theInputValue)
                {
                    case "1":
                        PopulateEmployees();
                        break;
                    case "2":
                        if (CanSelectEmployees())
                        {
                            SelectEmployeesScreen();
                        }
                        else
                        {
                            theErrorMessage = "There are no employees to display.";
                        }
                        break;
                    case "3":
                        SaveEmployee();
                        break;
                    case "4":
                        if (!LoadEmployees())
                        {
                            theErrorMessage = "The employee file does not exist.";
                        }
                        else
                        {
                            presentSuccessfulTransactionMessage("The employees have been loaded.");
                        }
                        break;
                    case "5":
                        keepRunning = false;
                        break;
                    default:
                        theErrorMessage = "Please enter a valid menu option.";
                        break;
                }
                displayMenuScreen();
            }
        }
        private void displayMenuScreen()
        {
            Console.Clear();
            addTopMargin();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(someBlanks + theErrorMessage);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(someBlanks + "Welcome to Employee Maintenance!");
            Console.WriteLine(someBlanks + "Please enter a number corresponding to the numbers below.");
            Console.WriteLine(someBlanks + "1. Populate Employees");
            Console.WriteLine(someBlanks + "2. Select Employee");
            Console.WriteLine(someBlanks + "3. Save Employees");
            Console.WriteLine(someBlanks + "4. Load Employees");
            Console.WriteLine(someBlanks + "5. Exit");
            Console.WriteLine();
            theErrorMessage = "";
        }
        private void addTopMargin()
        {
            for (int linecount = 1; linecount < 10; linecount++)
            {
                Console.WriteLine();
            }
        }

        private void PopulateEmployees()
        {
            displayPopulateEmployeesScreen();
            bool keepRunning = true;
            while (keepRunning)
            {
                string theInputValue = Console.ReadLine();
                switch (theInputValue.ToLower())
                {
                    case "h":
                        Hourly_Employee anHourlyEmployee = new Hourly_Employee();
                        anHourlyEmployee.menu();
                        if (anHourlyEmployee.getIsFilledOut())
                        {
                            anEmployeeArrayList.Add(anHourlyEmployee);
                        }
                        break;
                    case "s":
                        Salary_Employee aSalaryEmployee = new Salary_Employee();
                        aSalaryEmployee.menu();
                        if (aSalaryEmployee.getIsFilledOut())
                        {

                            anEmployeeArrayList.Add(aSalaryEmployee);
                        }
                        break;
                    case "c":
                        Commission_Employee aCommissionEmployee = new Commission_Employee();
                        aCommissionEmployee.menu();
                        if (aCommissionEmployee.getIsFilledOut())
                        {

                            anEmployeeArrayList.Add(aCommissionEmployee);
                        }
                        break;
                    case "x":
                        keepRunning = false;
                        break;
                    default:
                        theErrorMessage = "Please enter a valid menu option.";
                        break;
                }
                displayPopulateEmployeesScreen();
            }
        }

        private void SelectEmployeesScreen()
        {
            displaySelectEmployeesScreen();
            bool keepRunning = true;
            while (keepRunning)
            {
                string theInputValue = Console.ReadLine();
                switch (theInputValue.ToLower())
                {
                    case "x":
                        keepRunning = false;
                        break;
                    default:
                        theErrorMessage = "Please enter a valid menu option.";
                        break;
                }
                displaySelectEmployeesScreen();
            }
        }

        private void displaySelectEmployeesScreen()
        {
            Console.Clear();
            addTopMargin();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(someBlanks + theErrorMessage);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(someBlanks + "Please select an employee to view.  Enter 'X' to exit.");
            int theCounter = 1;
            foreach (Employee anEmployee in anEmployeeArrayList)
            {
                Console.WriteLine(someBlanks + "(" + theCounter + ") Employee Type: " + getEmployeeType(anEmployee.GetType()));
                theCounter++;
            }
            Console.WriteLine();
            theErrorMessage = "";
        }
        private void displayPopulateEmployeesScreen()
        {
            Console.Clear();
            addTopMargin();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(someBlanks + theErrorMessage);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(someBlanks + "Enter Employee Type");
            Console.WriteLine(someBlanks + "(H)ourly");
            Console.WriteLine(someBlanks + "(S)alary");
            Console.WriteLine(someBlanks + "(C)ommission");
            Console.WriteLine(someBlanks + "E(X)it");
            Console.WriteLine();
            theErrorMessage = "";
        }
        private bool CanSelectEmployees()
        {
            bool theReturnValue = false;
            foreach (Employee anEmployee in anEmployeeArrayList)
            {
                theReturnValue = true;
            }
            return theReturnValue;
        }
        private void SaveEmployee()
        {
           // if (doWeHaveAnEmployeeOfEachType())
            if (isThereAnEmployeeOfEachType())
            {
                presentSuccessfulTransactionMessage("The employees have been saved.");
                IFormatter formatter = new BinaryFormatter();
                Stream stream = new FileStream(fileLocation, FileMode.Create, FileAccess.Write);
                formatter.Serialize(stream, anEmployeeArrayList);
                stream.Close();
            }
            else
            {
                Console.WriteLine("We do not have at least one of each type.");
            }
            Thread.Sleep(3000);
        }
        private bool LoadEmployees()
        {
            bool theReturnValue = false;
            if (File.Exists(fileLocation))
            {
                theReturnValue = true;
                Stream stream = new FileStream(fileLocation, FileMode.Open, FileAccess.Read);
                IFormatter formatter = new BinaryFormatter();
                anEmployeeArrayList = (ArrayList)formatter.Deserialize(stream);
                stream.Close();
            }
            return theReturnValue;
        }

        private string getEmployeeType(Type aType)
        {
            if (aType.FullName.Contains("Hourly"))
            {
                return "Hourly";
            }
            if (aType.FullName.Contains("Salary"))
            {
                return "Salary";
            }
            if (aType.FullName.Contains("Commission"))
            {
                return "Commission";
            }
            return "";
        }
        private bool isThereAnEmployeeOfEachType()
        {
            bool theReturnValue = false;
            bool atLeastOneHourly = false;
            bool atLeastOneSalary = false;
            bool atLeastOneCommission = false;
            foreach (Employee anEmployee in anEmployeeArrayList)
            {
                if (getEmployeeType(anEmployee.GetType()).Equals("Hourly"))
                {
                    atLeastOneHourly = true;
                }
                if (getEmployeeType(anEmployee.GetType()).Equals("Salary"))
                {
                    atLeastOneSalary = true;
                }
                if (getEmployeeType(anEmployee.GetType()).Equals("Commission"))
                {
                    atLeastOneCommission = true;
                }
                if (atLeastOneHourly &&
                    atLeastOneSalary &&
                    atLeastOneCommission)
                {
                    theReturnValue = true;
                }
            }
            return theReturnValue;
        }

        private bool doWeHaveAnEmployeeOfEachType()
        {
            bool returnValue = false;
            int aCountOfHourlyEmployees = 0;
            int aCountOfSalaryEmployees = 0;
            int aCountOfCommissionEmployees = 0;
            foreach (Employee anEmployee in anEmployeeArrayList)
            {
                if (anEmployee.GetType().FullName.Contains("Hourly"))
                {
                    aCountOfHourlyEmployees++;
                }
                if (anEmployee.GetType().FullName.Contains("Salary"))
                {
                    aCountOfSalaryEmployees++;
                }
                if (anEmployee.GetType().FullName.Contains("Commission"))
                {
                    aCountOfCommissionEmployees++;
                }
            }
            if (aCountOfCommissionEmployees > 0 &&
                aCountOfHourlyEmployees > 0 &&
                aCountOfSalaryEmployees > 0)
            {
                returnValue = true;
            }
            return returnValue;
        }
        public string getFileLocation()
        {
            return fileLocation;
        }
        public void setFileLocation(string pFileLocation)
        {
            this.fileLocation = pFileLocation;
        }
        protected void presentSuccessfulTransactionMessage(string theTransactionSuccessMessage)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(someBlanks + theTransactionSuccessMessage);
            Console.ForegroundColor = ConsoleColor.Green;
            Thread.Sleep(sleepTime);
        }
    }
}
