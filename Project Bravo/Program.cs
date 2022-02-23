using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading;
using System.IO;
using ConsoleTables;
using Newtonsoft.Json;

#nullable disable // lazy

namespace ConsoleApp
{
    class Program
    {
        [Serializable]
        public class Employee // BRRRR
        {
            public int id { get; set; }
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string emailId { get; set; }

            public string contactNumber { get; set; }

            public string address { get; set; }

            public static string serial;

            public static void AddEmployee(string sfirstName, string slastName, List<Employee> eList)
            {
                Employee em = new Employee();

                em.firstName = sfirstName;
                em.lastName = slastName;

                // Extras

                string sEmailID, sMobileNumber, sAddress;

                Console.WriteLine("\nPlease enter employee email:");
                sEmailID = Console.ReadLine();
                em.emailId = sEmailID;

                Console.WriteLine("\nPlease enter employee phone number:");
                sMobileNumber = Console.ReadLine();

                em.contactNumber = sMobileNumber;

                Console.WriteLine("\nPlease enter employee address:");
                sAddress = Console.ReadLine();

                em.address = sAddress;

                eList.Add(em);
                int index = eList.IndexOf(em);

                var table = new ConsoleTable("Index", "First Name", "Last Name", "Email", "Contact Number", "Address");

                table.AddRow(index, em.firstName, em.lastName, em.emailId, em.contactNumber, em.address);
                table.Write();

                // serialize
                using (StreamWriter file = File.CreateText("employee.txt"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, eList);
                }
            }

            public static void InsertEmployee(int iId, List<Employee> eList)
            {
                Employee em = new Employee();
                string sFirstName, sLastName, sEmailID, sMobileNumber, sAddress;

                Console.WriteLine("Employee Index: {0}\n", iId);

                Console.WriteLine("Please write first name for employee Index: {0}", iId);
                sFirstName = Console.ReadLine();

                em.firstName = sFirstName;

                Console.WriteLine("Please write last name for employee Index: {0}", iId);
                sLastName = Console.ReadLine();

                em.lastName = sLastName;

                Console.WriteLine("\nPlease enter employee email for employee Index: {0}:", iId);
                sEmailID = Console.ReadLine();
                em.emailId = sEmailID;

                Console.WriteLine("\nPlease enter employee phone number for employee Index: {0}:", iId);
                sMobileNumber = Console.ReadLine();

                em.contactNumber = sMobileNumber;

                Console.WriteLine("\nPlease enter employee address for employee Index: {0}:", iId);
                sAddress = Console.ReadLine();

                em.address = sAddress;

                eList.Insert(iId, em);

                var table = new ConsoleTable("Index", "First Name", "Last Name", "Email", "Contact Number", "Address");

                table.AddRow(iId, em.firstName, em.lastName, em.emailId, em.contactNumber, em.address);
                table.Write();

                // serialize
                using (StreamWriter file = File.CreateText("employee.txt"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, eList);
                }
            }

            public static void UpdateEmployeeId(int iId, List<Employee> eList)
            {
                Employee em = eList.ElementAt(iId);

                if (em == null)
                    return;

                string sFirstName, sLastName, sEmailID, sMobileNumber, sAddress;

                Console.WriteLine("Not inputting any details will not update the record.");

                Console.WriteLine("Please enter first name for employee at index: {0}", iId);
                sFirstName = Console.ReadLine();

                if (String.Equals(sFirstName, ""))
                    sFirstName = em.firstName;
                else
                    em.firstName = sFirstName;

                Console.WriteLine("Please enter last name for employee at index: {0}", iId);
                sLastName = Console.ReadLine();

                if (String.Equals(sLastName, ""))
                    sLastName = em.lastName;
                else
                    em.lastName = sLastName;

                Console.WriteLine("\nPlease enter employee email for employee at index: {0}:", iId);
                sEmailID = Console.ReadLine();

                if (String.Equals(sEmailID, ""))
                    sEmailID = em.emailId;
                else
                    em.emailId = sEmailID;

                Console.WriteLine("\nPlease enter employee phone number for employee at index: {0}:", iId);
                sMobileNumber = Console.ReadLine();

                if (String.Equals(sMobileNumber, ""))
                    sMobileNumber = em.contactNumber;
                else
                    em.contactNumber = sMobileNumber;

                Console.WriteLine("\nPlease enter employee address for employee at index: {0}:", iId);
                sAddress = Console.ReadLine();

                if (String.Equals(sAddress, ""))
                    sAddress = em.address;
                else
                    em.address = sAddress;

                var table = new ConsoleTable("Index", "First Name", "Last Name", "Email", "Contact Number", "Address");

                table.AddRow(iId, em.firstName, em.lastName, em.emailId, em.contactNumber, em.address);
                table.Write();

                // serialize
                using (StreamWriter file = File.CreateText("employee.txt"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, eList);
                }
            }

