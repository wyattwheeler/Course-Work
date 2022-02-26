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
            // Public employee variables, go brrrr
            public string firstName
            {
                get;
                set;
            }
            public string lastName
            {
                get;
                set;
            }
            public string emailId
            {
                get;
                set;
            }
            public string contactNumber
            {
                get;
                set;
            }
            public string address
            {
                get;
                set;
            }
            public static string serial;

            // AddEmployee(string, string, List<Employee>)
            // Adds employee information to record in list & file.
            public static void AddEmployee(string sfirstName, string slastName, List<Employee> eList)
            {
                Employee em = new Employee();
                em.firstName = sfirstName;
                em.lastName = slastName;

                Console.WriteLine("\nPlease enter employee email:");
                em.emailId = Console.ReadLine();

                Console.WriteLine("\nPlease enter employee phone number:");
                em.contactNumber = Console.ReadLine();

                Console.WriteLine("\nPlease enter employee address:");
                em.address = Console.ReadLine();

                eList.Add(em);

                int index = eList.IndexOf(em);
                var table = new ConsoleTable("Index", "First Name", "Last Name", "Email", "Contact Number", "Address");
                table.AddRow(index, em.firstName, em.lastName, em.emailId, em.contactNumber, em.address);
                table.Write();

                // Serializing
                // Using the Newtonsoft.Json package, we can create / open & write serial to file with a few lines.
                using (StreamWriter file = File.CreateText("employee.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, eList);
                }
            }

            // InsertEmployee(int, List<Employee>
            // Inserts new employee information at defined index.
            public static void InsertEmployee(int iId, List<Employee> eList)
            {
                Employee em = new Employee();

                Console.WriteLine("Employee Index: {0}\n", iId);

                Console.WriteLine("\nPlease write first name for employee Index: {0}", iId);
                em.firstName = Console.ReadLine();

                Console.WriteLine("\nPlease write last name for employee Index: {0}", iId);
                em.lastName = Console.ReadLine();

                Console.WriteLine("\nPlease enter employee email for employee Index: {0}:", iId);
                em.emailId = Console.ReadLine();

                Console.WriteLine("\nPlease enter employee phone number for employee Index: {0}:", iId);
                em.contactNumber = Console.ReadLine();

                Console.WriteLine("\nPlease enter employee address for employee Index: {0}:", iId);
                em.address = Console.ReadLine();

                eList.Insert(iId, em);

                var table = new ConsoleTable("Index", "First Name", "Last Name", "Email", "Contact Number", "Address");
                table.AddRow(iId, em.firstName, em.lastName, em.emailId, em.contactNumber, em.address);
                table.Write();

                // Serializing
                using (StreamWriter file = File.CreateText("employee.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, eList);
                }
            }

            // UpdateEmployeeId(int, List<Employee>)
            // Update employee information at desired index
            public static void UpdateEmployeeId(int iId, List<Employee> eList)
            {
                Employee em = eList.ElementAt(iId);

                if (em == null)
                    return;

                // Use strings to ensure strings are getting parsed correctly & not early or somehow nulled
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

                // Serialize
                using (StreamWriter file = File.CreateText("employee.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, eList);
                }
            }

            // UpdateEmployeeName(string, List<Employee>)
            // Update employee information at desired first name
            public static void UpdateEmployeeName(string sName, List<Employee> eList)
            {
                string sFirstName, sLastName, sEmailID, sMobileNumber, sAddress;

                // Originally figured out how to do this when deleting first, then recycled it.
                List<Employee> DelList = eList.FindAll(em => em.firstName == sName);

                var table = new ConsoleTable("Index", "First Name", "Last Name");

                if (DelList.Count > 1)
                {
                    int eindex;
                    Console.WriteLine("Multiple employees with the same first name detected, please select below.");

                    foreach (Employee em in DelList)
                    {
                        eindex = DelList.IndexOf(em); // variable leaking to global, whoops
                        table.AddRow(eindex, em.firstName, em.lastName);
                    }

                    table.Write();

                    string sInput = Console.ReadLine();
                    bool isString = int.TryParse(sInput, out int num);

                    if (num > DelList.Count)
                    {
                        Console.WriteLine("Index out of bounds, please restart.");
                        return;
                    }

                    Employee emchosen = eList.ElementAt(num);
                    eindex = eList.IndexOf(emchosen);

                    if (emchosen == null)
                        return;

                    Console.WriteLine("Employee found: {0} {1}", emchosen.firstName, emchosen.lastName);
                    Console.WriteLine("Not inputting any details will not update the record.");
                    Console.WriteLine("Please enter new first name for employee at index: {0}", eindex);

                    sFirstName = Console.ReadLine();

                    if (String.Equals(sFirstName, ""))
                        sFirstName = emchosen.firstName;
                    else
                        emchosen.firstName = sFirstName;

                    Console.WriteLine("Please enter new last name for employee at index: {0}", eindex);

                    sLastName = Console.ReadLine();

                    if (String.Equals(sLastName, ""))
                        sLastName = emchosen.lastName;
                    else
                        emchosen.lastName = sLastName;

                    Console.WriteLine("\nPlease enter employee email for employee at index: {0}:", eindex);

                    sEmailID = Console.ReadLine();

                    if (String.Equals(sEmailID, ""))
                        sEmailID = emchosen.emailId;
                    else
                        emchosen.emailId = sEmailID;

                    Console.WriteLine("\nPlease enter employee phone number for employee at index: {0}:", eindex);

                    sMobileNumber = Console.ReadLine();

                    if (String.Equals(sMobileNumber, ""))
                        sMobileNumber = emchosen.contactNumber;
                    else
                        emchosen.contactNumber = sMobileNumber;

                    Console.WriteLine("\nPlease enter employee address for employee at index: {0}:", eindex);

                    sAddress = Console.ReadLine();

                    if (String.Equals(sAddress, ""))
                        sAddress = emchosen.address;
                    else
                        emchosen.address = sAddress;

                    table = new ConsoleTable("Index", "First Name", "Last Name", "Email", "Contact Number", "Address");
                    table.AddRow(eindex, emchosen.firstName, emchosen.lastName, emchosen.emailId, emchosen.contactNumber, emchosen.address);
                    table.Write();
                }
                else
                {
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

                    table = new ConsoleTable("Index", "First Name", "Last Name", "Email", "Contact Number", "Address");
                    table.AddRow(index, em.firstName, em.lastName, em.emailId, em.contactNumber, em.address);
                    table.Write();
                }

                // Serialize
                using (StreamWriter file = File.CreateText("employee.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, eList);
                }
            }

            // DeleteEmployeeId(int, List<Employee>)
            // Delete employee from list & file by desired index
            public static void DeleteEmployeeId(int iId, List<Employee> eList)
            {
                Employee em = eList.ElementAt(iId);

                if (em == null)
                    return;

                Console.WriteLine("Employee {0} {1} found at ID: {2}, deleting...", em.firstName, em.lastName, iId);

                eList.RemoveAt(iId);

                // Serialize
                using (StreamWriter file = File.CreateText("employee.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, eList);
                }
            }

            // DeleteEmployeeName(string, List<Employee>)
            // Delete employee from list & file by desired name
            public static void DeleteEmployeeName(string sName, List<Employee> eList)
            {
                List<Employee> DelList = eList.FindAll(em => em.firstName == sName); // Make new list to deconstruct, then delete from original list.

                if (DelList.Count > 1)
                {
                    int eindex; 
                    Console.WriteLine("Multiple employees with the same first name detected, please select below.");
                    var table = new ConsoleTable("Index", "First Name", "Last Name");

                    foreach (Employee em in DelList)
                    {
                        eindex = DelList.IndexOf(em); // variable leaking to global, whoops
                        table.AddRow(eindex, em.firstName, em.lastName);
                    }

                    table.Write();

                    string sInput = Console.ReadLine();
                    bool isString = int.TryParse(sInput, out int num);

                    if (num > DelList.Count)
                    {
                        Console.WriteLine("Index out of bounds, please restart.");
                        return;
                    }

                    Employee emchosen = eList.ElementAt(num);
                    eindex = eList.IndexOf(emchosen);

                    if (emchosen == null)
                        return;

                    Console.WriteLine("Employee {0} {1} found at ID: {2}, deleting...", emchosen.firstName, emchosen.lastName, eindex);

                    eList.RemoveAt(eindex);
                }
                else
                {
                    Employee em = eList.Find(em => em.firstName == sName);

                    int index = eList.IndexOf(em);

                    if (em == null)
                        return;

                    Console.WriteLine("Employee {0} {1} found at ID: {2}, deleting...", em.firstName, em.lastName, index);

                    eList.RemoveAt(index);
                }

                // Serialize
                using (StreamWriter file = File.CreateText("employee.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, eList);
                }
            }

            // SearchEmployeeId(int, List<Employee>)
            // Search employee information from list & file by desired index
            public static void SearchEmployeeId(int iId, List<Employee> eList)
            {
                Employee em = eList.ElementAt(iId);

                if (em == null)
                    return;

                if (iId > eList.Count)
                {
                    Console.WriteLine("Index out of bounds, please restart.");
                    return;
                }

                int index = eList.IndexOf(em);

                var table = new ConsoleTable("Index", "First Name", "Last Name", "Email", "Contact Number", "Address"); // External library ConsoleTable to show data easier.
                table.AddRow(index, em.firstName, em.lastName, em.emailId, em.contactNumber, em.address);
                table.Write();
            }

            // SearchEmployeeName(int, List<Employee>)
            // Search employee information from list & file by desired string
            public static void SearchEmployeeName(string sName, List<Employee> eList)
            {
                eList = eList.FindAll(em => em.firstName == sName);

                if(eList.Count > 1)
                {
                    int index;
                    Console.WriteLine("Multiple employees with the same first name detected, please select below.");
                    var table = new ConsoleTable("Index", "First Name", "Last Name");
                    foreach (Employee em in eList)
                    {
                        index = eList.IndexOf(em);
                        table.AddRow(index, em.firstName, em.lastName);
                    }

                    table.Write();

                    string sInput = Console.ReadLine();
                    bool isString = int.TryParse(sInput, out int num);

                    if (num > eList.Count)
                    {
                        Console.WriteLine("Index out of bounds, please restart.");
                        return;
                    }

                    Employee emchosen = eList.ElementAt(num);

                    if (emchosen == null)
                        return;

                    index = eList.IndexOf(emchosen);
                    table = new ConsoleTable("Index", "First Name", "Last Name", "Email", "Contact Number", "Address");
                    table.AddRow(index, emchosen.firstName, emchosen.lastName, emchosen.emailId, emchosen.contactNumber, emchosen.address);
                    table.Write();
                }
                else
                {
                    Employee em = eList.Find(em => em.firstName == sName);

                    int index = eList.IndexOf(em);
                    var table = new ConsoleTable("Index", "First Name", "Last Name", "Email", "Contact Number", "Address");
                    table.AddRow(index, em.firstName, em.lastName, em.emailId, em.contactNumber, em.address);
                    table.Write();
                }
            }
        }

        static void Main()
        {
            Console.WriteLine("==========Employee Information==========");
            Console.WriteLine("\n1. Add Information\n2. Insert Information\n3. Update Information\n4. Delete Information\n5. Search Information\n6. Display Information\n7. Display Information Menu");
            int num = 0; // Number selector
            int iRun = 1; // Make thing do thing
            List<Employee> EList = new List<Employee>(); // Keeping this at a global scope didn't carry my data, dunno why.

            // Serialize
            bool exists = File.Exists("employee.json");

            if(!exists) // File doesn't exist, create.
            {
                using (StreamWriter file = File.CreateText("employee.json"))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(file, EList);
                }
            }
            else
            {
                // We read file every time the program runs, never again as it is synced with the object list
                using (StreamReader file = new StreamReader("employee.json"))
                {
                    Employee.serial = file.ReadToEnd();
                    EList = JsonConvert.DeserializeObject<List<Employee>>(Employee.serial);
                }
            }

            // We do everything here, call all our functions and everything
            do
            {
                // Grab input, parse through as integer, prevents exception errors when something other than int is entered.
                string iinput = Console.ReadLine();
                bool isString = int.TryParse(iinput, out num);

                // Call function based on number representive in landing page.
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

                            isString = int.TryParse(Console.ReadLine(), out iEmployeeID);

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
                                isString = int.TryParse(Console.ReadLine(), out int iId);

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

                                isString = int.TryParse(Console.ReadLine(), out int iId);

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
                                isString = int.TryParse(Console.ReadLine(), out int iId);

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
                        Console.WriteLine("Please enter a function valid number.");
                        break;
                }
            }
            while (iRun == 1);
        }
    }
}