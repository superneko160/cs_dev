using System.Text.RegularExpressions;

namespace Editor
{
    class FindForm : Form
    {
        private TextBox textbox;
        private Button button;
        private RichTextBox editorTextBox;

        /**
         * コンストラクタ
         */
        public FindForm(RichTextBox editorTextBox)
        {
            // エディタのテキストボックス
            this.editorTextBox = editorTextBox;
            // フォーム
            this.Text = "検索";
            this.Width = 350;
            this.Height = 200;
            // 検索ボックス
            textbox = new TextBox();
            textbox.Width = 200;
            textbox.Height = 50;
            // 検索ボタン
            button = new Button();
            button.Width = 70;
            button.Height = 50;
            button.Text = "Find";
            // 部品をフォームに紐づけ
            textbox.Location = new Point(0, 0);
            button.Location = new Point(0, textbox.Height);
            textbox.Parent = this;
            button.Parent = this;
            // イベント追加
            button.Click += new EventHandler(find_event!);
        }

        /**
         * 検索ボタンのイベント
         */
        private void find_event(object sender, EventArgs e)
        {
            // エディタの背景色を白に戻す（リセット）
            editorTextBox.SelectAll();
            editorTextBox.SelectionBackColor = Color.White;

            Regex rx = new Regex(textbox.Text);
            Match? match = null;
            for (
                match = rx.Match(editorTextBox.Text);
                match.Success;
                match = match.NextMatch())
            {
                // マッチした文字列を赤色に変更
                editorTextBox.Select(match.Index, match.Length);
                editorTextBox.SelectionBackColor = Color.Yellow;
            }
            // キャレット位置を最後尾に移動して選択を解除
            editorTextBox.Select(editorTextBox.TextLength, 0);
            // 検索フォームを閉じる
            this.Close();
        }
    }
}
