namespace FirstApp
{
    internal class Program
    {
        static void CheckNumberStatus()//Method header
        {//body
            int num1 = GetARandomNumber();
            //Console.WriteLine("Please enter a number");
            //num1 = Convert.ToInt32(Console.ReadLine());
            if (num1 > 100)
                Console.WriteLine("Too big. The numebr is " + num1);
            else
                Console.WriteLine($"The number {num1} is Okay");
        }
        static int GetARandomNumber()
        {
            int num1 = new Random().Next(1, 200);
            return num1;
        }
        static void Main(string[] args)
        {
            //string name;
            //Console.WriteLine("Please enter your name");
            //name = Console.ReadLine();
            //Console.WriteLine("Welcome "+name);
            //Console.WriteLine($"Welcome {name}!!!");
            CheckNumberStatus();//method invocation

        }
    }
}