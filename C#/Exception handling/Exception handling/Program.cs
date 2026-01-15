static void getNums()
{
    int x;
    int y;
    double ans;

    Console.Write("Enter number 1: ");
    x = Convert.ToInt32(Console.ReadLine());

    Console.Write("Enter number 2: ");
    y = Convert.ToInt32(Console.ReadLine());

    ans = x / y;

    Console.WriteLine("Answer is " + ans);
}

try
{
    Console.WriteLine("Enter numbers to divide\n");

    getNums();
}
catch (DivideByZeroException)
{
    Console.WriteLine("Thou shall not divide by zero!!!\n");
    getNums();
}
catch (FormatException)
{
    Console.WriteLine("Incorrect format");
    getNums();
}

Console.ReadKey();
