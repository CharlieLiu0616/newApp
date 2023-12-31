using Tobii.Research;
public static class GazeDataReceived 
{
    public static void GazeData(IEyeTracker eyeTracker)
    {
        // Start listening to gaze data.
        eyeTracker.GazeDataReceived += EyeTracker_GazeDataReceived;
        // Wait for some data to be received.
        System.Threading.Thread.Sleep(10000000);
        // Stop listening to gaze data.
        eyeTracker.GazeDataReceived -= EyeTracker_GazeDataReceived;
    }

    private static void EyeTracker_GazeDataReceived(object sender, GazeDataEventArgs e)
    {
         if (e.LeftEye.GazePoint.Validity == Validity.Valid)
         {
            Console.Write("L:{0}, {1})",
            e.LeftEye.GazePoint.PositionOnDisplayArea.X,
            e.LeftEye.GazePoint.PositionOnDisplayArea.Y);
         }

        if (e.RightEye.GazePoint.Validity == Validity.Valid)
        {
            Console.WriteLine("R:{0}, {1})",
            e.RightEye.GazePoint.PositionOnDisplayArea.X,
            e.RightEye.GazePoint.PositionOnDisplayArea.Y);
        }
    }

}