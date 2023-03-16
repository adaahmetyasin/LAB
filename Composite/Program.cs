using System;
using System.Collections.Generic;

namespace Compsite
{
    interface IPriceable
    {
        decimal GetPrice();
    }

    class Product : IPriceable
    {
        private string name;
        private decimal price;

        public Product(string name, decimal price)
        {
            this.name = name;
            this.price = price;
        }

        public decimal GetPrice()
        {
            return price;
        }

        public string GetName()
        {
            return name;
        }

        public void SetPrice(decimal price)
        {
            this.price = price;
        }

        public void SetName(string name)
        {
            this.name = name;
        }
    }

    class PriceCalculation
    {
        public static decimal GetTotalProductPrice(List<Product> productList)
        {
            decimal total = 0m;
            foreach (Product product in productList)
            {
                total += product.GetPrice();
            }
            return total;
        }

        public static decimal GetTotalPacketPrice(List<Packet> packetList)
        {
            decimal total = 0m;
            foreach (Packet packet in packetList)
            {
                total += GetTotalProductPrice(packet.GetProductList());
            }
            return total;
        }
    }

    class Packet : IPriceable
    {
        private string name;
        private List<Product> productList;

        public Packet(string name)
        {
            this.name = name;
            productList = new List<Product>();
        }

        public decimal GetPrice()
        {
            return PriceCalculation.GetTotalProductPrice(productList);
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public List<Product> GetProductList()
        {
            return productList;
        }

        public void SetProductList(List<Product> productList)
        {
            this.productList = productList;
        }
    }

    class Stores : IPriceable
    {
        private string name;
        private List<Packet> packetList;
        private List<Product> productList;

        public Stores(string name)
        {
            this.name = name;
            packetList = new List<Packet>();
            productList = new List<Product>();
        }

        public decimal GetPrice()
        {
            decimal total = PriceCalculation.GetTotalPacketPrice(packetList);
            total += PriceCalculation.GetTotalProductPrice(productList);
            return total;
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public List<Packet> GetPacketList()
        {
            return packetList;
        }

        public void SetPacketList(List<Packet> packetList)
        {
            this.packetList = packetList;
        }

        public List<Product> GetProductList()
        {
            return productList;
        }

        public void SetProductList(List<Product> productList)
        {
            this.productList = productList;
        }
    }

    class ShoppingCart
    {
        private string name;
        private List<IPriceable> priceableList;

        public ShoppingCart(string name)
        {
            this.name = name;
            priceableList = new List<IPriceable>();
        }

        public decimal GetTotalPrice()
        {
            decimal total = 0m;
            foreach (IPriceable priceable in priceableList)
            {
                total += priceable.GetPrice();
            }
            return total;
        }
        public String GetName()
        {
            return name;
        }
        public void SetName(String name)
        {
            this.name = name;
        }
        public List<IPriceable> GetPriceableList()
        {
            return priceableList;
        }
        public void SetPriceableList(List<IPriceable> priceableList)
        {
            this.priceableList = priceableList;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ShoppingCart shoppingCart = new ShoppingCart("Shopping Cart");
            Stores stores = new Stores("Stores");
            Packet packet = new Packet("Packet");
            Product product = new Product("Product", 10m);
            Product tomato = new Product("Tomato", 5m);
            Product apple = new Product("Apple", 3m);
            Product orange = new Product("Orange", 2m);
            packet.GetProductList().Add(product);
            packet.GetProductList().Add(tomato);
            packet.GetProductList().Add(apple);
            packet.GetProductList().Add(orange);
            stores.GetPacketList().Add(packet);
            shoppingCart.GetPriceableList().Add(stores);
            Console.WriteLine(shoppingCart.GetTotalPrice());
        }
    }
}
