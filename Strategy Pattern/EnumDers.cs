public class EnumDers
{
public string DersAdi {get; set;}


private EnumDers(string dersAdi)
{
    DersAdi = dersAdi;
}

public static EnumDers TURKCE = new EnumDers("Türkçe");
public static EnumDers MATEMATIK = new EnumDers("Matematik");
public static EnumDers FEN = new EnumDers("Fen");
public static EnumDers SOSYAL = new EnumDers("Sosyal");
public static EnumDers INGILIZCE = new EnumDers("İngilizce");

public override string ToString()
{
    return DersAdi;
}

}