            public static void UpdateEmployeeName(string sName, List<Employee> eList)
            {
                string sFirstName, sLastName, sEmailID, sMobileNumber, sAddress;
                Employee em = eList.Find(em => em.firstName == sName);

                if (em == null)
                    return;

                int index = eList.IndexOf(em);

                Console.WriteLine("Employee found: {0} {1}", em.firstName, em.lastName);
                Console.WriteLine("Not inputting any details will not update the record.");

                Console.WriteLine("Please enter new first name for employee at index: {0}", index);

                sFirstName = Console.ReadLine();

                if (String.Equals(sFirstName, ""))
                    sFirstName = em.firstName;
                else
                    em.firstName = sFirstName;

                Console.WriteLine("Please enter new last name for employee at index: {0}", index);
                sLastName = Console.ReadLine();

                if (String.Equals(sLastName, ""))
                    sLastName = em.lastName;
                else
                    em.lastName = sLastName;

                Console.WriteLine("\nPlease enter employee email for employee at index: {0}:", index);
                sEmailID = Console.ReadLine();

                if (String.Equals(sEmailID, ""))
                    sEmailID = em.emailId;
                else
                    em.emailId = sEmailID;

                Console.WriteLine("\nPlease enter employee phone number for employee at index: {0}:", index);
                sMobileNumber = Console.ReadLine();

                if (String.Equals(sMobileNumber, ""))
                    sMobileNumber = em.contactNumber;
                else
                    em.contactNumber = sMobileNumber;

                Console.WriteLine("\nPlease enter employee address for employee at index: {0}:", index);
                sAddress = Console.ReadLine();

                if (String.Equals(sAddress, ""))
                    sAddress = em.address;
                else
                    em.address = sAddress;

                var table = new ConsoleTable("Index", "First Name", "Last Name", "Email", "Contact Number", "Address");

                table.AddRow(index, em.firstName, em.lastName, em.emailId, em.contactNumber, em.address);
                table.Write();

                // serialize
                using (StreamWriter file = File.CreateText("employee.txt"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, eList);
                }
            }

            public static void DeleteEmployeeId(int iId, List<Employee> eList)
            {
                Employee em = eList.ElementAt(iId);

                if (em == null)
                    return;

                Console.WriteLine("Employee {0} {1} found at ID: {2}, deleting...", em.firstName, em.lastName, iId);

                eList.RemoveAt(iId);

                // serialize
                using (StreamWriter file = File.CreateText("employee.txt"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, eList);
                }
            }

            public static void DeleteEmployeeName(string sName, List<Employee> eList)
            {
                Employee em = eList.Find(em => em.firstName == sName);

                if (em == null)
                    return;

                int index = eList.IndexOf(em);

                Console.WriteLine("Employee {0} {1} found at ID: {2}, deleting...", em.firstName, em.lastName, index);

                eList.RemoveAt(index);

                // serialize
                using (StreamWriter file = File.CreateText("employee.txt"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, eList);
                }
            }

            public static void SearchEmployeeId(int iId, List<Employee> eList)
            {
                Employee em = eList.ElementAt(iId);

                if (em == null)
                    return;

                var table = new ConsoleTable("Index", "First Name", "Last Name", "Email", "Contact Number", "Address"); // External library ConsoleTable to show data easier.

                int index = eList.IndexOf(em);

                table.AddRow(index, em.firstName, em.lastName, em.emailId, em.contactNumber, em.address);
                table.Write();
            }

            public static void SearchEmployeeName(string sName, List<Employee> eList)
            {
                Employee em = eList.Find(em => em.firstName == sName);

                if (em == null)
                    return;

                int index = eList.IndexOf(em);

                var table = new ConsoleTable("Index", "First Name", "Last Name", "Email", "Contact Number", "Address");

                table.AddRow(index, em.firstName, em.lastName, em.emailId, em.contactNumber, em.address);
                table.Write();
            }

        }

