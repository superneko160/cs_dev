﻿namespace Editor
{
    internal class Editor : Form
    {
        private RichTextBox textbox;
        private ToolStrip toolStrip;
        private ToolStripButton[] tsButton = new ToolStripButton[8];
        private string fileFilter;
        internal static readonly string[] fileFilterData = new string[]
            {
                "テキスト文書|*.txt;*.text",
                "ログファイル|*.log"
            };
        private FindForm findForm;
        private ReplaceForm replaceForm;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Editor()
        {
            // フォームがすべてのキーイベントを受け取るようにする
            KeyPreview = true;

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
            tsButton[7].Text = "Replace";
            // ツールチップテキスト
            tsButton[0].ToolTipText = "切り取り";
            tsButton[1].ToolTipText = "コピー";
            tsButton[2].ToolTipText = "貼り付け";
            tsButton[3].ToolTipText = "ファイル読み込み";
            tsButton[4].ToolTipText = "上書き保存";
            tsButton[5].ToolTipText = "新規保存";
            tsButton[6].ToolTipText = "検索";
            tsButton[7].ToolTipText = "置換";
            // ツールチップテキストの追加
            toolStrip = new ToolStrip();
            for (int i = 0; i < tsButton.Length; i++)
            {
                toolStrip.Items.Add(tsButton[i]);
            }
            // テキストボックス（エディタ部分）
            textbox = new RichTextBox();
            textbox.Multiline = true;
            textbox.Width = this.Width;
            textbox.Height = this.Height;
            textbox.Location = new Point(0, 40);
            // フォームに紐づけ
            this.Controls.Add(toolStrip);
            this.Controls.Add(textbox);

            // ウィンドウリサイズ時のイベント追加
            this.Resize += new EventHandler(form_resize_event!);
            // 特定のキー押下時のイベント
            this.KeyDown += new KeyEventHandler(keydown_event!);
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
            for (int i = 6; i < 7; i++)
            {
                tsButton[i].Click += new EventHandler(find_form_event!);
            }
            // 置換ボタンのイベント追加
            for (int i = 7; i < tsButton.Length; i++)
            {
                tsButton[i].Click += new EventHandler(replace_form_event!);
            }
        }

        /// <summary>
        /// フォームリサイズ時のイベント処理
        /// </summary>
        /// <param name="sender">イベント発生源</param>
        /// <param name="e">イベント引数</param>
        private void form_resize_event(object sender, EventArgs e)
        {
            // エディタの横幅をフォームに合わせて変更
            textbox.Width = this.Width;
            textbox.Height += this.Height;
        }

        /// <summary>
        /// 基本処理ボタンのイベント処理
        /// </summary>
        /// <param name="sender">イベント発生源</param>
        /// <param name="e">イベント引数</param>
        private void basic_event(object sender, EventArgs e)
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

        /// <summary>
        /// ファイルダイアログを表示するボタンのイベント処理
        /// </summary>
        /// <param name="sender">イベント発生源</param>
        /// <param name="e">イベント引数</param>
        private void dialog_event(object sender, EventArgs e)
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

        /// <summary>
        /// 新規保存ダイアログを表示するボタンのイベント処理
        /// </summary>
        /// <param name="sender">イベント発生源</param>
        /// <param name="e">イベント引数</param>
        private void save_dialog_event(object sender, EventArgs e)
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

        /// <summary>
        /// 検索フォームを表示するボタンのイベント処理
        /// </summary>
        /// <param name="sender">イベント発生源</param>
        /// <param name="e">イベント引数</param>
        private void find_form_event(object sender, EventArgs e)
        {
            findForm = new FindForm(textbox);
            findForm.Show();
        }

        /// <summary>
        /// 置換フォームを表示するボタンのイベント処理
        /// </summary>
        /// <param name="sender">イベントの発生源</param>
        /// <param name="e">イベント引数</param>
        private void replace_form_event(object sender, EventArgs e)
        {
            replaceForm = new ReplaceForm(textbox);
            replaceForm.Show();
        }

        /// <summary>
        /// 特定のキー押下時のイベント
        /// </summary>
        /// <param name="sender">イベントの発生源</param>
        /// <param name="e">キーイベント引数</param>
        private void keydown_event(object sender, KeyEventArgs e)
        {
            // Escキー押下時、エディタの背景色を白に戻す（検索時の背景色解除）
            if (e.KeyCode == Keys.Escape)
            {
                textbox.SelectAll();  //全選択
                textbox.SelectionBackColor = Color.White;  // 背景を白に変更
                textbox.Select(textbox.TextLength, 0);  // キャレット位置を最後尾に移動し全選択を解除
            }
        }
    }
}
