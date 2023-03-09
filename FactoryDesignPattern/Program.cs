using System;
namespace FactoryDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            CreditCard cardDetails = CreditCardFactory.GetCreditCard("Platinum");
            
            if (cardDetails != null)
            {
                Console.WriteLine("CardType : " + cardDetails.GetCardType());
                Console.WriteLine("CreditLimit : " + cardDetails.GetCreditLimit());
                Console.WriteLine("AnnualCharge :" + cardDetails.GetAnnualCharge());
            }
            else
            {
                Console.Write("Invalid Card Type");
            }
            Console.ReadLine();
        }
    }
}