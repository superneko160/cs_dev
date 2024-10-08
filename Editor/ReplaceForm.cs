﻿using System.Text.RegularExpressions;

namespace Editor
{
    class ReplaceForm : Form
    {
        private Label[] labels;
        private TextBox[] textBoxes;
        private Button button;
        private RichTextBox editorTextBox;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ReplaceForm(RichTextBox editorTextBox)
        {
            // エディタのテキストボックス
            this.editorTextBox = editorTextBox;
            // フォーム
            this.Text = "置換";
            this.Width = 350;
            this.Height = 240;
            // ラベル
            labels = new Label[2];
            for (int i = 0; i < labels.Length; i++)
            {
                labels[i] = new Label();
                labels[i].Width = 100;
                labels[i].Height = 50;
                labels[i].Location = new Point(0, (i * labels[i].Height));
                labels[i].Parent = this;
            }
            labels[0].Text = "置換前：";
            labels[1].Text = "置換後：";
            // 入力ボックス
            textBoxes = new TextBox[2];
            for (int i = 0; i < textBoxes.Length; i++)
            {
                textBoxes[i] = new TextBox();
                textBoxes[i].Width = 150;
                textBoxes[i].Height = 50;
                textBoxes[i].Location = new Point(labels[i].Width, (i * labels[i].Height));
                textBoxes[i].Parent = this;
            }
            // ボタン
            button = new Button();
            button.Text = "Replace";
            button.Width = 100;
            button.Height = 50;
            button.Location = new Point(0, (labels[0].Height * 2));
            button.Parent = this;
            // イベント追加
            button.Click += new EventHandler(replace_event!);
        }

        /// <summary>
        /// 置換ボタンのイベント
        /// </summary>
        /// <param name="sender">イベント発生源</param>
        /// <param name="e">イベント引数</param>
        private void replace_event(object sender, EventArgs e)
        {
            Regex regex = new Regex(textBoxes[0].Text);
            editorTextBox.Text = regex.Replace(
                editorTextBox.Text,  // 置換先
                textBoxes[1].Text  // 置換後文字列
            );
        }
    }
}
