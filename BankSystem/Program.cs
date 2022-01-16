using BankSystem.Models;
using BankSystem.Controllers;
using System.Text.RegularExpressions;
using System.Text.Json;
using BankSystem.DA;
using System.Diagnostics;

public class program
{
    #region Global lists
    public static List<User> users = new List<User>();
    public static List<Customer> customers = new List<Customer>();
    public static List<Account> accounts = new List<Account>();
    public static List<Role> roles = new List<Role>();
    #endregion

    #region Global role instances
    public static Role ADMIN = new Role("Admin");
    public static Role TELLER = new Role("Teller");
    #endregion

    #region Global login variables 
    public static Role LOGGED_IN_ROLE=new();
    public static User LOGGED_IN_USER=new ();
    #endregion

    public static void Main(string[] args)
    {

        #region Create a system admin and system teller
        roles.Add(ADMIN);
        roles.Add(TELLER);
        User Admin1 = new User(true, Guid.NewGuid(), "nazeeh", "12345", "nazeeh_r@yahoo.com", 30, 3000, ADMIN.RoleId);
        User Teller1 = new User(true, Guid.NewGuid(), "sara", "12345", "nazeeh_r@yahoo.com", 30, 3000, TELLER.RoleId);
        users.Add(Admin1);
        users.Add(Teller1);
        #endregion

        login();
        BacktoMenu();

    }

    /// <summary>
    /// This function resposnible for showing the teller main menu and the logged in username
    /// </summary>
    public static void TellerMainMenu()
    {
        #region Menu
        Console.Write("*********** Teller Portal ***********");
        Console.WriteLine("     USER: {0}\r\n", LOGGED_IN_ROLE.RoleName);

        Console.WriteLine("1-Make a deposite to a customer account");
        Console.WriteLine("2-Make a withdraw to a customer account");
        Console.WriteLine("3-Logout\r\n");
        #endregion
    }
    /// <summary>
    /// This function resposnible for showing the teller main menu and the logged in username
    /// </summary>
    public static void AdminMainMenu()
    {
        #region Menu
        Console.Write("*********** Admin Portal ***********");

        Console.WriteLine("     USER: {0}\r\n", LOGGED_IN_USER.userName);

        Console.WriteLine("1-Register a customer");
        Console.WriteLine("2-Make a deposite to a customer account");
        Console.WriteLine("3-Make a withdraw to a custmer account");
        Console.WriteLine("4-Show all accounts");
        Console.WriteLine("5-Update customer");
        Console.WriteLine("6-Delete account");
        Console.WriteLine("7-Logout\r\n");
        #endregion

    }

