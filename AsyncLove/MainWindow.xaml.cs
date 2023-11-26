using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace AsyncLove
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string url = @"https://turbo.az/";
        WebClient webClient = new();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SimpleDownload(object sender, RoutedEventArgs e)
        {
            var txt = webClient.DownloadString(url);
            siteText.Text = txt;
        }

        private void DontClick(object sender, RoutedEventArgs e)
        {
            var tsk = webClient.DownloadStringTaskAsync(url);
            siteText.Text = tsk.Result;

        }

        private void TaskDownload(object sender, RoutedEventArgs e)
        {
            var tsk = webClient.DownloadStringTaskAsync(url)
                .ContinueWith(t =>
                {

                    siteText.Text += t.Result;
                }, TaskScheduler.FromCurrentSynchronizationContext());

        }

        private void TaskContextDownload(object sender, RoutedEventArgs e)
        {
            var context = SynchronizationContext.Current;
            var tsk = webClient.DownloadStringTaskAsync(url)
                .ContinueWith(t =>
                {
                    context.Send(_ =>
                    {
                        siteText.Text = t.Result;

                    }, null);
                });

        }

        private async void AsyncDownload(object sender, RoutedEventArgs e)
        {
            var txt = await webClient.DownloadStringTaskAsync(url);
            siteText.Text = txt;

        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            siteText.Clear();
        }
    }
}
