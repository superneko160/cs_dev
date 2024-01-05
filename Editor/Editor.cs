using System.Drawing.Printing;

namespace Editor
{
    internal class Editor : Form
    {
        private TextBox textbox;
        private ToolStrip toolStrip;
        private ToolStripButton[] tsButton = new ToolStripButton[7];
        private string fileFilter;
        internal static readonly string[] fileFilterData = new string[]
            {
                "テキスト文書|*.txt;*.text",
                "ログファイル|*.log"
            };
        private const int FORM_PADDING = 7;

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
            tsButton[5].Text = "Save as";
            tsButton[6].Text = "Find";
            // ツールチップテキスト
            tsButton[0].ToolTipText = "切り取り";
            tsButton[1].ToolTipText = "コピー";
            tsButton[2].ToolTipText = "貼り付け";
            tsButton[3].ToolTipText = "ファイル読み込み";
            tsButton[4].ToolTipText = "上書き保存";
            tsButton[5].ToolTipText = "新規保存";
            tsButton[6].ToolTipText = "検索";
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
            textbox.Height = this.Height;
            textbox.Location = new Point(0, 40);
            // フォームに紐づけ
            this.Controls.Add(toolStrip);
            this.Controls.Add(textbox);
            // ウィンドウリサイズ時のイベント追加
            this.Resize += new EventHandler(form_resize_event!);
            // 切り取り、コピー、貼り付けボタンのイベント追加
            for (int i = 0; i < 3; i++)
            {
                tsButton[i].Click += new EventHandler(basic_event!);
            }
            // 読み込み、上書き保存ボタンのイベント追加
            for (int i = 3;  i < 5; i++)
            {
                tsButton[i].Click += new EventHandler(dialog_event!);
            }
            // 新規保存ボタンのイベント追加
            for (int i = 5; i < 6; i++)
            {
                tsButton[i].Click += new EventHandler(save_dialog_event!);
            }
            // 検索ボタンのイベント追加
            for (int i = 6; i < tsButton.Length; i++)
            {
                tsButton[i].Click += new EventHandler(find_form_event!);
            }
        }

        /**
         * フォームリサイズ時のイベント処理
         */
        private void form_resize_event(object sender, EventArgs e)
        {
            // エディタの横幅をフォームに合わせて変更
            textbox.Width = this.Width;
            textbox.Height += this.Height;
        }

        /**
         * 基本処理ボタンのイベント処理
         */
        public void basic_event(object sender, EventArgs e)
        {
            // 切り取り
            if (sender == tsButton[0])
            {
                textbox.Cut();
            }
            // コピー
            else if (sender == tsButton[1])
            {
                textbox.Copy();
            }
            // 貼り付け
            else if (sender == tsButton[2])
            {
                textbox.Paste();
            }
        }

        /**
         * ファイルダイアログを表示するボタンのイベント処理
         */
        public void dialog_event(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = fileFilter;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // ファイル読み込み
                if (sender == tsButton[3])
                {
                    StreamReader streamReader = new StreamReader(dialog.FileName, System.Text.Encoding.Default);
                    textbox.Text = streamReader.ReadToEnd();
                    streamReader.Close();
                }
                // 既存ファイルに上書き保存
                else if (sender == tsButton[4])
                {
                    StreamWriter streamWriter = new StreamWriter(dialog.FileName);
                    streamWriter.WriteLine(textbox.Text);
                    streamWriter.Close();
                }
            }
        }

        /**
         * 新規保存ダイアログを表示するボタンのイベント処理
         */
        public void save_dialog_event(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = fileFilter;
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // ファイルに書き込み
                using (StreamWriter streamWriter = new StreamWriter(dialog.FileName))
                {
                    streamWriter.Write(textbox.Text);
                }
            }
        }

        /**
         * 検索フォームを表示するボタンのイベント処理
         */
        public void find_form_event(object sender, EventArgs e)
        {
            // 新しいフォームのインスタンス化
        }
    }
}