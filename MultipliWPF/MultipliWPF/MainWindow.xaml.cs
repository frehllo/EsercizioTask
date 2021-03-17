using System;
using System.Collections.Generic;
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
using System.Threading;

namespace MultipliWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public void CalcolaMultipli(int a)
        {
            int divisore = a;
            int multipli = 0;
            
            for(int i = 1; i < 200000000; i++)
            {
                if(i % divisore == 0)
                {
                    txt_nM.Text = $"{multipli++}";
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Task<int> t1 = (Task<int>)Task.Factory.StartNew(() => CalcolaMultipli(Int32.Parse(txt_nA.Text)),
                CancellationToken.None,
                TaskCreationOptions.LongRunning,
                TaskScheduler.Default
                );
        }
    }
}
