using System.Net.Mail;

namespace Mailer
{
    public partial class Form1 : Form
    {
        // ���M�����[���A�h���X
        public const string SENDMAIL_ADDRESS = "";
        // ���M�����[���̃A�v���p�X���[�h
        public const string GMAIL_APP_PASSWORD = "";
        // SMTP�T�[�o
        public const string SMTP_SERVER = "smtp.gmail.com";
        // SMTP�T�[�o�̃|�[�g�ԍ�
        public const int SMTP_PORT = 587;

        private TextBox[] textBoxes = new TextBox[3];
        private Label[] labels = new Label[2];
        private Button button;
        private TableLayoutPanel tableLayoutPanel;

        public Form1()
        {
            InitializeComponent();

            tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.ColumnCount = 2;
            tableLayoutPanel.RowCount = 4;
            tableLayoutPanel.Dock = DockStyle.Fill;

            for (int i = 0; i < textBoxes.Length; i++)
            {
                textBoxes[i] = new TextBox();
                textBoxes[i].Dock = DockStyle.Fill;
            }
            textBoxes[2].Multiline = true;
            textBoxes[2].ScrollBars = ScrollBars.Vertical;
            textBoxes[2].Height = 200;
            tableLayoutPanel.SetColumnSpan(textBoxes[2], 2);

            for (int i = 0; i < labels.Length; i++)
            {
                labels[i] = new Label();
                labels[i].Dock = DockStyle.Fill;
            }
            labels[0].Text = "�^�C�g��";
            labels[1].Text = "����";

            button = new Button();
            button.Text = "���M";
            button.Height = 45;
            tableLayoutPanel.SetColumnSpan(button, 2);

            // �^�C�g��
            labels[0].Parent = tableLayoutPanel;
            textBoxes[0].Parent = tableLayoutPanel;
            // ����
            labels[1].Parent = tableLayoutPanel;
            textBoxes[1].Parent = tableLayoutPanel;
            // �{�����̓G���A
            textBoxes[2].Parent = tableLayoutPanel;
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
                    SENDMAIL_ADDRESS,  // ���M��
                    textBoxes[1].Text  // ����
                );
                message.Subject = textBoxes[0].Text;  // �^�C�g��
                message.Body = textBoxes[2].Text;     // �{��

                SmtpClient smtp = new SmtpClient(SMTP_SERVER, SMTP_PORT);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new System.Net.NetworkCredential(SENDMAIL_ADDRESS, GMAIL_APP_PASSWORD);
                smtp.EnableSsl = true;
                smtp.Send(message);  // ���M

                MessageBox.Show("���M����");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
