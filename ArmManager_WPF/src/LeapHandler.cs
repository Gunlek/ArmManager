using ArmManager_WPF.src.CustomConsole;
using ArmManager_WPF.src.LeapListeners;
using Leap;
using System;

namespace ArmManager_WPF.src
{
    class LeapHandler
    {

        private ConsoleHandler console;
        private Controller controller;

        public LeapHandler(MainWindow window, ConsoleHandler con)
        {
            this.console = con;
            this.console.writeLeapConsole("Ready to listen to Leap Motion data...");

            this.controller = new Controller();

            MainLeapListener mll = new MainLeapListener(window, this.console);
            controller.Connect += mll.OnServiceConnect;
            controller.Device += mll.OnConnect;
            controller.FrameReady += mll.OnFrame;
        }
    }
}
