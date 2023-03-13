using System;

namespace AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Priz priz = new Priz();
            Utu utu = new Utu();
            Buzdolabı buzdolabı = new Buzdolabı();
            Iphone iphone = new Iphone();

            priz.elektrikVer(utu);
            priz.elektrikVer(buzdolabı);
            //priz.elektrikVer(iphone); // hata verir

            TelefonAdapter telefonAdapter = new TelefonAdapter(iphone);
            priz.elektrikVer(telefonAdapter);
        }

    }

    public interface ElektrikliEvAletleri
    {
        int prizeTakVeCalistir();
    }

    public class Priz
    {
        public void elektrikVer(ElektrikliEvAletleri elektrikliEvAleti)
        {
            int volt = elektrikliEvAleti.prizeTakVeCalistir();
            Console.WriteLine("Prizden" + volt + "volt alınıyor");
        }
    }

    public class Utu : ElektrikliEvAletleri
    {
        private int volt;

        public Utu()
        {
            this.volt = 220;
        }
        public int prizeTakVeCalistir()
        {
            Console.WriteLine("ütü calisdi");
            return volt;
        }
    }

    public class Buzdolabı : ElektrikliEvAletleri
    {
        private int volt;
        public Buzdolabı()
        {
            this.volt = 220;
        }
        public int prizeTakVeCalistir()
        {
            Console.WriteLine("buzdolabı calisdi");
            return volt;
        }
    }

    public interface Telefon
    {
        int şarjEt();
    }

    public class Iphone : Telefon
    {
        private int volt;
        public Iphone()
        {
            this.volt = 5;
        }
        public int şarjEt()
        {
            Console.WriteLine("Iphone şarj oldu");
            return volt;
        }
    }

    public class TelefonAdapter : ElektrikliEvAletleri
    {
        private Telefon telefon;

        public TelefonAdapter(Telefon telefon)
        {
            this.telefon = telefon;
        }

        public int prizeTakVeCalistir()
        {
            return telefon.şarjEt();
        }
    }
}
