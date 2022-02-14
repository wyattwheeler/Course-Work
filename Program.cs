using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassISSR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool sFormComplete = false;

            Console.OutputEncoding = Encoding.GetEncoding(866);
            Console.WriteLine("Project Alpha (v0.1) - Wyatt Wheeler");
            Console.WriteLine("SR02");

            Console.WriteLine("┌───┐");
            Console.WriteLine("│ 1 │");
            Console.WriteLine("└───┘\n");

            Console.WriteLine("  /\\");
            Console.WriteLine(" /2 \\");
            Console.WriteLine("/____\\");

            Console.WriteLine("┌───┐");
            Console.WriteLine("│   │");
            Console.WriteLine("│ 4 │──────┐");
            Console.WriteLine("│   │   5  │");
            Console.WriteLine("└───┘──────┘ \n");

            Console.WriteLine("│\\");
            Console.WriteLine("│ \\");
            Console.WriteLine("│ 5\\");
            Console.WriteLine("│   \\");
            Console.WriteLine("└────\\\n");

            Console.WriteLine("SR03 - First day of Techtorium was good, enjoyed meeting the others.\n");

            Console.WriteLine("SR04");
            Console.WriteLine("Confidence: 8");
            Console.WriteLine("Creativity: 4");
            Console.WriteLine("Resilience: 7");
            Console.WriteLine("Positivity: 6");
            Console.WriteLine("Hard Work: 9");
            Console.WriteLine("Love For Programming: 10\n");

            Console.WriteLine("SR05");

            string sName, sHighSchool, sID, sTrainerName, sContactNumber, sHobbies;

            Console.WriteLine("Please fill out the form below.\n");
            Console.WriteLine("Name:");
            sName = Console.ReadLine();

            Console.WriteLine("Your name is {0}\n", sName);

            Console.WriteLine("High School:");
            sHighSchool = Console.ReadLine();

            Console.WriteLine("Your name is {0} who went to {1}\n", sName, sHighSchool);

            Console.WriteLine("Techtorium ID:");
            sID = Console.ReadLine();

            Console.WriteLine("Your name is {0} who went to {1} with ID {2}\n", sName, sHighSchool, sID);

            Console.WriteLine("Trainer Name:");
            sTrainerName = Console.ReadLine();

            Console.WriteLine("Your name is {0} who went to {1} with ID {2} with tutor {3}\n", sName, sHighSchool, sID, sTrainerName);

            Console.WriteLine("Contact Number:");
            sContactNumber = Console.ReadLine();

            Console.WriteLine("Your name is {0} who went to {1} with ID {2} with tutor {3}, associated contact number is: {4}\n", sName, sHighSchool, sID, sTrainerName, sContactNumber);

            Console.WriteLine("Hobbies (seperated by comma, {}");
            sHobbies = Console.ReadLine();

            Console.WriteLine("Your name is {0} who went to {1} with ID {2} with tutor {3}, associated contact number is: {4}, hobby tags: {5}\n", sName, sHighSchool, sID, sTrainerName, sContactNumber, sHobbies);

            Console.WriteLine("Thanks for completing the form, you now have access to the main commands.");
            Console.WriteLine("Type ./help for more info.");

            sFormComplete = true;

            do
            {
                string sInput = Console.ReadLine();

                // CMDS
                string sHelpCmd = "./help";
                string sSR06Cmd = "./SR06";
                string sSR07Cmd = "./SR07";
                string sSR08Cmd = "./SR08";
                string sSR09Cmd = "./SR09";
                string sSR10Cmd = "./SR10";
                string sSR11Cmd = "./SR11";

                if (String.Equals(sInput, sHelpCmd))
                {
                    Console.WriteLine("\nProject Alpha: Help menu.");
                    Console.WriteLine("./SR06 - Execute SR06 code.");
                    Console.WriteLine("./SR07 - Execute SR07 code.");
                    Console.WriteLine("./SR08 - Execute SR08 code.");
                    Console.WriteLine("./SR09 - Execute SR09 code.");
                    Console.WriteLine("./SR10 - Execute SR10 code.");
                    Console.WriteLine("./SR11 - Execute SR11 code.");
                }

                if(String.Equals(sInput, sSR06Cmd))
                {
                    string sBirthYear;
                    string sOtherBirthYear;

                    Console.WriteLine("Birthyear compare test");
                    Console.WriteLine("Please have another to fill out this form\n");
                    Console.WriteLine("Birth year:");
                    sBirthYear = Console.ReadLine();

                    Console.WriteLine("Other person birth year:");
                    sOtherBirthYear = Console.ReadLine();

                    int iBirthYear = Int32.Parse(sBirthYear);
                    int iOtherBirthYear = Int32.Parse(sOtherBirthYear);

                    if (iBirthYear < iOtherBirthYear)
                        Console.WriteLine("Person 1 is older than Person 2.");
                    else
                        Console.WriteLine("Person 1 is younger than Person 2.");
                }

                if(String.Equals(sInput, sSR07Cmd))
                { 
                    string sBirthYear;
                    string sCitizen;

                    Console.WriteLine("Vote Elegibility Test");
                    Console.WriteLine("Please have another to fill out this form.\n");

                    Console.WriteLine("Birth Year:\n");
                    sBirthYear = Console.ReadLine();
                    int iBirthYear = Int32.Parse(sBirthYear);

                    Console.WriteLine("Are you a New Zealand citizen? (Y/n)\n");
                    sCitizen = Console.ReadLine();

                    if (String.Equals(sCitizen, "Y") || String.Equals(sCitizen, "y"))
                    {
                        if (iBirthYear <= 2003)
                        {
                            Console.WriteLine("Person 1 is elgible to vote in NZ");
                        }
                        else
                        {
                            Console.WriteLine("Person 1 is not elgible to vote in NZ, concluding test.");
                        }
                    }
                    else if(String.Equals(sCitizen, "N") || String.Equals(sCitizen, "n"))
                    {
                        Console.WriteLine("Person 1 is not elgible to vote in NZ, concluding test.");
                    }
                    else
                        Console.WriteLine("Not a valid answer, please rerun the test and check parameters.");
                }

                if(String.Equals(sInput, sSR08Cmd))
                {
                    Console.WriteLine("Negative Number Check Test");
                    Console.WriteLine("Please insert a number:\n");

                    string sNumber = Console.ReadLine();

                    int iResult;
                    if (int.TryParse(sNumber, out iResult)) // check if number not string
                    {
                        int iNumber = Int32.Parse(sNumber);

                        if (iNumber < 0)
                            Console.WriteLine("{0} is a negative number", sNumber);
                        else
                            Console.WriteLine("{0} is a positive number", sNumber);
                    }
                    else
                        Console.WriteLine("Data entered were not numbers, please rerun test.");
                }

                if(String.Equals(sInput, sSR09Cmd))
                {
                    Console.WriteLine("Number Calculation Test");
                    Console.WriteLine("David is 19 years old and Luke is 17 years old, what's the difference in years?");

                    Console.WriteLine("DEBUG: int iDavidAge = 19");
                    int iDavidAge = 19;
                    Console.WriteLine("DEBUG: int iLukeAge = 19");
                    int iLukeAge = 17;

                    Console.WriteLine("DEBUG: int iDifference = iDavidAge - iLukeAge;");
                    int iDifference = iDavidAge - iLukeAge;
                    Console.WriteLine("The difference in years between David & Luke is {0}", iDifference);
                }

                if(String.Equals(sInput, sSR10Cmd))
                {
                    Console.WriteLine("Number Odd or Even Test");
                    Console.WriteLine("Please insert a number:\n");

                    string sNumber = Console.ReadLine();

                    int iResult;
                    if (int.TryParse(sNumber, out iResult)) // check if number not string
                    {
                        int iNumber = Int32.Parse(sNumber);

                        if (iNumber % 2 == 0) // Modulo number aka get remainder, if number does not have a remainder, then run.
                            Console.WriteLine("{0} is an even number", sNumber);
                        else
                            Console.WriteLine("{0} is an odd number", sNumber);
                    }
                    else
                        Console.WriteLine("Data entered were not numbers, please rerun test.");
                }

                if (String.Equals(sInput, sSR11Cmd))
                {
                    //Each 25% out of 100 will represent a grade. (A = 76-100%, B = 75-51%, C = 50-26%, D = 25-0%)
                    Console.WriteLine("Grade Mark Test");
                    Console.WriteLine("Please insert your mark (0-100):\n");

                    string sNumber = Console.ReadLine();

                    int iResult;
                    if (int.TryParse(sNumber, out iResult)) // check if number not string
                    {
                        int iNumber = Int32.Parse(sNumber);

                        if (iNumber < 0 || iNumber > 100)
                            Console.WriteLine("Mark was exceeding bounds, please rerun test.");

                        int iGrade = 0;

                        if (iNumber >= 0 && iNumber <= 25)
                            iGrade = 4; // D
                        else if (iNumber >= 26 && iNumber <= 50)
                            iGrade = 3; // C
                        else if (iNumber >= 51 && iNumber <= 75)
                            iGrade = 2; // B
                        else if (iNumber >= 76 && iNumber <= 100)
                            iGrade = 1; // A

                        switch (iGrade)
                        {
                            case 1:
                                Console.WriteLine("You got a A!");
                                break;
                            case 2:
                                Console.WriteLine("You got a B!");
                                break;
                            case 3:
                                Console.WriteLine("You got a C!");
                                break;
                            case 4:
                                Console.WriteLine("You got a D!");
                                break;
                        }
                    }
                    else
                        Console.WriteLine("Data entered were not numbers, please rerun test.");
                }
            }
            while (sFormComplete == true);

            

            

            Console.ReadKey(true);
        }
    }
}
