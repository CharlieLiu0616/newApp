using Tobii.Research;

public class CalibrationDataToFile {
    private IEyeTracker eyeTracker;
    private String path;

    public CalibrationDataToFile(IEyeTracker eyeTracker, String path)
    {
        this.eyeTracker = eyeTracker;
        this.path = path;
    }
    public CalibrationDataToFile(IEyeTracker eyeTracker)
    {
        this.eyeTracker = eyeTracker;
        this.path = "calibrationData.xml";
    }

    public void Calibrate()
    {
        if (System.IO.File.Exists(path))
        {
            System.IO.File.Delete(path);
        }

        using (System.IO.FileStream fileStream = System.IO.File.Create(path))
        {
            var dataContractSerializer = new System.Runtime.Serialization.DataContractSerializer(typeof(CalibrationData));
            // Retrieve the calibration data from the eye tracker.
            CalibrationData calibrationData = eyeTracker.RetrieveCalibrationData();
            // Save the calibration data to the file;
            dataContractSerializer.WriteObject(fileStream, calibrationData);
        }
        // Reopen the file and read the calibration data back.
        using (System.IO.FileStream fileStream = System.IO.File.OpenRead(path))
        {
            var dataContractSerializer = new System.Runtime.Serialization.DataContractSerializer(typeof(CalibrationData));
            // Read the calibration data from file.
            CalibrationData calibrationData = dataContractSerializer.ReadObject(fileStream) as CalibrationData;
            // Don't apply empty calibration.
            if (calibrationData.Data.Length != 0)
            {
                // Apply the calibration data to the eye tracker.
                eyeTracker.ApplyCalibrationData(calibrationData);
            }
        }

    }
}
