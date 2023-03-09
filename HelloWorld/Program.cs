namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Car audi = new AudiFactory().CreateCar();
            Car bmw = new BMWFactory().CreateCar();
            Car mercedes = new MercedesFactory().CreateCar();

            Console.WriteLine("Audi: " + audi.getBrand() + " " + audi.getYear() + " " + audi.getPrice());
            Console.WriteLine("BMW: " + bmw.getBrand() + " " + bmw.getYear() + " " + bmw.getPrice());
            Console.WriteLine("Mercedes: " + mercedes.getBrand() + " " + mercedes.getYear() + " " + mercedes.getPrice());

        }
    }
}