using BankSystem.Models;
using BankSystem.Controllers;
using System.Text.RegularExpressions;
using System.Text.Json;
using BankSystem.DA;

public class program
{
    public static List<User> users = new List<User>();
    public static List<Customer> customers = new List<Customer>();
    public static List<Account> accounts = new List<Account>();
    public static Role ADMIN = new Role("Admin");
    public static Role TELLER = new Role("Teller");
    public static List<Role> roles = new List<Role>();

    public static Role loggedinRole;
    public static User loggedinUser;

    public static void Main(string[] args)
    {

        roles.Add(ADMIN);
        roles.Add(TELLER);
        User Admin1 = new User("nazeeh", "nazeeh_r@yahoo.com", 23, ADMIN.RoleId, "12345");
        User Teller1 = new User("ahmad", "ahmad@gmail.com", 22, TELLER.RoleId, "1231");
        users.Add(Admin1);
        users.Add(Teller1);
     //   initialization();
        login();
        BacktoMenu();



    }

    public static void TellerMainMenu()
    {
        Console.Write("*********** Teller Portal ***********");
        Console.WriteLine("     USER: {0}\r\n", loggedinUser.userName);

        Console.WriteLine("1-Make a deposite to a customer account");
        Console.WriteLine("2-Make a withdraw to a customer account");
        Console.WriteLine("3-Logout\r\n");


    }

    public static void AdminMainMenu()
    {
        Console.Write("*********** Admin Portal ***********");

        Console.WriteLine("     USER: {0}\r\n", loggedinUser.userName);

        Console.WriteLine("1-Register a customer");
        Console.WriteLine("2-Make a deposite to a customer account");
        Console.WriteLine("3-Make a withdraw to a custmer account");
        Console.WriteLine("4-Show all accounts");
        Console.WriteLine("5-Logout\r\n");


    }

    public static void AdminSelectChoice()
    {
        Console.Write("Please select a chioce: ");
        Regex rx = new Regex("[1-5]");
        while (true)
        {
            string choice = Console.ReadLine();

            if (rx.IsMatch(choice))
                switch (choice)
                {
                    case "1": RegisterCustomer(); break;
                    case "2": Deposite(); break;
                    case "3": Withdraw(); break;
                    case "4": showAllAccounts();break;
                    case "5": Logout(); break;


                }
            else
                BacktoMenu();
        }

    }

    public static void TellerSelectChoice()
    {
        Console.Write("Please select a chioce: ");
        Regex rx = new Regex("[1-3]");
        while (true)
        {
            string choice = Console.ReadLine();

            if (rx.IsMatch(choice))
                switch (choice)
                {
                    case "1": Deposite(); break;
                    case "2": Withdraw(); break;
                    case "3": Logout(); break;



                }
            else
                BacktoMenu();
        }

    }






    public static void RegisterCustomer()
    {
        Console.Clear();
        Console.WriteLine("***** Create Customer Account *****\r\n");
        Console.Write("Please Enter user name: ");
        var name = Console.ReadLine();
        Console.Write("Please Enter user email: ");
        var email = Console.ReadLine();
        Console.Write("Please Enter user age: ");
        var input = Console.ReadLine();
        int age = Convert.ToInt32(input);

        Console.Write("Please select account type: 1-Salary 2- Savings");
        int choice = Convert.ToInt32(Console.ReadLine());

        Customer customer = AdminTransaction.CreateCustomer(name, email, age);
        customers.Add(customer);


        string type = (choice >= 0) ? "Salary" : "Savings";
        Account account = AdminTransaction.CreateBankAccount(type, customer.customerId);

        accounts.Add(account);
        customer.accountList.Add(account.accountIBAN);
        Console.WriteLine("\r\n");

        Console.WriteLine("Account has been created sucessfully!");
        Console.WriteLine("OwnerName: {0}, IBAN: {1}, Type: {2}", customer.customerName, account.accountIBAN, account.accountType);
        Console.WriteLine("Press any key to continue..");
        Console.ReadLine();

        BacktoMenu();



    }


