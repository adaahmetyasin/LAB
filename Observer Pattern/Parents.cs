public class Parents :Observer
{
    private string name;

    public Parents(string name)
    {
        this.name = name;
    }

    public void Update(Observable observable)
    {
        Thermometer thermometer = (Thermometer)observable;

        Console.WriteLine("Parents " + name + " are notified that the temperature is " + thermometer.GetTemperature());

    }
}