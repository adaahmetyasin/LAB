public class App
{
    public static void Main()
    {
        int minTemperature = 23;
        int maxTemperature = 28;
        Thermometer thermometer = new Thermometer(minTemperature, maxTemperature);
        Parents mom = new Parents("John");
        Parents dad = new Parents("Mary");

        thermometer.AddObserver(mom);
        thermometer.AddObserver(dad);

        for(int i = thermometer.GetTemperature(); i <= 30; i++)
        {
            thermometer.SetTemperature(i);
        }
        for (int i = thermometer.GetTemperature(); i >= 22; i--)
        {
            thermometer.SetTemperature(i);
        }


    }
}