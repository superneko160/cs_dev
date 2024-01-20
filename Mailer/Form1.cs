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
            labels[0].Text = "�^�C�g��";
            labels[1].Text = "����";
            labels[2].Text = "���M��";

            button = new Button();
            button.Text = "���M";
            button.Height = 45;
            tableLayoutPanel.SetColumnSpan(button, 2);

            // �^�C�g��
            labels[0].Parent = tableLayoutPanel;
            textBoxes[1].Parent = tableLayoutPanel;
            // ����
            labels[1].Parent = tableLayoutPanel;
            textBoxes[0].Parent = tableLayoutPanel;
            // ���M��
            labels[2].Parent = tableLayoutPanel;
            textBoxes[2].Parent = tableLayoutPanel;
            // �{�����̓G���A
            textBoxes[3].Parent = tableLayoutPanel;
            // ���M�{�^��
            button.Parent = tableLayoutPanel;
            // �t�H�[���Ƀe�[�u�����C�A�E�g�p�l����R�Â�
            tableLayoutPanel.Parent = this;

            // ���M�{�^���������̃C�x���g�ǉ�
            button.Click += new EventHandler(bt_Click!);
        }

        /**
         * ���M�{�^��������
         */
        private void bt_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage message = new MailMessage(
                    textBoxes[2].Text,  // ���M��
                    textBoxes[1].Text  // ����
                );
                message.Subject = textBoxes[0].Text;  // �^�C�g��
                message.Body = textBoxes[3].Text;  // �{��
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "";  // SMTP�T�[�o
                smtp.Send(message);  // ���M
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
