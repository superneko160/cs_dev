using System.Diagnostics;

checkDateTime();
checkStopWatch();
checkRandom();

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