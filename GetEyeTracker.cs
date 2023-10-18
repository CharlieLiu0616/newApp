using System.Linq.Expressions;
using Tobii.Research;

namespace newApp
{
    public static class GetEyeTracker
    {

        public static IEyeTracker Get()
        {
            EyeTrackerCollection eyeTrackers = EyeTrackingOperations.FindAllEyeTrackers();
            foreach (IEyeTracker eyeTracker in eyeTrackers)
            {
                Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}", eyeTracker.Address, eyeTracker.DeviceName, eyeTracker.Model, eyeTracker.SerialNumber, eyeTracker.FirmwareVersion, eyeTracker.RuntimeVersion);
            }
            return eyeTrackers.FirstOrDefault();
        }

    }
}