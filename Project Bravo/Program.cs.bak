using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading;
using ConsoleTables;

#nullable disable // lazy

namespace ConsoleApp
{
    class Program
    {
        public class Employee // BRRRR
        {
            private string firstEName;
            private string lastEName;
            private string emailEid;
            private string contactEnumber;
            private string Eaddress;
            public string firstName
            {
                get
                {
                    return firstEName;
                }
                set
                {
                    firstEName = value;
                }
            }
            public string lastName
            {
                get
                {
                    return lastEName;
                }
                set
                {
                    lastEName = value;
                }
            }

            public string emailId
            {
                get
                {
                    return emailEid;
                }
                set
                {
                    emailEid = value;
                }
            }

            public string contactNumber
            {
                get
                {
                    return contactEnumber;
                }
                set
                {
                    contactEnumber = value;
                }
            }

            public string address
            {
                get
                {
                    return Eaddress;
                }
                set
                {
                    Eaddress = value;
                }
            }

            public static void AddEmployee(string sfirstName, string slastName, List<Employee> eList)
            {
                Employee em = new Employee();

                em.firstName = sfirstName;
                em.lastName = slastName;

                eList.Add(em);
                int index = eList.IndexOf(em);
                Console.WriteLine("[DEBUG] AddEmployee: {0} {1} with Index: {2}", em.firstName, em.lastName, index);
            }

            public static void InsertEmployee(int iId, List<Employee> eList)
            {
                Employee em = new Employee();
                string sFirstName, sLastName;

                Console.WriteLine("Employee Index: {0}\n", iId);

                Console.WriteLine("Please write first name for employee Index: {0}", iId);
                sFirstName = Console.ReadLine();

                em.firstName = sFirstName;

                Console.WriteLine("Please write last name for employee Index: {0}", iId);
                sLastName = Console.ReadLine();

                em.lastName = sLastName;

                eList.Insert(iId, em);
                int index = eList.IndexOf(em);

                Console.WriteLine("Employee Index: {0} updated with Name: {1} {2}", index, em.firstName, em.lastName);
            }

            public static void UpdateEmployeeId(int iId, List<Employee> eList)
            {
                Employee em = eList.ElementAt(iId);

                if (em == null)
                    return;

                string sFirstName, sLastName;

                Console.WriteLine("Please enter first name for employee at index: {0}", iId);
                sFirstName = Console.ReadLine();

                em.firstName = sFirstName;

                Console.WriteLine("Please enter last name for employee at index: {0}", iId);
                sLastName = Console.ReadLine();

                em.lastName = sLastName;

                Console.WriteLine("Employee Index: {0} updated with name {1} {2}", iId, em.firstName, em.lastName);
            }

            public static void UpdateEmployeeName(string sName, List<Employee> eList)
            {
                string sFirstName, sLastName;
                Employee em = eList.Find(em => em.firstName == sName);

                if (em == null)
                    return;

                int index = eList.IndexOf(em);

                Console.WriteLine("Employee found: {0} {1}", em.firstName, em.lastName);

                Console.WriteLine("Please enter new first name for employee at index: {0}", index);
                sFirstName = Console.ReadLine();

                em.firstName = sFirstName;

                Console.WriteLine("Please enter new last name for employee at index: {0}", index);
                sLastName = Console.ReadLine();

                em.lastName = sLastName;

                Console.WriteLine("Employee Index: {0} updated with name {1} {2}", index, em.firstName, em.lastName);
            }

            public static void DeleteEmployeeId(int iId, List<Employee> eList)
            {
                Employee em = eList.ElementAt(iId);

                if (em == null)
                    return;

                Console.WriteLine("Employee {0} {1} found at ID: {2}, deleting...", em.firstName, em.lastName, iId);

                eList.RemoveAt(iId);
            }

            public static void DeleteEmployeeName(string sName, List<Employee> eList)
            {
                Employee em = eList.Find(em => em.firstName == sName);

                if (em == null)
                    return;

                int index = eList.IndexOf(em);

                Console.WriteLine("Employee {0} {1} found at ID: {2}, deleting...", em.firstName, em.lastName, index);

                eList.RemoveAt(index);
            }

            public static void SearchEmployeeId(int iId, List<Employee> eList)
            {
                Employee em = eList.ElementAt(iId);

                if (em == null)
                    return;

                var table = new ConsoleTable("Index", "First Name", "Last Name"); // External library ConsoleTable to show data easier.

                int index = eList.IndexOf(em);

                table.AddRow(index, em.firstName, em.lastName);
                table.Write();
            }

            public static void SearchEmployeeName(string sName, List<Employee> eList)
            {
                Employee em = eList.Find(em => em.firstName == sName);

                if (em == null)
                    return;

                int index = eList.IndexOf(em);

                var table = new ConsoleTable("Index", "First Name", "Last Name"); // External library ConsoleTable to show data easier.

                table.AddRow(index, em.firstName, em.lastName);
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

                        var table = new ConsoleTable("Index", "First Name", "Last Name"); // External library ConsoleTable to show data easier.

                        foreach (Employee employee in EList)
                        {
                            int index = EList.IndexOf(employee);
                            table.AddRow(index, employee.firstName, employee.lastName);
                        }

                        table.Write();
                        break;
                    case 7:
                        Console.WriteLine("==========Employee Information==========");
                        Console.WriteLine("\n1. Add Information\n2. Insert Information\n3. Update Information\n4. Delete Information\n5. Search Information\n6. Display Information");
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