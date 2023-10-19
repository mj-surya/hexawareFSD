namespace primenumber
{
    internal class Program
    {
        static void prime() {
            int n = Convert.ToInt32 (Console.ReadLine());   
            int a = 0;
            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0)
                {
                    a++;
                }
            }
            if (a == 2)
                Console.WriteLine($"{n} is a prime number");
            else
                Console.WriteLine($"{n} is not a prime number");
        }
        static void Main(string[] args)
        {
            prime();
        }
    }
}