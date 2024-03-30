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

        // Guid.NewGuid().GetHashCode() 生成される乱数の順序が毎回異なるように設定
        Random rand = new Random(Guid.NewGuid().GetHashCode());
        rand.Shuffle(chars);

        // ユーザがパスワードの長さを入力
        Console.Write("Enter the desired password length: ");
        int passwordLength;
        if (int.TryParse(Console.ReadLine(), out passwordLength) && passwordLength > 0)
        {
            string password = GeneratePassword(chars, passwordLength, rand);
            Console.WriteLine($"Password: {password}");
        }
        else
        {
            Console.WriteLine("Invalid password length. Please enter a positive integer.");
        }
    }

    /// <summary>
    /// ランダムな文字列を生成する関数
    /// </summary>
    /// <param name="chars">使用可能な文字の配列</param>
    /// <param name="passwordLength">生成するパスワードの長さ</param>
    /// <param name="rand">Randomオブジェクト</param>
    /// <returns>ランダムに生成されたパスワード文字列</returns>
    static string GeneratePassword(char[] chars, int passwordLength, Random rand)
    {
        char[] password = new char[passwordLength];

        for (int i = 0; i < passwordLength; i++)
        {
            password[i] = chars[rand.Next(chars.Length)];
        }

        return new string(password);
    }
}