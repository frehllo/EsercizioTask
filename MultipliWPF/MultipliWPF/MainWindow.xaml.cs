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
                    multipli++;
                    txt_nM.Text = $"{multipli}";
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string divisore = txt_nA.Text;
            int d = Int32.Parse(divisore);
            Task<int> t1 = (Task<int>)Task.Factory.StartNew(() => CalcolaMultipli(d),
                CancellationToken.None, //Se posso interrompere il Task
                TaskCreationOptions.LongRunning, //Non permermette di avviare Task figli
                TaskScheduler.Default // Scelgo come devono essere gestiti i Task
                );
        }
    }
}
