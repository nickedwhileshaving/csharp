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
                aPayroll.ID = "THE ID";
                aPayroll.Name = "THE NAME";
                anArrayList.Add(aPayroll);
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

        }
        private void PopulateEmployees()
        {

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
        private void LoadEmployee()
        {
            Stream stream = new FileStream(fileLocation, FileMode.Create, FileAccess.Write);
            IFormatter formatter = new BinaryFormatter();
            stream = new FileStream(fileLocation, FileMode.Open, FileAccess.Read);
            anEmployeeArrayList = (ArrayList)formatter.Deserialize(stream);
        }
    }
}
