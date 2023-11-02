using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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

namespace SP01_Processes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Process.Start("calc");
            //Process.Start("cmd");
            //Process.Start("mspaint");
            //Process.Start(@"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe");

            //txtBox.Text = Process.GetCurrentProcess().ProcessName;
            //txtBox.Text = Process.GetCurrentProcess().Id.ToString();

            //var proc = Process.GetProcessesByName("CalculatorApp");
            //proc[0].Kill();

            var processes = Process.GetProcesses().ToList();
            foreach (var process in processes)
            {
                procLstBox.Items.Add($"{process.Id}. {process.ProcessName}");

            }

        }
    }
}
