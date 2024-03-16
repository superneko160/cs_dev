class Program
{
    static void Main(string[] args)
    {
        char[] chars = [
            'a', 'b', 'c', 'd', 'e', 'f',
            'A', 'B', 'C', 'D', 'E', 'F',
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9',
            '+', '-', '*', '/', '%', '?', '&', '_'
        ];
        Random rand = new Random();
        rand.Shuffle(chars);

        string password = GeneratePassword(chars, 7);
        Console.WriteLine(password);
    }

    /// <summary>
    /// ランダムな文字列を生成する関数
    /// </summary>
    /// <param name="chars">使用可能な文字の配列</param>
    /// <param name="passwordLength">生成するパスワードの長さ</param>
    /// <returns>ランダムに生成されたパスワード文字列</returns>
    static string GeneratePassword(char[] chars, int passwordLength)
    {
        string password = "";
        for (int i = 0; i < passwordLength; i++)
        {
            password += chars[i];
        }
        return password;
    }
}