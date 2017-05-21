using ArmManager_WPF.src.LeapListeners;
using Leap;
using System;

namespace ArmManager_WPF.src
{
    class LeapHandler
    {

        private Controller controller;

        public LeapHandler(MainWindow window)
        {
            Console.WriteLine("Ready to listen to Leap Motion data...");
            Console.WriteLine();

            this.controller = new Controller();

            MainLeapListener mll = new MainLeapListener(window);
            controller.Connect += mll.OnServiceConnect;
            controller.Device += mll.OnConnect;
            controller.FrameReady += mll.OnFrame;
        }
    }
}
