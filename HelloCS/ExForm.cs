namespace HelloCS
{
    /**
     * 拡張フォームクラス
     */
    class ExForm : Form
    {
        Label label = new Label();
        TextBox text_box = new TextBox();
        Button button = new Button();

        /**
         * コンストラクタ
         * @string form_title フォームのタイトル
         * @int width フォームの横幅
         * @int height フォームの高さ
         */
        public ExForm(string form_title, int width, int height)
        {
            // フォーム自体
            this.Text = form_title;
            this.Width = width;
            this.Height = height;
            // ラベル
            this.label.Width = 50;
            this.label.Text = "数字：";
            // ボタン
            this.button.Text = "判定";
            // 入力欄の制限設定
            this.text_box.MaxLength = 8;
            this.text_box.ImeMode = ImeMode.Disable;
            // 設置場所
            this.label.Location = new Point(0, 0);  // Point(left top)
            this.text_box.Location = new Point(this.label.Width, 0);  // Point(left, top)
            this.button.Location = new Point((this.label.Width + this.text_box.Width), 0);  // Point(left top)
            // イベント追加
            this.button.Click += new EventHandler(bt_click!);
            // フォームに紐づけ
            this.Controls.Add(this.label);
            this.Controls.Add(this.text_box);
            this.Controls.Add(this.button);
        }

        /**
         * ボタンクリック時の処理
         */
        public void bt_click(object sender, EventArgs e)
        {
            if (int.TryParse(this.text_box.Text, out int number))
            {
                MessageBox.Show(fizzbuzz(number), "判定結果");
            }
            else
            {
                MessageBox.Show("数値が入力されていません", "判定結果");
            }
        }

        /*
         * FizzBuzz判定
         * @int number 整数
         */
        private string fizzbuzz(int number)
        {
            string result = number switch
            {
                int n when n == 0 => "Zero",
                int n when n % 3 == 0 && n % 5 == 0 => "FizzBuzz",
                int n when n % 3 == 0 => "Fizz",
                int n when n % 5 == 0 => "Buzz",
                _ => number.ToString(),
            };
            return result;
        }
    }
}
