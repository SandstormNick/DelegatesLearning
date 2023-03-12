//Declare a delegate
delegate void Del(int i, double j);

class MathClass
{
    static void Main()
    {
        MathClass m = new MathClass();

        //Delegate instatiation using "MultiplyNumbers"
        Del d = m.MultiplyNumbers;

        //Invoke the delegate object.
        Console.WriteLine("Invoking the delegate using 'MultiplyNumbers'");
        for (int i = 1; i <= 5; i++)
            d(i, 2);

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }

    //Declare the associated method.
    void MultiplyNumbers(int m, double n)
    {
        Console.WriteLine(m * n + " ");
    }
}