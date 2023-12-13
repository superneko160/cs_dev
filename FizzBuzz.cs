using System;

class FizzBuzz
{
    public static void Main(string[] args)
    {
        for (int i = 1; i <= 100; i++)
        {
            Console.WriteLine(fizzbuzz(i));
        }
    }

    static string fizzbuzz(int num)
    {
        if (num % 3 == 0 && num % 5 == 0)
        {
            return "FizzBuzz";
        }
        if (num % 3 == 0)
        {
            return "Fizz";
        }
        if (num % 5 == 0)
        {
            return "Buzz";
        }
        return num.ToString();

        // C#8.0以上
        // string result = num switch
        // {
        //     int n when n % 3 == 0 && n % 5 == 0 => "FizzBuzz",
        //     int n when n % 3 == 0 => "Fizz",
        //     int n when n % 5 == 0 => "Buzz",
        //     _ => num.ToString(),
        // };
        // return result;
    }
}