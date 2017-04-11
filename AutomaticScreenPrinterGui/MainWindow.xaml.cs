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
using AutomaticScreenPrinterGui.Const;
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
        readonly IApplicationInterface appInstance;
        public MainWindow(IApplicationInterface app)
        {
            this.appInstance = app;
            InitializeComponent();
            this.initValues();
        }

        private void initValues()
        {
            this.StatusValueLbl.Content = eStatus.Stopped.ToString();
            this.StartBtn.Content = eButtonValues.Start.ToString();
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
            if (this.appInstance.Status)
            {
                this.appInstance.Stop();
                this.initValues();
                return;
            }
            //if (this.appInstance.FilePath == null)
            //{
            //    this.LocationValueLbl.Foreground = 
            //}
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
                return;
            }

            this.appInstance.Execute();
            this.StatusValueLbl.Content = eStatus.Capturing.ToString();
            this.StartBtn.Content = eButtonValues.Stop.ToString();

        }
    }
}
