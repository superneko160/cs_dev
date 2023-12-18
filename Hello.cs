using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;

class Hello
{
    public static void Main()
    {
        Console.WriteLine("Hello, C#!!");
        Console.WriteLine(RuntimeInformation.FrameworkDescription);

        int[] nums = new int[]{10, 11, 12};
        foreach (int num in nums)
        {
            Console.Write(num + " ");
        }

        List<int> list = new List<int>(){13, 14};
        list.Add(15);
        foreach (int num in list)
        {
            Console.Write(num + " ");
        }
        Console.WriteLine();
    }
}