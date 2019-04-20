﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;

namespace Assignment2
{
    [Serializable]
    class Payroll
    {
        public String ID;
        public String Name;
        private static string fileLocation;
        private static ConsoleColor theBeginningConsoleColor;
        ArrayList anEmployeeArrayList;
        private string theErrorMessage;
        private String someBlanks = "                             ";

        public Payroll()
        {
             anEmployeeArrayList = new ArrayList();
        }

        static void Main(string[] argumentArray)
        {
            theBeginningConsoleColor = Console.ForegroundColor;
            fileLocation = null;
            if (argumentArray.Length > 0)
            {
                fileLocation = argumentArray[0];
            }
            if (fileLocation != null)
            {
                Payroll aPayroll = new Payroll();
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
                        SelectEmployee();
                        break;
                    case "3":
                        SaveEmployee();
                        break;
                    case "4":
                        LoadEmployees();
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
                        break;
                    case "s":
                        Salary_Employee aSalaryEmployee = new Salary_Employee();
                        aSalaryEmployee.menu();
                        break;
                    case "c":
                        Commission_Employee aCommissionEmployee = new Commission_Employee();
                        aCommissionEmployee.menu();
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
        private void SelectEmployee()
        {

        }
        private void SaveEmployee()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(fileLocation, FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, anEmployeeArrayList);
            stream.Close();
        }
        private void LoadEmployees()
        {
            Stream stream = new FileStream(fileLocation, FileMode.Create, FileAccess.Write);
            IFormatter formatter = new BinaryFormatter();
            stream = new FileStream(fileLocation, FileMode.Open, FileAccess.Read);
            anEmployeeArrayList = (ArrayList)formatter.Deserialize(stream);
        }
    }
}
