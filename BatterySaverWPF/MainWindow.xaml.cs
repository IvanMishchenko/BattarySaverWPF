using System;
using System.Reflection;
using System.Timers;
using System.Windows;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace BatterySaverWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Hide();
            var timer = new System.Windows.Threading.DispatcherTimer();
            timer.Tick += TimerTick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            CheckBattery();
        }


        private static object GetInfoBattery()
        {
            return PropertyInfoStatus[3].GetValue(SystemInformation.PowerStatus, null);
        }

        private static object GetInfoPower()
        {

            return PropertyInfoStatus[0].GetValue(SystemInformation.PowerStatus, null);
        }

        private static PropertyInfo[] PropertyInfoStatus
        {
            get
            {
                return typeof(PowerStatus).GetProperties();
            }
        }

        private void CheckBattery()
        {
            if (Convert.ToDouble(GetInfoBattery()) == 1 && Convert.ToInt32(GetInfoPower()) == 1)
            {
                Show();
            }
            else
            {
                Hide();
            }
        }
    }
}
