using System;
namespace FacadePAttern
{
    class Program
    {
        static void Main(string[] args)
        {
            RestaurantFacade restaurant = new RestaurantFacade();
            restaurant.GetVegPizza();
            dashLine();
            restaurant.GetNonVegPizza();
            dashLine();
            restaurant.GetGarlicBread();
            dashLine();
            restaurant.GetCheesyGarlicBread();

        }
        static void dashLine()
        {
            Console.WriteLine("-------------------------------------------------");
        }
    }
    public interface IPizza{
        void getVegPizza();
        void getNonVegPizza();
    }

    public class PizzaProvider : IPizza{
        public void getVegPizza(){
            Console.WriteLine("Veg Pizza");
        }
        public void getNonVegPizza(){
            getNonVegToppings();
            Console.WriteLine("Non Veg Pizza");
        }
        private void getNonVegToppings(){
            Console.WriteLine("Getting Non Veg Pizza");
        }
    }

    public interface IBread{
        void GetGarlicBread();
        void GetCheesyGarlicBread();
    }

    public class BreadProvider : IBread{
        public void GetGarlicBread(){
            Console.WriteLine("Garlic Bread");
        }
        public void GetCheesyGarlicBread(){
            getCheese();
            Console.WriteLine("Cheesy Garlic Bread");
        }
        private void getCheese(){
            Console.WriteLine("Getting Cheese");
        }
    }

    public class RestaurantFacade{
        private IPizza _PizzaProvider;
        private IBread _BreadProvider;
        public RestaurantFacade(){
            _PizzaProvider = new PizzaProvider();
            _BreadProvider = new BreadProvider();
        }
        public void GetVegPizza(){
            _PizzaProvider.getVegPizza();
        }
        public void GetNonVegPizza(){
            _PizzaProvider.getNonVegPizza();
        }
        public void GetGarlicBread(){
            _BreadProvider.GetGarlicBread();
        }
        public void GetCheesyGarlicBread(){
            _BreadProvider.GetCheesyGarlicBread();
        }
    }
}