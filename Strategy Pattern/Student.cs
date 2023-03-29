public class Student
{
    private EnumBolum Bolum;
    private SınavStratejisi SınavStratejisi;

    public Student(EnumBolum bolum)
    {
        Bolum = bolum;
        if (bolum == EnumBolum.SAYISAL)
        {
            SınavStratejisi = new SayısalStratejisi();
        }
        else if (bolum == EnumBolum.SOZEL)
        {
            SınavStratejisi = new SozelStratejisi();
        }
    }

    public String getOncelikSirasi()
    {
        Console.WriteLine(Bolum + " bölümü için sınav stratejisi: ");
        String siralama = "1. " + SınavStratejisi.getBirinciDers() + " çöz \n" +
                            "2. " + SınavStratejisi.getIkinciDers() + " çöz \n" +
                            "3. " + SınavStratejisi.getUcuncuDers() + " çöz \n" +
                            "4. " + SınavStratejisi.getDorduncuDers() + " çöz \n" +
                            "5. " + SınavStratejisi.getBesinciDers() + " çöz \n";
        return siralama;
    }
}