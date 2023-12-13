using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

class ListSegments {

    /**
     * メイン処理
     */
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
            IEnumerable<string> entries = Directory.EnumerateFileSystemEntries(path);
            // ファイルとディレクトリを表示
            foreach (string entry in entries)
            {
                FileAttributes attributes = File.GetAttributes(entry);
                string info = getEntryInfo(attributes);
                Console.Write(info);
                Console.WriteLine(entry);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    /**
     * パス取得
     */
    static string getPath()
    {
        // コマンドライン引数を配列で取得する
        string[] cmds = Environment.GetCommandLineArgs();
        // コマンドライン引数があればそれを、なければ現在のディレクトリを取得
        return (cmds.Length > 1) ? cmds[1] : Directory.GetCurrentDirectory();
    }

    /**
     * ファイル、ディレクトリの情報取得
     */
    static string getEntryInfo(FileAttributes attributes)
    {
        char[] info = new char[]{'-', '-', '-', '-'};
        // ディレクトリ
        if ((attributes & FileAttributes.Directory) != 0)
        {
            info[0] = 'd';
        }
        // 読み込み専用
        if ((attributes & FileAttributes.ReadOnly) != 0)
        {
            info[1] = 'r';
        }
        // 隠しファイル
        if ((attributes & FileAttributes.Hidden) != 0)
        {
            info[2] = 'h';
        }
        // システムファイル
        if ((attributes & FileAttributes.System) != 0)
        {
            info[3] = 's';
        }
        // 文字列にしてリターン
        return new string(info);
    }
}
