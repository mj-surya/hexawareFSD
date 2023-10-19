namespace Square
{
    internal class Program
    {
        static void square() {
            int a = Convert.ToInt32 (Console.ReadLine());
            Console.WriteLine (a*a);
        }
        static void Main(string[] args)
        {
            square();
        }
    }
}