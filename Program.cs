namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("please enter Name student");
            String Name = Console.ReadLine();

            Console.WriteLine("enter exam score");
            double score = double.Parse(Console.ReadLine());

            Console.WriteLine("enter Attendence rate");
            double attendence = double.Parse(Console.ReadLine());

            if (score < 0 || score > 100 || attendence < 0 || attendence > 100)
            {
                Console.WriteLine("invalid input : value must be betwwen 0 and 100");
                return;
            }
            if (attendence < 75)
            {
                Console.WriteLine("invalid ");
                return;
            }
            if (score >= 90)
            {
                Console.WriteLine("grade:A Excelent");

            }
            else if (score >= 80)
            {
                Console.WriteLine("grade : B vry good");
            }
            else if (score >= 70)
            {
                Console.WriteLine("grade :c good");

            }
            else if (score >= 50)
            {
                Console.WriteLine("grad : D pass");
            }
            else
            {
                Console.WriteLine("grade : f fail");
            }
        }

    }
    
}
