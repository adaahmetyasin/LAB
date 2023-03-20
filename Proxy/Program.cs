using System;

namespace ProxyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            IService service = new ConcreteService();
            Proxy proxy = new Proxy(service);
            
            service.Login(15);
            proxy.Login(15);
            
            service.Login(18);
            proxy.Login(18);

        }

        public interface IService
        {
            void Login(int age);
        }
        class ConcreteService : IService
        {
            public void Login(int age)
            {
                Console.WriteLine($"You are logged. Age: {age}");
            }
        }

        class Proxy : IService
        {
            private IService _service;
            public Proxy(IService service)
            {
                _service = service;
            }
            public void Login(int age)
            {
                if (age < 18)
                {
                    Console.WriteLine("You are not allowed to login.");
                }
                else
                {
                    _service.Login(age);
                }
            }
        }
    }
}