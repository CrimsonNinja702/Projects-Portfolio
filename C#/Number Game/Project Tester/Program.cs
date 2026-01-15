Random random = new Random();
Random random2 = new Random();
bool flag = true;
int num2 = random2.Next(1, 7);
int hp = 4;

Console.WriteLine("Welcome to Tyler's number game!\nHere you have 3 guesses to guess the correct number before you lose to the computer!\nGoodluck!!\n");

while (flag)
{
    hp --;

    if (hp == 0)
    {
        Console.WriteLine("Your HP is: " + hp);
        Console.WriteLine("You died! The number was " + num2);
        flag = false;
    }
    else
    {
        int num = random.Next(1, 7);

        Console.WriteLine("Your HP is: " + hp + "\nYou rolled a " + num);

        if (num == num2)
        {
            Console.WriteLine("You guessed correctly!");
            Console.WriteLine("The number was: " + num2);
            flag = false;
        }
        else
        {
            Console.WriteLine("Try again!\n");
            Console.Write("Would you like to roll again? Y/N: ");
            string ans = Convert.ToString(Console.ReadLine());

            ans = ans.ToUpper();

            if (ans == "Y")
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
        }
    }
}
Console.WriteLine("Thank you for playing!");
Console.ReadKey();
