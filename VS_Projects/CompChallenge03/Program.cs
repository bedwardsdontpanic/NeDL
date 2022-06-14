using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

#pragma warning disable 8604, 8600, 8601, 8602, 8603
namespace competencyChallenege03
{
    public class Program
    {
        public static void Main()
        {
            ILogger logger = new FileLogger();
            ProductService productService = new ProductService(logger);
            runProgram(productService);

        }

        static List<BankAccount> loadFileIntoList()
        {

            string[] theText = File.ReadLines("D:\\Workspaces\\NeDL\\VS_Projects\\CompChallenge03\\BankAccounts.txt").ToArray();
            List<BankAccount> theAccounts = new List<BankAccount>();
            for (int i = 0; i < theText.Count(); i++)
            {
                if (theText[i] != "" && theText[i] != null)
                {

                    string[] splitit = theText[i].Split('|');

                    if (splitit[1] == "Checkings")
                    {
                        Checkings newAccount = new Checkings(Convert.ToInt32(splitit[0]), splitit[1], Convert.ToDouble(splitit[2]), Convert.ToDouble(splitit[3]));
                        theAccounts.Add(newAccount);
                    }
                    else if (splitit[1] == "Savings")
                    {
                        Savings newAccount = new Savings(Convert.ToInt32(splitit[0]), splitit[1], Convert.ToDouble(splitit[2]), Convert.ToDouble(splitit[3]));
                        theAccounts.Add(newAccount);
                    }
                    else
                    {
                        CD newAccount = new CD(Convert.ToInt32(splitit[0]), splitit[1], Convert.ToDouble(splitit[2]), Convert.ToDouble(splitit[3]), Convert.ToDouble(splitit[4]));
                        theAccounts.Add(newAccount);
                    }
                }
            }

            return theAccounts;
        }

        static void saveAccountIntoFile(BankAccount theAccount)
        {
            List<BankAccount> theAccounts = new List<BankAccount>();
            theAccounts = loadFileIntoList();

            using (StreamWriter SW = new StreamWriter("BankAccounts.txt"))
            {

                foreach (BankAccount currentAccount in theAccounts)
                {

                    if (currentAccount.accountId != theAccount.accountId)
                    {
                        SW.WriteLine(currentAccount.toFileFormat());
                    }

                    else
                    {
                        SW.WriteLine(theAccount.toFileFormat());
                    }
                }
            }

        }

        static void readAccounts()
        {

            List<BankAccount> theAccounts = new List<BankAccount>();
            theAccounts = loadFileIntoList();

            foreach (BankAccount theAccount in theAccounts)
            {
                Console.WriteLine(theAccount);
            }

            Console.WriteLine("\nReturning to main menu...\n");
        }

        static void withdrawMenu()
        {
            string theId = "";
            do
            {
                Console.Write("Enter the account number: ");
                theId = Console.ReadLine();
            }
            while (validateInt(theId) == false || GetAccount(Convert.ToInt32(theId)) == null);

            BankAccount theAccount = GetAccount(Convert.ToInt32(theId));
            string withdrawAmountEntry = "";

            do
            {
                Console.Write("Your balance for the " + theAccount.accountType + " account is $" + theAccount.currentBalance + ". Enter an amount to withdraw: ");
                withdrawAmountEntry = Console.ReadLine();
            }
            while (validateDouble(withdrawAmountEntry) == false || theAccount.withdraw(Convert.ToDouble(withdrawAmountEntry)) == false);

            double withdrawAmount = Convert.ToDouble(withdrawAmountEntry);

            saveAccountIntoFile(theAccount);
        }

        static void depositMenu()
        {
            string theId = "";
            do
            {
                Console.Write("Enter the account number: ");
                theId = Console.ReadLine();
            }
            while (validateInt(theId) == false || GetAccount(Convert.ToInt32(theId)) == null);

            BankAccount theAccount = GetAccount(Convert.ToInt32(theId));
            string depositAmountEntry = "";

            do
            {
                Console.Write("Your balance for the " + theAccount.accountType + " account is $" + theAccount.currentBalance + ". Enter an amount to deposit: ");
                depositAmountEntry = Console.ReadLine();
            }
            while (validateDouble(depositAmountEntry) == false);

            double depositAmount = Convert.ToDouble(depositAmountEntry);
            theAccount.deposit(depositAmount);
            saveAccountIntoFile(theAccount);
        }

        static BankAccount GetAccount(int theId)
        {
            List<BankAccount> theAccounts = new List<BankAccount>();
            theAccounts = loadFileIntoList();

            foreach (BankAccount currentAccount in theAccounts)
            {
                if (currentAccount.accountId == theId && currentAccount.accountType == "Checkings")
                {
                    return (Checkings)currentAccount;
                }
                else if (currentAccount.accountId == theId && currentAccount.accountType == "Savings")
                {
                    return (Savings)currentAccount;
                }
                else if (currentAccount.accountId == theId && currentAccount.accountType == "CD")
                {
                    return (CD)currentAccount;
                }
            }

            Console.WriteLine("Invalid account number... ");
            return null;
        }

        static bool validateSelection(string s)
        {

            if (Char.TryParse(s, out char x) == true && (x == 'L' || x == 'D' || x == 'W' || x == 'Q'))
            {
                return true;
            }

            else
            {
                Console.WriteLine("\nInvalid selection. Try again. ");
                return false;
            }
        }

        static bool validateDouble(string s)
        {

            if (double.TryParse(s, out double x) == true && x >= 0)
            {
                return true;
            }

            else
            {
                Console.WriteLine("\nInvalid input. Try again... ");
                return false;
            }
        }

        static bool validateInt(string s)
        {

            if (Int32.TryParse(s, out int x) == true && x >= 0)
            {
                return true;
            }

            else
            {
                Console.WriteLine("\nInvalid input. Try again... ");
                return false;
            }
        }

        static void runProgram(ProductService productService)
        {

            string input;
            char selection = 'z';
            bool charCheck = false;

            do
            {
                Console.Write("What would you like to do? Type the letter to choose \nL) List all accounts \nD) Open deposit menu \nW) Open withdrawl menu \nQ) Quit the program \n");
                input = Console.ReadLine();
                input = input.ToUpper();
                charCheck = validateSelection(input);

                if (charCheck == false)
                {
                    continue;
                }

                selection = Convert.ToChar(input);

                switch (selection)
                {
                    case 'L':
                        Console.WriteLine("Listing All Bank Accounts...\n");
                        readAccounts();
                        continue;

                    case 'D':
                        Console.WriteLine("Opening Deposit Menu...\n");
                        depositMenu();
                        break;

                    case 'W':
                        Console.WriteLine("Opening Withdraw Menu...\n");
                        withdrawMenu();
                        continue;

                    case 'Q':
                        Console.WriteLine("\nExiting program...\n");
                        break;

                    default:
                        Console.WriteLine("\n\nInvalid input... Re-enter please.");
                        continue;
                }

            }

            while (selection != 'Q');
        }


    }


}