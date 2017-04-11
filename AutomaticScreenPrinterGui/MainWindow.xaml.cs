using System;
using System.Windows;
using System.Windows.Forms;
using AutomaticScreenPrinterGui.Const;
using static System.Windows.Forms.DialogResult;
using Brushes = System.Windows.Media.Brushes;


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
            if (this.appInstance.FilePath == null)
            {
                this.LocationLbl.Foreground = Brushes.Red;
                return;
            }
            else
            {
                this.LocationLbl.Foreground = Brushes.Black;
            }
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
                this.IntervalLbl.Foreground = Brushes.Red;
                return;
            }
            this.IntervalLbl.Foreground = Brushes.Black;
            this.appInstance.Execute();
            this.StatusValueLbl.Content = eStatus.Capturing.ToString();
            this.StartBtn.Content = eButtonValues.Stop.ToString();

        }
    }
}
