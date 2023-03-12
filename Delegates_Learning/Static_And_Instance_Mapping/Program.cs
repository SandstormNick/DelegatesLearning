// Declare a delegate
delegate void Del();

class SampleClass
{
    public void InstanceMethod()
    {
        Console.WriteLine("A message from the instance method.");
    }

    static public void StaticMethod()
    {
        Console.WriteLine("A message from the static method.");
    }
}

class TestSampleClass
{
    static void Main()
    {
        var sc = new SampleClass();

        //Map the delegate to the instance method:
        Del d = sc.InstanceMethod;
        d();

        //Map to the static method
        d = SampleClass.StaticMethod;
        d();
    }
}