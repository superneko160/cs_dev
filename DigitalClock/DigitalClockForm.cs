namespace DigitalClock
{
    using System.Windows.Forms;

    partial class DigitalClockForm : Form
    {
        private Timer timer;
        private Label label;

        public DigitalClockForm()
        {
            timer = new Timer();
            timer.Interval = 1000;
            timer.Start();

            label = new Label();
            label.Font = new Font("Courier", 15, FontStyle.Regular);
            label.Dock = DockStyle.Fill;
            label.Parent = this;

            timer.Tick += new EventHandler(timer_Tick!);
        }

        private void timer_Tick(Object sender, EventArgs e)
        {
            DateTime datetime = DateTime.Now;
            label.Text = datetime.ToString();
        }
    }
}