    static void showAllAccounts()
    {
        Console.Clear();
        Console.WriteLine("\r\n             IBAN                         AccountOwner                    AccountType                  AccountBalance   ");
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");
        foreach (Account account in accounts)
        {
            Customer customer=Search.GetCustomer(customers,account.accountOwnerId);
            Console.WriteLine("{0}          {1}                         {2}                             {3}", account.accountIBAN,customer.customerName,account.accountType,account.accountBalance);
        }

        Console.WriteLine("Press any key to continue..");
        Console.ReadLine();
        BacktoMenu();

    }

    public static void Deposite()
    {

        Console.Clear();
        Console.WriteLine("***** Deposition *****\r\n");
        Account account;
        Console.Write("Please enter the IBAN for the target account: ");
        var input = Console.ReadLine().Trim();
        if (Guid.TryParse(input, out var accountIBAN))
        {
            account = Search.GetAccount(accounts, accountIBAN);

            if (account == null)
            {
                Console.WriteLine("Account not found..");
                Console.WriteLine("Press any key to continue..");
                Console.ReadLine();
                BacktoMenu();
                return;
            }

        }

        else
        {
            Console.WriteLine("Invalid IBAN Format");
            Console.WriteLine("Press any key to continue..");
            Console.ReadLine();
            BacktoMenu();
            return;
        }
        Console.WriteLine("Cuurent Balance:{0} Nis", account.accountBalance);

        Console.Write("Please Enter the amount to deposite to the targeted account: ");
        double amount = Convert.ToDouble(Console.ReadLine());
        MakeTransaction.deposit(account, amount);

        BacktoMenu();
    }


    public static void Withdraw()
    {


        Console.Clear();
        Console.WriteLine("***** Deposition *****\r\n");
        Account account;
        Console.Write("Please enter the IBAN for the target account: ");
        var input = Console.ReadLine().Trim();
        if (Guid.TryParse(input, out var accountIBAN))
        {
            account = Search.GetAccount(accounts, accountIBAN);

            if (account == null)
            {
                Console.WriteLine("Account not found..");
                Console.WriteLine("Press any key to continue..");
                Console.ReadLine();
                BacktoMenu();
                return;
            }
        }

        else
        {
            Console.WriteLine("Invalid IBAN Format");
            Console.WriteLine("Press any key to continue..");
            Console.ReadLine();
            BacktoMenu();
            return;
        }

        Console.WriteLine("Cuurent Balance:{0} Nis", account.accountBalance);
        Console.Write("Please Enter the amount to withdraw from your account: ");
        double amount = Convert.ToDouble(Console.ReadLine());
        MakeTransaction.withdraw(account, amount);
        BacktoMenu();
    }

    public static void initialization()
    {

        customers = DataBaseConnections.getAllCustomers();
        accounts = DataBaseConnections.getAllAccounts();

        Console.WriteLine(customers[0].customerId);
        Console.WriteLine(accounts[0]);
        Console.WriteLine("Connected to database..\r\n");


    }


    public static void login()
    {
        Console.WriteLine("Welcome to the bank system, Please login..\r\n");

        while (true)
        {
            Console.Write("UserName: ");
            var username = Console.ReadLine().Trim();
            Console.Write("Password: ");
            var password = Console.ReadLine();

            if (username != null && password != null)
            {
                loggedinUser = Authentication.UserLoginAuthentication(users, username, password);
                if (loggedinUser != null)
                {
                    loggedinRole = Search.GetLoggedInUserRole(roles, loggedinUser);
                    Console.WriteLine($"WELCOME {loggedinUser.userName} TO THE {loggedinRole.RoleName} PORTAL");
                    initialization();
                    Console.WriteLine();
                    return;
                }

                else
                    Console.Clear();
                Console.WriteLine("Invalid username/password, please try agian\r\n");

            }

            else
            {
                Console.Clear();

                Console.WriteLine("Invalid Input");

            }
        }
    }

    public static void Logout()
    {
        DataBaseConnections.SaveAccounts(accounts);
        DataBaseConnections.SaveCustomers(customers);


        loggedinUser = null;
        loggedinRole = null;
        Console.Clear();
        login();
    }



    public static void BacktoMenu()
    {
        Console.Clear();
        if (loggedinRole.RoleName == "Admin")
        {
            AdminMainMenu();
            AdminSelectChoice();
        }

        else
        {
            TellerMainMenu();
            TellerSelectChoice();
        }

    }

}
