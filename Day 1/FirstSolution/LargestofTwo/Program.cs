namespace LargestofTwo
{
    internal class Program
    {
        static void largest() { 
            int a=Convert.ToInt32(Console.ReadLine());
            int b=Convert.ToInt32(Console.ReadLine());
            if (a > b)
                Console.WriteLine($"{a} is greater than {b}");
            else Console.WriteLine($"{b} is greater than {a}");
        
        }
        static void Main(string[] args)
        {
            largest();
        }
    }
}