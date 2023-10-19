namespace AverageofTen
{
    internal class Program
    {
        static void average()
        {
            int a = 0;
            for(int i = 0; i < 10; i++)
            {
                int b= Convert.ToInt32(Console.ReadLine());
                a+= b;
            }
            double avg = a / 10;
            Console.WriteLine("Average of 10 numbers is "+avg);
        }
        static void Main(string[] args)
        {
            average();
        }
    }
}