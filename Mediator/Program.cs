namespace MediatorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var callCenter = new CabCallCenter();

            var passenger1 = new Passenger("John", "123, Main Street", 8);
            var passenger2 = new Passenger("Mary", "456, Main Street", 28);

            var cab1 = new Cab("Cab1", 11, true);
            var cab2 = new Cab("Cab2", 22, true);

            callCenter.Register(cab1);
            callCenter.Register(cab2);

            callCenter.BookCab(passenger1);
            callCenter.BookCab(passenger2);

            Console.ReadKey();

        
        }

        internal interface ICab
{
    string Name { get; }
    int CurrentLocation { get; }
    bool IsFree { get; }

    void Assign(string name, string address);
}

internal class Cab : ICab
{
    private readonly string _name;
    private readonly int _location;
    private readonly bool _free;

    public Cab(string name, int location, bool free)
    {
        _name = name;
        _location = location;
        _free = free;
    }

    public string Name => _name;

    public int CurrentLocation => _location;

    public bool IsFree => _free;

    public void Assign(string name, string address) =>
        Console.WriteLine($"Cab {Name}, assigned to passenger: {name}, {address}");
}
    internal interface ICabCallCenter
{
    void Register(ICab cab);
    void BookCab(IPassenger passenger);
}

internal class CabCallCenter : ICabCallCenter
{
    private readonly Dictionary<string, ICab> cabs
        = new Dictionary<string, ICab>();
    public void BookCab(IPassenger passenger)
    {
        foreach (var cab in cabs.Values.Where(c => c.IsFree))
        {
            if(IsWithin5MileRadius(cab.CurrentLocation, passenger.Location))
            {
                cab.Assign(passenger.Name, passenger.Address);
                passenger.Acknowledge(cab.Name);
            }
        }
    }

    public void Register(ICab cab)
    {
        if (!cabs.ContainsValue(cab)) cabs.Add(cab.Name, cab);
    }

    private bool IsWithin5MileRadius(int cabLocation, int passengerLocation)
        => Math.Abs(cabLocation - passengerLocation) < 5;
}
internal interface IPassenger
{
    string Name { get; }
    string Address { get; }
    int Location { get; }

    void Acknowledge(string name);
}

internal class Passenger : IPassenger
{
    private string _name;
    private string _address;
    private int _location;

    public Passenger(string name, string address, int location)
    {
        _name = name;
        _address = address;
        _location = location;
    }
    public string Name => _name;

    public string Address => _address;

    public int Location => _location;

    public void Acknowledge(string name) =>
    Console.WriteLine($"Passenger {Name}, Cab: {name}");
}

    }
}