public class SayısalStratejisi : SınavStratejisi
{
    public EnumDers getBirinciDers()
    {
        return EnumDers.MATEMATIK;
    }

    public EnumDers getIkinciDers()
    {
        return EnumDers.FEN;
    }

    public EnumDers getUcuncuDers()
    {
        return EnumDers.TURKCE;
    }

    public EnumDers getDorduncuDers()
    {
        return EnumDers.SOSYAL;
    }

    public EnumDers getBesinciDers()
    {
        return EnumDers.INGILIZCE;
    }
}