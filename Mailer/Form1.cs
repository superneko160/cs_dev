using System.Net.Mail;

namespace Mailer
{
    public partial class Form1 : Form
    {
        private TextBox[] textBoxes = new TextBox[4];
        private Label[] labels = new Label[3];
        private Button button;
        private TableLayoutPanel tableLayoutPanel;

        public Form1()
        {
            InitializeComponent();

            tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.RowCount = 5;
            tableLayoutPanel.Dock = DockStyle.Fill;

            for (int i = 0; i < textBoxes.Length; i++)
            {
                textBoxes[i] = new TextBox();
                textBoxes[i].Dock = DockStyle.Fill;
            }
            textBoxes[3].Multiline = true;
            textBoxes[3].ScrollBars = ScrollBars.Vertical;
            textBoxes[3].Height = 200;
            tableLayoutPanel.SetColumnSpan(textBoxes[3], 2);

            for (int i = 0; i < labels.Length; i++)
            {
                labels[i] = new Label();
                labels[i].Dock = DockStyle.Fill;
            }
            labels[0].Text = "タイトル";
            labels[1].Text = "宛先";
            labels[2].Text = "送信元";

            button = new Button();
            button.Text = "送信";
            button.Height = 45;
            tableLayoutPanel.SetColumnSpan(button, 2);

            // タイトル
            labels[0].Parent = tableLayoutPanel;
            textBoxes[1].Parent = tableLayoutPanel;
            // 宛先
            labels[1].Parent = tableLayoutPanel;
            textBoxes[0].Parent = tableLayoutPanel;
            // 送信元
            labels[2].Parent = tableLayoutPanel;
            textBoxes[2].Parent = tableLayoutPanel;
            // 本文入力エリア
            textBoxes[3].Parent = tableLayoutPanel;
            // 送信ボタン
            button.Parent = tableLayoutPanel;
            // フォームにテーブルレイアウトパネルを紐づけ
            tableLayoutPanel.Parent = this;

            // 送信ボタン押下時のイベント追加
            button.Click += new EventHandler(bt_Click!);
        }

        /**
         * 送信ボタン押下時
         */
        private void bt_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage message = new MailMessage(
                    textBoxes[2].Text,  // 送信元
                    textBoxes[1].Text  // 宛先
                );
                message.Subject = textBoxes[0].Text;  // タイトル
                message.Body = textBoxes[3].Text;  // 本文
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "";  // SMTPサーバ
                smtp.Send(message);  // 送信
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
