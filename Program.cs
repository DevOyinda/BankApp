using System;
using System.IO;
using System.Text;
using System.Collections.Generic;



public class UserManagerClass
{
    public string Email;
    public string FullName;
    public string Password;
    public string FilePath = @"C:\Users\oyins\Desktop\Oyinda\FilesFolder\";

    public void Register()
    {       
        Console.WriteLine("Email Address:");
        Email = Console.ReadLine();
        Console.WriteLine("FullName:");
        FullName = Console.ReadLine();
        Console.WriteLine("Password:");
        Password = Console.ReadLine();
    }
    public void Login()
    {
        Console.WriteLine("Email Address:");
        Email = Console.ReadLine();
        Console.WriteLine("Password:");
        Password = Console.ReadLine();
    }

    public void RegisterFileCreation()
    {
        
        if (File.Exists($"{FilePath}{Email}.txt"))
        {
            Console.WriteLine("You have already registered"); // to go back to login  
        }
        else
        {
            using (StreamWriter sw = File.AppendText($"{FilePath}{Email}.txt"))
            {
                sw.WriteLine(FullName);
                sw.WriteLine(Email);
                sw.WriteLine(Password);
            }
            Console.WriteLine("Thank you for Registering to our app");// to go back to login
            
            /*string[] lines = File.ReadAllLines($"{FilePath}{Email}.txt");
            Console.WriteLine("Contents of the file = ");
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }*/
        }
    }

    public void PasswordVerification()
    {

        if (File.Exists($"{FilePath}{Email}.txt"))
        {
            string[] checkfile = File.ReadAllLines($"{FilePath}{Email}.txt");
            List<string> list = new List<string>();

            list.Add(Email);
            list.Add(Password);


            if (list[1] == checkfile[2])
            {
                Console.WriteLine("Welcome to Sukoko app"); // to go to account details class for next step               
            }
            else
            {
                Console.WriteLine("Incorrect Password"); 
            }
        }
        else
        {
            Console.WriteLine("Account not found");
            Console.WriteLine("Please proceed to registeration first");
        }
    }
}


public class AccountDetails
{
    
    public string FirstName;
    public string LastName;
    public string AccNum;
    public string Pin;
    public string Initialdeposit;
    public string FilePath = @"C:\Users\oyins\Desktop\Oyinda\";
    public string folderName = @"C:\Users\oyins\Desktop\Oyinda\BankDetails\";

    public static int amount = 1000;
    string amt = Convert.ToString(amount);

    public void CreateBankAccount()
    {
        Console.WriteLine("First Name:");
        FirstName = Console.ReadLine();
        Console.WriteLine("Last Name:");
        LastName = Console.ReadLine();
        Console.WriteLine("Account Number:");
        AccNum = Console.ReadLine();
        Console.WriteLine("Pin:");
        Pin = Console.ReadLine();
    }

    public void LoginBankAccount()
    {
        Console.WriteLine("Account Number");
        AccNum = Console.ReadLine();
        Console.WriteLine("Pin");
        Pin = Console.ReadLine();
    }

    public void BankDetailsFile()
    {
        if (File.Exists($"{folderName}{AccNum}.txt"))
        {
            Console.WriteLine("You have an account with us");
        }
        else
        {
            using (StreamWriter sw = File.AppendText($"{folderName}{AccNum}.txt"))
            {
                sw.WriteLine(FirstName);
                sw.WriteLine(LastName);
                sw.WriteLine(AccNum);
                sw.WriteLine(Pin);
                sw.WriteLine(amt);
            }
            Console.WriteLine("Thank you for opening an account with us");
        }
    }

    public void AccnumVerification()
    {
       

        if (File.Exists($"{folderName}{AccNum}.txt"))
        {
            string[] filecheck = File.ReadAllLines($"{folderName}{AccNum}.txt");

            List<string> list = new List<string>();

            list.Add(AccNum);
            list.Add(Pin);
            

            if (list[1] == filecheck[3])
            {
                Console.WriteLine("Hey" + FirstName + ", WELCOME!!!");
            }
            else
            {
                Console.WriteLine("Wrong Pin");
                
            }
        }
        else
        {
            Console.WriteLine("Incorrect Details");
            Console.WriteLine("Create an account with us before using our app"); //
        }
    }
}

