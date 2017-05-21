using System;
using System.Windows.Controls;

namespace ArmManager_WPF.src.ConsoleHandler
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

            this.initConsole();
        }

        public void initConsole()
        {
            this.writeConsole(this.getTimeStamp() + " Welcome to Arm Manager V1.0 by SimpleDuino");
            this.writeConsole(this.getTimeStamp() + " Visit http://simple-duino.com for more infos");
        }

        public void writeConsole(String msg)
        {
            if (this.console.Text != "")
                this.console.Text = this.console.Text + "\n";
            this.console.Text = this.console.Text + msg;
        }

        public void writeLeapConsole(String msg)
        {
            if (this.leapConsole.Text != "")
                this.leapConsole.Text = this.leapConsole.Text + "\n";
            this.leapConsole.Text = this.leapConsole.Text + msg;
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
