public class App
{
    public static void Main()
    {   
        Console.WriteLine("----------------------");
        siralamaYazdir(EnumBolum.SAYISAL);
        Console.WriteLine("----------------------");
        siralamaYazdir(EnumBolum.SOZEL);


    }
    private static void siralamaYazdir(EnumBolum bolum)
    {
        Student student = new Student(bolum);
        Console.WriteLine(student.getOncelikSirasi());
    }
}