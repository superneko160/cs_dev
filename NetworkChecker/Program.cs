using System.Net;

// ユーザ入力
Console.Write("ホスト名を入力してください(ex: www.google.com): ");
string hostname = Console.ReadLine();

// 未入力の場合、実行中のマシンのホスト名（自分自身）を取得
if (hostname == null)
{
    hostname = Dns.GetHostName();
}

try
{
    // IPアドレスのリストを取得
    IPHostEntry entry = Dns.GetHostEntry(hostname);
    // IPアドレス取得
    IPAddress iPAddress = entry.AddressList[0];
    // 表示
    Console.WriteLine("IPアドレス: " + iPAddress.ToString());
}
catch(Exception ex)
{
    throw new Exception(ex.Message);
}