        static void Main()
        {
            Console.WriteLine("==========Employee Information==========");
            Console.WriteLine("\n1. Add Information\n2. Insert Information\n3. Update Information\n4. Delete Information\n5. Search Information\n6. Display Information\n7. Display Information Menu");
            int num = 0;
            int iRun = 1; // lazy
            List<Employee> EList = new List<Employee>(); // Apparently redefining or keeping this at a global scope didn't carry my data, dunno why.

            // Serialize
            using (StreamReader file = new StreamReader("employee.txt"))
            {
                Employee.serial = file.ReadToEnd();
                EList = JsonConvert.DeserializeObject<List<Employee>>(Employee.serial);
            }

            do
            {
                num = Convert.ToInt32(Console.ReadLine());

                switch (num)
                {
                    case 1:
                        { // ugliest formatting i've ever seen.
                            string sFirstName, sLastName;
                            Console.WriteLine("Please state employee's first name.");
                            sFirstName = Console.ReadLine();

                            Console.WriteLine("Please state employee's last name.");
                            sLastName = Console.ReadLine();

                            Employee.AddEmployee(sFirstName, sLastName, EList); // can only be null on expended types
                            break;
                        }
                    case 2:
                        {
                            int iEmployeeID = 0;

                            Console.WriteLine("Insert Employee Information at index");
                            Console.WriteLine("Please enter employee index: ");

                            Employee em = new Employee();

                            iEmployeeID = Convert.ToInt32(Console.ReadLine()); // we don't need errOrs here!
                            Employee.InsertEmployee(iEmployeeID, EList);

                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Update Employee Information via Index/Name\n");
                            Console.WriteLine("Update via Index or Name? (i/n)");

                            string sInput = Console.ReadLine();

                            if (String.Equals(sInput, "i") || String.Equals(sInput, "I") || String.Equals(sInput, "Index"))
                            {
                                Console.WriteLine("Please enter Employee Index");
                                int iId = Convert.ToInt32(Console.ReadLine());

                                Employee.UpdateEmployeeId(iId, EList);
                            }
                            else if (String.Equals(sInput, "n") || String.Equals(sInput, "N") || String.Equals(sInput, "Name"))
                            {
                                Console.WriteLine("Please enter Employee's first name");

                                string sFirstName = Console.ReadLine();

                                Employee.UpdateEmployeeName(sFirstName, EList);
                            }

                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Delete Employee Information via Index/Name\n");
                            Console.WriteLine("Delete via Index or Name? (i/n)");

                            string sInput = Console.ReadLine();

                            if (String.Equals(sInput, "i") || String.Equals(sInput, "I") || String.Equals(sInput, "Index"))
                            {
                                Console.WriteLine("Please enter Employee Index");
                                int iId = Convert.ToInt32(Console.ReadLine());

                                Employee.DeleteEmployeeId(iId, EList);
                            }
                            else if (String.Equals(sInput, "n") || String.Equals(sInput, "N") || String.Equals(sInput, "Name"))
                            {
                                Console.WriteLine("Please enter Employee's first name");

                                string sFirstName = Console.ReadLine();

                                Employee.DeleteEmployeeName(sFirstName, EList);
                            }

                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Search Employee Information via Index/Name\n");
                            Console.WriteLine("Search via Index or Name? (i/n)");

                            string sInput = Console.ReadLine();

                            if (String.Equals(sInput, "i") || String.Equals(sInput, "I") || String.Equals(sInput, "Index"))
                            {
                                Console.WriteLine("Please enter Employee Index");
                                int iId = Convert.ToInt32(Console.ReadLine());

                                Employee.SearchEmployeeId(iId, EList);
                            }
                            else if (String.Equals(sInput, "n") || String.Equals(sInput, "N") || String.Equals(sInput, "Name"))
                            {
                                Console.WriteLine("Please enter Employee's first name");

                                string sFirstName = Console.ReadLine();

                                Employee.SearchEmployeeName(sFirstName, EList);
                            }

                            break;
                        }
                    case 6:
                        Console.WriteLine("[DEBUG] Displaying all information in EList");

                        var table = new ConsoleTable("Index", "First Name", "Last Name", "Email", "Contact Number", "Address"); // External library ConsoleTable to show data easier.

                        foreach (Employee employee in EList)
                        {
                            int index = EList.IndexOf(employee);
                            table.AddRow(index, employee.firstName, employee.lastName, employee.emailId, employee.contactNumber, employee.address);
                        }

                        table.Write();
                        break;
                    case 7:
                        Console.WriteLine("==========Employee Information==========");
                        Console.WriteLine("\n1. Add Information\n2. Insert Information\n3. Update Information\n4. Delete Information\n5. Search Information\n6. Display Information\n7. Display Information Menu");
                        break;
                    default:
                        // not a number, deez nutz.
                        break;
                }
            }
            while (iRun == 1);
        }
    }
}