public class BankAccount : AccountDetails
{
    int withdraw; int deposit;
    int current;
 

public void AccountBalance()
    {
        Console.WriteLine("Your current account balance is " + amount);
    }

    public void Withdrawal()
    {
        Console.WriteLine("Enter the amount to withdraw");
        withdraw = Convert.ToInt32(Console.ReadLine());
        if (amount > withdraw)
        {
            if (withdraw % 10 == 0)
            {
                Console.WriteLine("Please collect your cash " + withdraw);
                current = amount - withdraw;
                Console.WriteLine("The current balance is now " + current);
            }
            else
                Console.WriteLine("Please enter the amount in multiples of 10");
        }
        else
            Console.WriteLine("Your account doesn't have sufficient balance");
    }

    public void Deposit()
    {
        Console.WriteLine("Enter the amount to be deposited");
        deposit = Convert.ToInt32(Console.ReadLine());
        current = amount + deposit;
        Console.WriteLine("The current balance in the account is " + current);
    }

    public void Cancel()
    {
        Console.WriteLine("Thank You for Banking with us!");
    }

}


class Program
{
    static void Main()
    {
        string folderName = @"C:\Users\oyins\Desktop\Oyinda\BankDetails";
        // If directory does not exist, create it
        if (!Directory.Exists(folderName))
        {
            Directory.CreateDirectory(folderName);
        }
        Console.ReadLine();

    
        var input = "";
        int select;
        do
        {
            bool check = true;
            while (check)
            {
                Console.WriteLine("1.Login");
                Console.WriteLine("2.Register");
                Console.WriteLine("Pick an option: ");
                input = Console.ReadLine();
                if (!int.TryParse(input, out select))
                {
                    Console.WriteLine("Wrong input entered");
                }
                else
                {
                    switch (select)
                    {
                        case 1:
                            UserManagerClass umc = new UserManagerClass();
                            umc.Login();
                            umc.PasswordVerification();                          
                            break;

                        case 2:
                            UserManagerClass umc1 = new UserManagerClass();
                            umc1.Register();
                            umc1.RegisterFileCreation();
                            check = false;
                            break;
                            

                        default:
                            Console.WriteLine("Select the right option");
                            break;
                    }
                }
            }
        } while (!int.TryParse(input, out select));

        
        
        do
        {
            bool check = true;
            while (check)
            {
                Console.WriteLine("1.CreateAccount");
                Console.WriteLine("2.Login");
                Console.WriteLine("Pick an option: ");
                input = Console.ReadLine();
                if (!int.TryParse(input, out select))
                {
                    Console.WriteLine("Wrong input entered");
                }
                else
                {
                    switch (select)
                    {
                        case 1:
                            AccountDetails ad = new AccountDetails();
                            ad.CreateBankAccount();
                            ad.BankDetailsFile();                           
                            break;

                        case 2:
                            AccountDetails ad1 = new AccountDetails();
                            ad1.LoginBankAccount();
                            ad1.AccnumVerification();
                                                       
                            check = false;
                            break;

                        default:
                            Console.WriteLine("Select the right option");
                            break;
                    }
                }
            }
        } while (!int.TryParse(input, out select));

        int r;
        do
        {
            /*Console.WriteLine("Welcome to SUKOKO BANK");
            Console.WriteLine("Enter your Pin");
            //int pin = Convert.ToInt32(Console.ReadLine());

            var pin2 = int.TryParse(Console.ReadLine(), out r);

            if (pin2 == true)
            {*/
            bool check = true;
            while (check)
            {
                Console.WriteLine("1.Check Account Balance");
                Console.WriteLine("2.Withdraw Money");
                Console.WriteLine("3.Deposit Money");
                Console.WriteLine("4.Cancel");
                Console.Write("Enter your Choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        BankAccount account1 = new BankAccount();
                        account1.AccountBalance();
                        break;

                    case 2:
                        BankAccount account2 = new BankAccount();
                        account2.Withdrawal();
                        break;

                    case 3:
                        BankAccount account3 = new BankAccount();
                        account3.Deposit();
                        break;

                    case 4:
                        BankAccount account4 = new BankAccount();
                        account4.Cancel();
                        check = false;
                        break;

                    default:
                        Console.WriteLine("Select the right option");
                        break;
                }
            }
            /*else
                Console.WriteLine("Wrong input entered");
        }*/

        } while (!int.TryParse(Console.ReadLine(), out r));
    }
}


