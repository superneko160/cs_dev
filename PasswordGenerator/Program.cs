class Program
{
    static void Main(string[] args)
    {
        // パスワード生成に利用できる文字群を取得
        char[] chars = GetAllChars();

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
    /// 小文字アルファベット、大文字アルファベット、数字、および一般的な記号を含む配列を取得
    /// </summary>
    /// <returns>パスワードに利用可能な文字が含まれる配列</returns>
    public static char[] GetAllChars()
    {
        List<char> charList = new List<char>();

        // 小文字のアルファベット
        for (char c = 'a'; c <= 'z'; c++)
        {
            charList.Add(c);
        }

        // 大文字のアルファベット
        for (char c = 'A'; c <= 'Z'; c++)
        {
            charList.Add(c);
        }

        // 数字
        for (char c = '0'; c <= '9'; c++)
        {
            charList.Add(c);
        }

        // 記号
        charList.AddRange(new[] { '+', '-', '*', '/', '%', '?', '&', '_' });

        return charList.ToArray();
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