using System;
using System.Windows.Controls;

namespace ArmManager_WPF.src.CustomConsole
{
    class ConsoleHandler
    {
        private MainWindow window;
        private TextBlock console;
        private TextBlock leapConsole;

        public ConsoleHandler(MainWindow win)
        {
            this.window = win;
            this.console = win.console_text;
            this.leapConsole = win.console_leap;

            this.initConsole();
        }

        public void initConsole()
        {
            this.writeConsole("Welcome to Arm Manager V1.0 by SimpleDuino");
            this.writeConsole("Visit http://simple-duino.com for more infos");
        }

        public void writeConsole(String msg)
        {
            if (this.console.Text != "")
                this.console.Text = this.console.Text + "\n";
            this.console.Text = this.console.Text + this.getTimeStamp() + " " + msg;
        }

        public void writeLeapConsole(String msg)
        {
            if (this.leapConsole.Text != "")
                this.leapConsole.Text = this.leapConsole.Text + "\n";
            this.leapConsole.Text = this.leapConsole.Text + this.getTimeStamp() + " " + msg;
        }

        private String getTimeStamp()
        {
            String timestamp = "";
            DateTime nowDate = DateTime.Now;
            timestamp += "[" + nowDate.Hour + ":" + nowDate.Minute + ":" + nowDate.Second + "]";
            return timestamp;
        }
    }
}
