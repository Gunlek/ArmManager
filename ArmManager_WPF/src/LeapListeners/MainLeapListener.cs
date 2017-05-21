using ArmManager_WPF.src.CustomConsole;
using Leap;
using System;
using System.Windows.Media;

namespace ArmManager_WPF.src.LeapListeners
{
    class MainLeapListener
    {
        private MainWindow window;
        private BrushConverter bc = new BrushConverter();
        private ConsoleHandler console;

        public MainLeapListener(MainWindow window, ConsoleHandler con)
        {
            this.window = window;
            this.console = con;
        }

        public void OnServiceConnect(object sender, ConnectionEventArgs args)
        {
            this.console.writeLeapConsole("Service connected");
        }

        public void OnConnect(object sender, DeviceEventArgs args)
        {
            this.console.writeLeapConsole("Connected");
        }

        public void OnFrame(object sender, FrameEventArgs args)
        {
            Leap.Frame frame = args.frame;
            this.console.writeLeapConsole("Frame id: " + frame.Id + ", timestamp: " + frame.Timestamp + ", hands: " + frame.Hands.Count);

            this.window.detected_hands.Content = Convert.ToString(frame.Hands.Count);
            if (frame.Hands.Count == 0)
                this.window.hand_state.Background = (Brush)bc.ConvertFrom("#c0392b");
            else if(frame.Hands.Count == 1)
                this.window.hand_state.Background = (Brush)bc.ConvertFrom("#f39c12");
            else
                this.window.hand_state.Background = (Brush)bc.ConvertFrom("#2ecc71");


            foreach (Hand hand in frame.Hands)
            {
                this.console.writeLeapConsole("Hand id: "+ hand.Id + ", palm position: " + hand.PalmPosition + ", fingers: " + hand.Fingers.Count);

                Leap.Vector normalHandVector = hand.PalmNormal;
                Leap.Vector direction = hand.Direction;
                
                this.console.writeLeapConsole("Hand pitch:: " + direction.Pitch * 180.0f / (float)Math.PI + " degrees, roll: " + normalHandVector.Roll * 180.0f / (float)Math.PI + " degrees, yaw: "+ direction.Yaw * 180.0f / (float)Math.PI + " degrees");

                if (hand.IsRight)
                {
                    this.window.right_hand_pitch.Text = Convert.ToString(Math.Round(direction.Pitch * 180.0f / (float)Math.PI));
                    this.window.right_hand_roll.Text = Convert.ToString(Math.Round(normalHandVector.Roll * 180.0f / (float)Math.PI));
                    this.window.right_hand_yaw.Text = Convert.ToString(Math.Round(direction.Yaw * 180.0f / (float)Math.PI));
                }
                else
                {
                    this.window.left_hand_pitch.Text = Convert.ToString(Math.Round(direction.Pitch * 180.0f / (float)Math.PI));
                    this.window.left_hand_roll.Text = Convert.ToString(Math.Round(normalHandVector.Roll * 180.0f / (float)Math.PI));
                    this.window.left_hand_yaw.Text = Convert.ToString(Math.Round(direction.Yaw * 180.0f / (float)Math.PI));
                }
            }
        }
    }
}
