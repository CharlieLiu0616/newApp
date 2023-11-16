// See https://aka.ms/new-console-template for more information
using newApp;
using Tobii.Research;

IEyeTracker eyeTracker = GetEyeTracker.Get();
if (eyeTracker == null)
{
    Console.WriteLine("No eyetracker found!");
    return;
}
Console.WriteLine("The following eyetracker is chosen: ");
Console.WriteLine("{0}, {1}, {2}, {3}, {4}, {5}", eyeTracker.Address, eyeTracker.DeviceName, eyeTracker.Model, eyeTracker.SerialNumber, eyeTracker.FirmwareVersion, eyeTracker.RuntimeVersion);
//EyeTrackerCalibration.Calibrate(eyeTracker);
//new CalibrationDataToFile(eyeTracker, "CalibrationData.xml").Write();
//byte[] calibrationData = CalibrationDataToFile.Read(@"C:\Users\jl6\Desktop\newApp\calibration.setpm");
//CalibrationData data = new CalibrationData(calibrationData);
//eyeTracker.ApplyCalibrationData(data);
GazeDataReceived.GazeData(eyeTracker);