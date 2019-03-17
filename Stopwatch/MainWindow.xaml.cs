using System;
using System.Windows;

using System.Timers;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DateTime date;
        Timer timer = new Timer(0.001);
        public MainWindow()
        {
            InitializeComponent();
            Reset1.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {   
            if(Timer1.Content.ToString() == "Start")
            {
                    Timer1.Content = "Stop";
                    Reset1.IsEnabled = false;
                    date = DateTime.Now;
                    timer.Elapsed += tickTimer;            
                    timer.Enabled = true;                
            }
            else if(Timer1.Content.ToString() == "Continue")
            {
                Timer1.Content = "Stop";
                timer.Enabled = true;
                Reset1.IsEnabled = false;
            }
            else
            {
                Timer1.Content = "Continue";
                Reset1.IsEnabled = true;
                timer.Enabled = false; 
            }
        }

        private void tickTimer(object sender, EventArgs e)
        {
            Dispatcher.InvokeAsync(() => {
                TimeSpan span = new TimeSpan(DateTime.Now.Ticks - date.Ticks);
                Label1.Content = span.ToString(@"hh\:mm\:ss\.fff");
            });
        }

        private void ButtonReset_Click(object sender, RoutedEventArgs e)
        {
            Label1.Content = String.Format("{0:HH:mm:ss.fff}", DateTime.MinValue);
            timer.Enabled = false;
            Timer1.Content = "Start";
            Reset1.IsEnabled = false;
        }
    }
}