    /// <summary>
    /// This function is responsible for getting a choice from user from 1-5 and call the related functions based on admin menu
    /// and the function will stuck in while loop until 1-5 is enterd by the user
    /// </summary>
    public static void AdminSelectChoice()
    {
        #region Reading choice and stay in loop until one of the choices is entered
        try
        {
            Console.Write("Please select a chioce: ");
            #region  Input validation
            Regex rx = new Regex("[1-6]{1}");
            #endregion          
            while (true)
            {
                string choice = Console.ReadLine();

                if (rx.IsMatch(choice))
                    switch (choice)
                    {
                        case "1": RegisterCustomer(); break;
                        case "2": Deposite(); break;
                        case "3": Withdraw(); break;
                        case "4": showAllAccounts(); break;
                        case "5": updateCustomer(); break;
                        case "6": deleteAccount(); break;
                        case "7": Logout(); break;
                    }
                else
                    BacktoMenu();
            }
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
        #endregion
    }

    /// <summary>
    /// This function is responsible for getting a choice from user from 1-3 and call the related functions based on teller menu
    /// and the function will stuck in while loop until 1-5 is enterd by the user
    /// </summary>
    public static void TellerSelectChoice()
    {
        #region Reading choice and stay in loop until one of the choices is entered

        try
        {
            Console.Write("Please select a chioce: ");
            #region  Input validation
            Regex rx = new Regex("[1-3]{1}");
            #endregion 
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
        catch (Exception ex) { Console.WriteLine(ex.Message); }
        #endregion

    }

    /// <summary>
    /// This function is used to get the needed data to create new customer and create a bank account for that customer
    /// </summary>

    public static void RegisterCustomer()
    {

        #region regex validators
        Regex emailValidator = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Regex usernameValidator = new Regex("[A-Za-z]");
        Regex ageValidator = new Regex("[1-9][8-9]");
        Regex accountTypeValidator = new Regex("[1-2]");
        #endregion

        #region function variables
        string name;
        string email;
        int age;
        int choice;
        #endregion

        #region read inputs and validate them
        try
        {

            Console.Clear();
            Console.WriteLine("***** Create Customer Account *****\r\n");

            Console.Write("Please Enter user name: ");
            while (true)
            {
                name = Console.ReadLine();
                if (usernameValidator.IsMatch(name))
                    break;
                else
                    Console.Write("   Wrong Input try other name:");
            }




            Console.Write("Please Enter user email: ");

            while (true)
            {
                email = Console.ReadLine();
                if (emailValidator.IsMatch(email))
                    break;
                else
                    Console.Write("   Wrong Input try other email:");
            }


            Console.Write("Please Enter user age: ");
            while (true)
            {
                var input = Console.ReadLine();

                if (ageValidator.IsMatch(input))
                {
                    age = Convert.ToInt32(input);

                    break;
                }
                else
                    Console.Write("  Wrong/Illeagal age,try another one:");
            }


            Console.Write("Please select account type: 1-Salary 2-Savings   ");

            while (true)
            {
                var input = Console.ReadLine();
                if (accountTypeValidator.IsMatch(input))
                {
                    choice = Convert.ToInt32(input);

                    break;
                }

                else
                    Console.Write("  Wrong account type Input try again:");
            }

            #endregion

            #region create the customer and its account
            Customer customer = AdminTransaction.CreateCustomer(name, email, age);
            customers.Add(customer);


            string type = (choice == 1) ? "Salary" : "Savings";
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
        catch (Exception ex) { Console.WriteLine(ex.Message); }

        #endregion

    }



    /// <summary>
    /// This function is responsible for printing the avaliable accounts in the system and their important info
    /// </summary>

    static void showAllAccounts()
    {
        #region validation
        if (accounts == null) return;
        #endregion

        #region printing data
        Console.Clear();
        Console.WriteLine("\r\n             IBAN                         AccountOwner             AccountType          AccountBalance      Status ");
        Console.WriteLine("------------------------------------------------------------------------------------------------------------------------");


        foreach (Account account in accounts)
        {
            string active = account.active ? "active" : "disactive";

            Customer customer = Search.getCustomer(customers, account.accountOwnerId);

            if (customer != null)
            {
                Console.WriteLine("{0}          {1}                      {2}                  {3}            {4}", account.accountIBAN, customer.customerName, account.accountType, account.accountBalance, active);

            }
        }

        Console.WriteLine("Press any key to continue..");
        Console.ReadLine();
        BacktoMenu();
        #endregion
    }

    /// <summary>
    /// This function is used to make a deposite process by entering the targeted IBAN and amount
    /// </summary>
    public static void Deposite()
    {
        #region Data validation
        if (customers == null || accounts == null)
        {
            Console.WriteLine("Feature not available");
            Console.Clear();
            BacktoMenu();
            return;
        }
        #endregion

        #region Find account
        try
        {
            Regex amoutValidator = new Regex(@"-?\d+(?:\.\d+)?");

            Console.Clear();
            Console.WriteLine("***** Deposition *****\r\n");
            Account account;
            Console.Write("Please enter the IBAN for the target account: ");
            var input = Console.ReadLine().Trim();
            if (Guid.TryParse(input, out var accountIBAN))
            {
                account = Search.getAccount(accounts, accountIBAN);

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

            #endregion

            #region Make depsoite
            Console.WriteLine("Cuurent Balance:{0} Nis", account.accountBalance);

            Console.Write("Please Enter the amount to deposite to the targeted account: ");
            while (true)
            {
                input = Console.ReadLine();
                if (amoutValidator.IsMatch(input))
                    break;
                else
                    Console.Write("Wrong input try again:");
            }
            double amount = Convert.ToDouble(input);
            int result = MakeTransaction.deposit(account, amount);

            switch (result.ToString())
            {
                case "1": Console.WriteLine($"Successfully deposited {amount} Nis, and your new balance become {account.accountBalance} Nis"); break;
                case "0": Console.WriteLine("Faild Transaction,Wrong withdraw input"); break;
            }
            Console.WriteLine("Press any key to continue..");
            Console.ReadLine();
            BacktoMenu();
            BacktoMenu();
        }
        catch (Exception ex) { Console.WriteLine(ex.ToString()); }
        #endregion
    }

    /// <summary>
    /// This function is used to make a withdraw process by entering the targeted IBAN and amount
    /// </summary>

    public static void Withdraw()
    {
        #region Data validation
        if (customers == null || accounts == null)
        {
            Console.WriteLine("Feature not available");
            Console.Clear();
            BacktoMenu();
            return;
        }
        #endregion

        #region Find Account
        try
        {
            Regex amoutValidator = new Regex(@"-?d*(?:\d*\.\d*)?$");


            Console.Clear();
            Console.WriteLine("***** Deposition *****\r\n");
            Account account;
            Console.Write("Please enter the IBAN for the target account: ");
            var input = Console.ReadLine().Trim();

            if (Guid.TryParse(input, out var accountIBAN))
            {
                account = Search.getAccount(accounts, accountIBAN);

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
            #endregion

            #region Make withdraw
            Console.WriteLine("Cuurent Balance:{0} Nis", account.accountBalance);
            Console.Write("Please Enter the amount to withdraw from your account: ");
            while (true)
            {
                input = Console.ReadLine().Trim();

                if (amoutValidator.IsMatch(input))
                    break;

                else
                    Console.Write("Wrong input try again:");
            }
            double amount = Convert.ToDouble(input);
            int result = MakeTransaction.withdraw(account, amount);
            switch (result.ToString())
            {
                case "1": Console.WriteLine($"Successfully deposited {amount} Nis, and your new balance become {account.accountBalance} Nis"); break;
                case "-1": Console.WriteLine("Failed Transaction,Can't fund the current amount your balance is less than {0}", amount); break;
                case "0": Console.WriteLine("Faild Transaction,Wrong withdraw input"); break;
            }
            Console.WriteLine("Press any key to continue..");
            Console.ReadLine();
            BacktoMenu();
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
        #endregion
    }

    /// <summary>
    /// This function is resposible for getting data from  DAL 
    /// </summary>
    public static void initialization()
    {
        try
        {
            customers = DataBaseConnections.getAllCustomers();
            accounts = DataBaseConnections.getAllAccounts();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    /// <summary>
    /// This funvtion is used for making login process to the system 
    /// </summary>
    public static void login()
    {
        try
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
                    LOGGED_IN_USER = Authentication.userLoginAuthentication(users, username, password);
                    if (LOGGED_IN_USER != null)
                    {
                        LOGGED_IN_ROLE = Search.getLoggedInUserRole(roles, LOGGED_IN_USER.roleID);
                        if (LOGGED_IN_ROLE != null)
                        {
                            Console.WriteLine($"WELCOME {LOGGED_IN_USER.userName} TO THE {LOGGED_IN_ROLE.RoleName} PORTAL");
                            initialization();
                            Console.WriteLine();
                            return;
                        }
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
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    /// <summary>
    /// This function requestes to save the accounts and customers data and set the logged user to null then call the login function
    /// </summary>
    public static void Logout()
    {
        DataBaseConnections.saveAccounts(accounts);
        DataBaseConnections.saveCustomers(customers);


        LOGGED_IN_USER = null;
        LOGGED_IN_ROLE = null;
        Console.Clear();
        login();
    }


    /// <summary>
    /// This function clear the screen and call the targeted menu and its select choice based on the logged-in user role
    /// </summary>
    public static void BacktoMenu()
    {
        Console.Clear();
        if (LOGGED_IN_ROLE.RoleName == "Admin")
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

    /// <summary>
    /// /This function is used to update customer records
    /// </summary>
    public static void updateCustomer()
    {

        #region regex validation
        Regex accountTypeValidator = new Regex("[1-4]");
        #endregion

        #region function variables
        Customer customer = null;

        #endregion


        #region Data validation
        if (customers == null || accounts == null)
        {
            Console.WriteLine("Feature not available");
            Console.Clear();
            BacktoMenu();
            return;
        }
        #endregion



        #region Find customer
        Console.Clear();
        Console.WriteLine("***** Update Customer *****\r\n");
        try
        {
            Console.Write("Please enter Customer ID: ");
            var input = Console.ReadLine().Trim();
            if (Guid.TryParse(input, out var customerID))
            {
                customer = Search.getCustomer(customers, customerID);

                if (customer == null)
                {
                    Console.WriteLine("Customer not found..");
                    Console.WriteLine("Press any key to continue..");
                    Console.ReadLine();
                    BacktoMenu();
                    return;
                }
            }
            else
            {
                Console.WriteLine("Invalid ID Format");
                Console.WriteLine("Press any key to continue..");
                Console.ReadLine();
                BacktoMenu();
                return;
            }
            #endregion


            #region validation
            if (customer == null)
            {
                Console.WriteLine("Error occurred , customer not found ");
                Console.Clear();
                BacktoMenu();
                return;
            }

            #endregion

        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }

        updateCustomerMenu(customer);
        updateCustomerMenuSelection(ref customer);
    }

    /// <summary>
    /// This function used to show update menu and the id of the customer we want to update 
    /// </summary>
    /// <param name="customer">the custmer object we want to make updates on</param>
    public static void updateCustomerMenu(Customer customer)
    {
        Console.Clear();
        Console.WriteLine("***** Update Customer: {0} *****\r\n", customer.customerId);
        Console.WriteLine("1- Update customer name");
        Console.WriteLine("2- Update customer email");
        Console.WriteLine("3- Update customer age");
        Console.WriteLine("4- Update customer's accounts");
        Console.WriteLine("5- Back");



    }

    /// <summary>
    /// THI
    /// </summary>
    /// <param name="customer"></param>
    public static void updateCustomerMenuSelection(ref Customer customer)
    {

        #region Reading choice and stay in loop until one of the choices is entered
        try
        {
            Console.Write("Please select a chioce: ");
            #region  Input validation
            Regex rx = new Regex("[1-5]{1}");
            #endregion          
            while (true)
            {
                string choice = Console.ReadLine();

                if (rx.IsMatch(choice))
                    switch (choice)
                    {
                        case "1":

                            Console.Write($"Current name: {customer.customerName}, Please enter the new name:");
                            var newCustomerName = Console.ReadLine();
                            customer.customerName = newCustomerName;
                            Console.WriteLine("Name has been updated sucessfully,press any key to continue..");
                            Console.ReadLine();
                            updateCustomerMenu(customer);
                            updateCustomerMenuSelection(ref customer);
                            ; break;
                        case "2":
                            Console.Write($"Current Email: {customer.customerEmail}, Please enter the new email:");
                            var newCustomerEmail = Console.ReadLine();
                            customer.customerEmail = newCustomerEmail;
                            Console.WriteLine("Name has been updated sucessfully,press any key to continue..");
                            Console.ReadLine();
                            updateCustomerMenu(customer);
                            updateCustomerMenuSelection(ref customer);




                            break;
                        case "3":
                            Console.Write($"Current age: {customer.customerAge}, Please enter the new age:");
                            int newCustomerage = Convert.ToInt32(Console.ReadLine());
                            customer.customerAge = newCustomerage;
                            Console.WriteLine("Name has been updated sucessfully,press any key to continue..");
                            Console.ReadLine();
                            updateCustomerMenu(customer);
                            updateCustomerMenuSelection(ref customer);


                            break;

                        case "4": updateAccount(); break;
                        case "5": BacktoMenu(); break;
                    }
                else
                    updateCustomerMenu(customer);
                updateCustomerMenuSelection(ref customer);
            }
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
        #endregion
    }
    /// <summary>
    /// This function is used for delete(Disactive an account)
    /// </summary>
    public static void deleteAccount()
    {

        Console.WriteLine("*** Delete Account ***");
        #region Data validation
        if (customers == null || accounts == null)
        {
            Console.WriteLine("Feature not available");
            Console.Clear();
            BacktoMenu();
            return;
        }
        #endregion

        #region Find account
        try
        {
            Regex amoutValidator = new Regex(@"-?\d+(?:\.\d+)?");

            Console.Clear();
            Console.WriteLine("***** Deposition *****\r\n");
            Account account;
            Console.Write("Please enter the IBAN for the target account: ");
            var input = Console.ReadLine().Trim();
            if (Guid.TryParse(input, out var accountIBAN))
            {
                account = Search.getAccount(accounts, accountIBAN);

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


            account.active = false;
            Console.WriteLine("Account deleted successfully!");
            Console.WriteLine("Press any key to continue..");
            Console.ReadLine();
            BacktoMenu();
        }

        #endregion

         




        catch { Console.WriteLine(); }
    }
    
    public static void updateAccount()
    {



    }

}
