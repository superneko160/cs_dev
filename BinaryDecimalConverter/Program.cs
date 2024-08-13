// 10進数→2進数、2進数→10進数変換プログラム

Console.WriteLine("数値を入力してください：");

// 入力を受け取る（未入力だった場合は空文字列を用意）
string input = Console.ReadLine() ?? string.Empty;
Console.WriteLine(ConvertNumber(input));

// テスト用の入力配列
//string[] inputs = {
//    "1010", "15", "11111111", "255", "invalid", "1001"
//};

//foreach (var input in inputs)
//{
//    Console.WriteLine(ConvertNumber(input));
//    Console.WriteLine();  // 結果の間に空行を挿入
//}

/// <summary>
/// 入力された文字列を2進数または10進数として解釈し、結果を返す
/// </summary>
/// <param name="input">変換する数値（文字列）</param>
/// <returns>変換結果（文字列）</returns>
static string ConvertNumber(string input)
{
    if (string.IsNullOrEmpty(input))
    {
        return "入力が空です。";
    }

    if (IsBinary(input))
    {
        return $"2進数 {input} の10進数表現は {ConvertBinaryToDecimal(input)} です。";
    }

    if (int.TryParse(input, out int decimalValue))
    {
        return $"10進数 {input} の2進数表現は {ConvertDecimalToBinary(decimalValue)} です。";
    }

    return $"'{input}' は無効な入力です。2進数または10進数を入力してください。";
}

/// <summary>
/// 文字列が2進数表現か判定
/// </summary>
/// <param name="input">チェックする文字列</param>
/// <returns>入力された数値がすべて0か1であればtrue、条件に合致しなければfalse</returns>
static bool IsBinary(string input)
{
    return input.All(c => c == '0' || c == '1');
}

/// <summary>
/// 2進数文字列を10進数整数に変換
/// </summary>
/// <param name="binary">変換する2進数（文字列）</param>
/// <returns>変換された10進数（整数）</returns>
/// <exception cref="FormatException">入力文字列が無効な2進数形式の場合スロー</exception>
/// <exception cref="OverflowException">結果が Int32 の範囲を超える場合スロー</exception>
static int ConvertBinaryToDecimal(string binary)
{
    return Convert.ToInt32(binary, 2);
}

/// <summary>
/// 10進数整数を2進数文字列に変換
/// </summary>
/// <param name="decimal">変換する10進数（整数）</param>
/// <returns>変換された2進数（文字列）</returns>
static string ConvertDecimalToBinary(int decimalNumber)
{
    return Convert.ToString(decimalNumber, 2);
}
