﻿using System.Diagnostics;

List<int> list = new List<int> { 1, 84, 95, 95, 40, 6 };

checkDateTime();
checkStopWatch();
checkRandom();
checkLambda(list);
checkBasicLinq(list);
checkDistinctLinq(list);
checkToArrayLinq(list);

static void checkDateTime()
{
    DateTime dt = DateTime.Now;

    // 2024/02/06 23:30:41
    Console.WriteLine(dt.ToString());

    // 2024/02/06
    Console.WriteLine(dt.ToShortDateString());

    // 2024年2月6日
    Console.WriteLine(dt.ToLongDateString());

    // 23:38
    Console.WriteLine(dt.ToShortTimeString());

    // 23:38:10
    Console.WriteLine(dt.ToLongTimeString());

    // 2024-02-06 23-38-10
    Console.WriteLine(dt.ToString("yyyy-MM-dd HH-mm-ss"));

    // 24年38月6日(火) 午後11時38分10秒
    Console.WriteLine(dt.ToString("y年m月d日(ddd) tth時m分s秒"));
}

static void checkStopWatch()
{
    Stopwatch sw = new Stopwatch();
    sw.Start();  // 計測開始
    //int number = 0;
    for (int i = 0; i < 999999; i++)
    {
        //number++;
    }
    sw.Stop();  // 計測終了
    long result = sw.ElapsedMilliseconds;  // 計測結果（ミリ秒）
    Console.WriteLine(result.ToString());
}

static void checkRandom()
{
    Random random = new Random();

    // 0以上6未満の整数をランダムに生成
    Console.WriteLine(random.Next(6));
    // -10以上11未満の整数をランダムに生成
    Console.WriteLine(random.Next(-10, 11));
}

static void checkLambda(List<int> list)
{
    // list の要素から偶数を取り出す（FindAllの引数内にラムダ式使用）
    List<int> findAllList = list.FindAll(num => num % 2 == 0);
    Console.WriteLine("=== findAllList ===");
    foreach (int num in findAllList)
    {
        Console.WriteLine(num);
    }

    // list の要素をそれぞれ 3 倍にする（ConvertAllの引数内にラムダ式使用）
    List<int> convertAllList = list.ConvertAll(num => num * 3);
    Console.WriteLine("=== convertAllList ===");
    foreach (int num in convertAllList)
    {
        Console.WriteLine(num);
    }
}

static void checkBasicLinq(List<int> list)
{
    // list の最初の要素を取得
    Console.WriteLine("First: " + list.First());
    // list の最後の要素を取得
    Console.WriteLine("Last: " + list.Last());
    // list の最大値を取得
    Console.WriteLine("Max: " + list.Max());
    // list の最小値を取得
    Console.WriteLine("Min: " + list.Min());
    // list の平均値を取得
    Console.WriteLine("Average: " + list.Average());
    // list の合計値を取得
    Console.WriteLine("Sum: " + list.Sum());
    // list の要素値を取得
    Console.WriteLine("Count: " + list.Count());
    // list のすべての要素が 84 未満かどうか
    Console.WriteLine("All: " + list.All(x => x < 84));  // False
    // list のいずれかの要素が 84 未満かどうか
    Console.WriteLine("Any: " + list.Any(x => x < 84));  // True
    // list に値が 40 の要素が含まれてるかどうか
    Console.WriteLine("Contains: " + list.Contains(40));  // True
}

static void checkDistinctLinq(List<int> list)
{
    // list から重複を除いた要素を取得
    var distinctList = list.Distinct();
    Console.WriteLine("=== distinctList ===");
    //Console.WriteLine(distinctList.GetType().Name);
    foreach (int num in distinctList)
    {
        Console.WriteLine(num);
    }
}

static void checkToArrayLinq(List<int> list)
{
    // list を配列に変換
    int[] numbers = list.ToArray();
    Console.WriteLine("=== array ===");
    Console.WriteLine(numbers.GetType().Name);
    foreach (int num in numbers)
    {
        Console.WriteLine(num);
    }
}