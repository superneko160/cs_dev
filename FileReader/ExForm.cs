namespace FileReader
{
    class ExForm : Form
    {
        private Button button;
        private Label[] labels = new Label[3];

        public ExForm()
        {
            this.Text = "SAMPLE";
            this.Width = 700;  // 幅が狭いとフルパス表示できない
            this.Height = 240;

            for (int i = 0; i < labels.Length; i++)
            {
                labels[i] = new Label();
                labels[i].Top = i * labels[0].Height;
                labels[i].Width = this.Width;
            }
            button = new Button();
            button.Height = 35;
            button.Text = "表示";
            button.Dock = DockStyle.Bottom;
            button.Parent = this;

            for (int i = 0; i < labels.Length; i++)
            {
                labels[i].Parent = this;
            }

            button.Click += new EventHandler(bt_Click!);
        }

        public void bt_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FileInfo fileinfo = new FileInfo(ofd.FileName);
                labels[0].Text = "ファイル名：" + fileinfo.Name;
                labels[1].Text = "絶対パス：" + Path.GetFullPath(ofd.FileName);
                labels[2].Text = "サイズ：" + Convert.ToString(fileinfo.Length);
            }
        }
    }
}
