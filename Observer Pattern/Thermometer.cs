public class Thermometer : Observable
{
    private int temperature;
    private int minTemperature;
    private int maxTemperature;

    public Thermometer(int minTemperature, int maxTemperature)
    {
        this.minTemperature = minTemperature;
        this.maxTemperature = maxTemperature;
        this.temperature = 24;
    }

    public int GetTemperature()
    {
        return temperature;
    }

    public void SetTemperature(int temperature)
    {
        this.temperature = temperature;

        Console.WriteLine("Temperature is now " + temperature);

        checkTemperature();
    }

    private void checkTemperature()
    {
        if (temperature < minTemperature)
        {
            NotifyObservers();
        }
        else if (temperature > maxTemperature)
        {
            NotifyObservers();
        }
    }


}