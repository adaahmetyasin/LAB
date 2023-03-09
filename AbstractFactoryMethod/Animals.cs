namespace AbstractFactoryDesignPattern
{
    public class Cat : Animal
    {
        public string speak()
        {
            return "Meow Meow Meow";
        }
    }
    public class Lion : Animal
    {
        public string speak()
        {
            return "Roar";
        }
    }

    public class Dog : Animal
    {
        public string speak()
        {
            return "Bark Bark Bark";
        }
    }
    public class Octopus : Animal
    {
        public string speak()
        {
            return "Squish Squish Squish";
        }
    }
    public class Shark : Animal
    {
        public string speak()
        {
            return "Sharky Sharky";
        }
    }
}