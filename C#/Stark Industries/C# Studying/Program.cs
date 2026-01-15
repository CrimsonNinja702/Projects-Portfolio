bool flag = true;
string username1 = "", password1 = "";

static void Menu() 
{
    Console.WriteLine("WELCOME TO S.T.A.R.K INDUSTRIES\n" +
                  "-------------------------------\n\nPlease select an option\n" +
                  "1. Log in\n" +
                  "2. Sign up\n" +
                  "3. Exit\n");
}

while (flag) 
{
    Menu();

    int choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        case 1:
            Console.Write("Please enter username: ");
            string username = Console.ReadLine();

            if (username == username1)
            {
                Console.Write("Please enter password: ");
                string password = Console.ReadLine();

                if (password == password1)
                {
                    Console.WriteLine("\nWelcome " + username + "\n");
                }
                else
                {
                    Console.WriteLine("\nPassword incorrect " + "\n");
                }
            }
            else
            {
                Console.WriteLine("\nUsername " + username + " does not exist\n");
            }
            break;

        case 2:
            Console.Write("Please enter name: ");
            string name = Console.ReadLine().ToLower().Replace(" ", "");

            Console.Write("Please enter password: ");
            password1 = Console.ReadLine();

            username1 = name + "@starkindustries";

            Console.WriteLine("Username created! Welcome " + username1 + "\n");

            break;

        case 3:
            Console.WriteLine("Exiting...");
            flag = false;
            break;

        default:
            Console.WriteLine("Please select an option from the menu\n");
            break;
    }
}

Console.ReadKey();