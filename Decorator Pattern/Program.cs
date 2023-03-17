using System;
namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IPizza pizza = new Pizza();
            Console.WriteLine(pizza.GetPizzaType());

            pizza = new PizzaWithCheese(pizza);
            Console.WriteLine(pizza.GetPizzaType());

            pizza = new PizzaWithCheese(pizza);
            Console.WriteLine(pizza.GetPizzaType());

            pizza = new PizzaWithTomatoSauce(pizza);
            Console.WriteLine(pizza.GetPizzaType());

            Console.ReadKey();
        }
    }
    // base interface
    interface IPizza{
        string GetPizzaType();
    }

    // concrete implementation
    class Pizza : IPizza{
        public string GetPizzaType(){
            return "This is a normal pizza";
        }
    }

    // base decorator
    class PizzaDecorator : IPizza{
        protected IPizza _pizza;
        public PizzaDecorator(IPizza pizza){
            _pizza = pizza;
        }

        public virtual string GetPizzaType(){
            return _pizza.GetPizzaType();
        }
    }

    // concrete decorator
    class PizzaWithCheese : PizzaDecorator{
        public PizzaWithCheese(IPizza pizza) : base(pizza){
        }

        public override string GetPizzaType(){
            return base.GetPizzaType() + " with cheese";
        }
    }
    class PizzaWithTomatoSauce : PizzaDecorator{
        public PizzaWithTomatoSauce(IPizza pizza) : base(pizza){
        }

        public override string GetPizzaType(){
            return base.GetPizzaType() + " with tomato sauce";
        }
    }
}