using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class ListSegments {
    static void Main(string[] args)
    {
        // パス取得
        string path = getPath();
        try
        {
            if (!Directory.Exists(path))
            {
                throw new DirectoryNotFoundException("指定されたパスが見つかりません");
            }
            // 指定されたディレクトリ内のファイルとディレクトリを取得
            IEnumerable<string> segments = Directory.EnumerateFileSystemEntries(path);
            // ファイルとディレクトリを表示
            foreach (string segment in segments) {
                Console.WriteLine(segment);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    static string getPath()
    {
        // コマンドライン引数を配列で取得する
        string[] cmds = Environment.GetCommandLineArgs();
        // コマンドライン引数があればそれを、なければ現在のディレクトリを取得
        return (cmds.Length > 1) ? cmds[1] : Directory.GetCurrentDirectory();
    }
}
