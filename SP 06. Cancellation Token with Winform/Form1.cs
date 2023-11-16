using System.Timers;

namespace SP_06._Cancellation_Token_with_Winform
{
    public partial class Form1 : Form
    {
        static CancellationTokenSource cts = new CancellationTokenSource();
        CancellationToken token = cts.Token;
        int count = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void Counter(CancellationToken token)
        {
            while (true)
            {
                if (token.IsCancellationRequested)
                {
                    ReverseCounter();
                    return;
                }
                count++;
                Thread.Sleep(100);
                
                timerLabel.Text = count.ToString();
            }

        }

        private void ReverseCounter()
        {
            ThreadPool.QueueUserWorkItem(o =>
            {
                while (count != 0)
                {
                    count--;
                    Thread.Sleep(100);
                    timerLabel.Text = count.ToString();
                }
            });


        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            cts.Cancel();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(o =>
            {
                Counter(cts.Token);
            });
        }
    }
}