namespace HelloCS
{
    internal static class Program
    {
        static void Main()
        {
            Form form = new Form();
            Label label = new Label();

            form.Text = "CS-Window";
            label.Text = "Hello, C#!!!";
            label.Parent = form;

            Application.Run(form);
        }
    }
}