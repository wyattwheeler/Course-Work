using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading;

#nullable disable // lazy

namespace ConsoleApp
{
    class Program
    {
        public class Employee // BRRRR
        {
            public int Id
            {
                get;
                set;
            }
            public string firstName
            {
                get;
                set;
            }
            public string lastName
            {
                get => lastName;
                set => lastName = value;
            }
            public string emailId
            {
                get => emailId;
                set => emailId = value;
            }
            public string contactNumber
            {
                get => contactNumber;
                set => contactNumber = value;
            }
            public string address
            {
                get => address;
                set => address = value;
            }
        }

        static void Main()
        {
            Console.WriteLine("==========Employee Information==========");
            Console.WriteLine("\n1. Add Information\n2. Insert Information\n3. Update Information\n4. Delete Information\n5. Search Information\n6. Display Information");
            int num = 0;
            int iRun = 1; // lazy
            num = Convert.ToInt32(Console.ReadLine());

            do
            {
                switch (num)
                {
                    case 1:

                        string sFirstName, sLastName;
                        Console.WriteLine("Please state employee's first name.");
                        sFirstName = Console.ReadLine();

                        Console.WriteLine("Please state employee's last name.");
                        sLastName = Console.ReadLine();

                        AddEmployee(sFirstName, sLastName); // can only be null on expended types

                        break;
                    case 2:
                        // insert info
                        break;
                    case 3:
                        // update info
                        break;
                    case 4:
                        // delete info
                        break;
                    case 5:
                        // search info
                        break;
                    case 6:
                        List<Employee> EList = new List<Employee>();

                        for (int i = 0; i <= EList.Count - 1; i = i + 1) // loop my nuts
                        {
                            string sOutput = "";
                            String.Format(sOutput, "Employee Name: {0} {1}\n{2}", EList[i].firstName, EList[i].lastName, sOutput);
                            Console.WriteLine("{0}", sOutput);
                        }
                        break;
                    default:
                        // not a number, deez nutz.
                        break;
                }
            }
            while (iRun == 1);
        }

        static void AddEmployee(string sfirstName, string slastName)
        {
            List<Employee> EList = new List<Employee>();

            EList.Add(new Employee()
            {
                firstName = sfirstName,
                lastName = slastName
            });
        }
    }
}