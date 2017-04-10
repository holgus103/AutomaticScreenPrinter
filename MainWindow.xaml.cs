using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using static System.Windows.Forms.DialogResult;
using Application = System.Windows.Application;

namespace AutomaticScreenPrinterGui
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        readonly App appInstance; 
        public MainWindow()
        {
            this.appInstance = (App) Application.Current;
            InitializeComponent();
        }

        private void BrowserBtn_Click(object sender, RoutedEventArgs e)
        {
            var dlg = new FolderBrowserDialog();
            if (OK == dlg.ShowDialog())
            {
                this.LocationValueLbl.Content =
                this.appInstance.FilePath = dlg.SelectedPath;
            }
        }

        private void StartBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var interval = Int32.Parse(this.IntervalTb.Text);
                if (interval > 0)
                {
                    this.appInstance.Interval = 1000 * interval;
                }

            }
            catch (Exception ex)
            {
                //this.IntervalTb.TextDecorations.
            }
            this.appInstance.Execute();
        }
    }
}
