namespace EvenorOdd
{
    internal class Program
    {
        static void oddeven() {
            int a = Convert.ToInt32(Console.ReadLine());
            if (a % 2 == 0)
                Console.WriteLine($"{a} is even.");
            else
                Console.WriteLine($"{a} is odd.");
        }
        static void Main(string[] args)
        {
            oddeven();
        }
    }
}