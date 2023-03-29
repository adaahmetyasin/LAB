public class SozelStratejisi : SınavStratejisi
{
    public EnumDers getBirinciDers()
    {
        return EnumDers.TURKCE;
    }

    public EnumDers getIkinciDers()
    {
        return EnumDers.INGILIZCE;
    }

    public EnumDers getUcuncuDers()
    {
        return EnumDers.SOSYAL;
    }

    public EnumDers getDorduncuDers()
    {
        return EnumDers.MATEMATIK;
    }

    public EnumDers getBesinciDers()
    {
        return EnumDers.FEN;
    }
}