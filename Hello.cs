using System;
using System.Runtime.InteropServices;

class Hello
{
    public static void Main()
    {
        Console.WriteLine("Hello, C#!!");
        Console.WriteLine(RuntimeInformation.FrameworkDescription);

        int[] nums = new int[]{10, 11, 12};
        foreach (int num in nums) {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}