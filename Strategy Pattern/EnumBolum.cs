public class EnumBolum
{
public string BolumAdi {get; set;}


private EnumBolum(string bolumAdi)
{
    BolumAdi = bolumAdi;
}

public static EnumBolum SAYISAL = new EnumBolum("Sayısal");
public static EnumBolum SOZEL = new EnumBolum("Sözel");

public override string ToString()
{
    return BolumAdi;

}
    
}