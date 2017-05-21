using Leap;
using System;
using System.Windows.Media;

namespace ArmManager_WPF.src.LeapListeners
{
    class MainLeapListener
    {
        private MainWindow window;
        private BrushConverter bc = new BrushConverter();

        public MainLeapListener(MainWindow window)
        {
            this.window = window;
        }

        public void OnServiceConnect(object sender, ConnectionEventArgs args)
        {
            Console.WriteLine("Service connected");
        }

        public void OnConnect(object sender, DeviceEventArgs args)
        {
            Console.WriteLine("Connected");
        }

        public void OnFrame(object sender, FrameEventArgs args)
        {
            Leap.Frame frame = args.frame;
            Console.WriteLine(
                "Frame id: {0}, timestamp: {1}, hands: {2}",
                frame.Id, frame.Timestamp, frame.Hands.Count
                );

            this.window.detected_hands.Content = Convert.ToString(frame.Hands.Count);
            if (frame.Hands.Count == 0)
                this.window.hand_state.Background = (Brush)bc.ConvertFrom("#c0392b");
            else if(frame.Hands.Count == 1)
                this.window.hand_state.Background = (Brush)bc.ConvertFrom("#f39c12");
            else
                this.window.hand_state.Background = (Brush)bc.ConvertFrom("#2ecc71");


            foreach (Hand hand in frame.Hands)
            {
                Console.WriteLine("Hand id: {0}, palm position: {1}, fingers: {2}",
                    hand.Id, hand.PalmPosition, hand.Fingers.Count);
                
                Leap.Vector normalHandVector = hand.PalmNormal;
                Leap.Vector direction = hand.Direction;

                Console.WriteLine(
                    "Hand pitch:: {0} degrees, roll: {1} degrees, yaw: {2} degrees",
                    direction.Pitch * 180.0f / (float)Math.PI, normalHandVector.Roll * 180.0f / (float)Math.PI, direction.Yaw * 180.0f / (float)Math.PI);

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
