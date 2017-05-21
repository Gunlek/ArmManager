using ArmManager_WPF.src;
using ArmManager_WPF.src.ConsoleHandler;
using System.Windows;

namespace ArmManager_WPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ConsoleHandler console;
        private LeapHandler leap;

        public MainWindow()
        {
            InitializeComponent();

            console = new ConsoleHandler(this);
            leap = new LeapHandler(this, console);
        }
    }
}
