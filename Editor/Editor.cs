namespace Editor
{
    internal class Editor : Form
    {
        private TextBox textbox;
        private ToolStrip toolStrip;
        private ToolStripButton[] tsButton = new ToolStripButton[5];
        private String fileFilter;
        internal static readonly string[] fileFilterData = new string[]
            {
                "テキスト文書|*.txt;*.text",
                "タブ区切り値|*.tsv",
                "カンマ区切り値|*.csv",
                "ログファイル|*.log"
            };

        /**
         * コンストラクタ
         */
        public Editor()
        {
            // ファイルダイアログのフィルタ設定
            fileFilter = String.Join("|", fileFilterData);
            // フォームのタイトル、横幅、高さ
            this.Text = "テキストエディタ";
            this.Width = 900;
            this.Height = 720;
            // ツールバー（ボタン）
            for (int i = 0; i < tsButton.Length; i++)
            {
                tsButton[i] = new ToolStripButton();
            }
            tsButton[0].Text = "Cut";
            tsButton[1].Text = "Copy";
            tsButton[2].Text = "Paste";
            tsButton[3].Text = "Load";
            tsButton[4].Text = "Save";
            // ツールチップテキスト
            tsButton[0].ToolTipText = "切り取り";
            tsButton[1].ToolTipText = "コピー";
            tsButton[2].ToolTipText = "貼り付け";
            tsButton[3].ToolTipText = "ファイル読み込み";
            tsButton[4].ToolTipText = "ファイル保存";
            // ツールチップテキストの追加
            toolStrip = new ToolStrip();
            for (int i = 0; i < tsButton.Length; i++)
            {
                toolStrip.Items.Add(tsButton[i]);
            }
            // テキストボックス（エディタ部分）
            textbox = new TextBox();
            textbox.Multiline = true;
            textbox.Width = this.Width;
            textbox.Height = this.Height - 100;
            textbox.Location = new Point(0, 40);
            // フォームに紐づけ
            toolStrip.Parent = this;
            textbox.Parent = this;
            // 切り取り、コピー、貼り付けボタンのイベント追加
            for (int i = 0; i < 3; i++)
            {
                tsButton[i].Click += new EventHandler(basic_event!);
            }
            // 読み込み、書き込みボタンのイベント追加
            for (int i = 3;  i < tsButton.Length; i++)
            {
                tsButton[i].Click += new EventHandler(dialog_event!);
            }
        }

        /**
         * 基本処理ボタンのイベント処理
         */
        public void basic_event(Object sender, EventArgs e)
        {
            if (sender == tsButton[0])
            {
                textbox.Cut();
            }
            else if (sender == tsButton[1])
            {
                textbox.Copy();
            }
            else if (sender == tsButton[2])
            {
                textbox.Paste();
            }
        }

        /**
         * ファイルダイアログを表示するボタンのイベント処理
         */
        public void dialog_event(Object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = fileFilter;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (sender == tsButton[3])
                {
                    StreamReader streamReader = new StreamReader(dialog.FileName, System.Text.Encoding.Default);
                    textbox.Text = streamReader.ReadToEnd();
                    streamReader.Close();
                }
                // 既存ファイルで保存（新規作成で保存は未実装）
                else if (sender == tsButton[4])
                {
                    StreamWriter streamWriter = new StreamWriter(dialog.FileName);
                    streamWriter.WriteLine(textbox.Text);
                    streamWriter.Close();
                }
            }
        }
    }
}
