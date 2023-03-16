// using System;

// namespace Compsite
// {

//     class Program
//     {

//         static void Main(string[] args)
//         {
//             Product tomato = new Product("Tomato", 1.5m);
//             Product potato = new Product("Potato", 2.5m);
//             Product carrot = new Product("Carrot", 3.5m);
//             Product onion = new Product("Onion", 4.5m);
//             Packet vegetablePacket = new Packet("Vegetable Packet");
//             vegetablePacket.AddProduct(tomato);
//             vegetablePacket.AddProduct(potato);
//             vegetablePacket.AddProduct(carrot);
//             vegetablePacket.AddProduct(onion);

//             Product phone = new Product("Phone", 1000m);
//             Product laptop = new Product("Laptop", 2000m);

//             Packet electronicPacket = new Packet("Electronic Packet");
//             electronicPacket.AddProduct(phone);
//             electronicPacket.AddProduct(laptop);

//             Product ball = new Product("Ball", 10m);
//             Product oil = new Product("Oil", 20m);

//             Stores store = new Stores("Aid Store");
//             store.AddPacket(vegetablePacket);
//             store.AddProduct(oil);

//             ShoppingCart shoppingCart = new ShoppingCart("My Shopping Cart");
//             shoppingCart.AddPriceable(vegetablePacket);
//             shoppingCart.AddPriceable(electronicPacket);
//             shoppingCart.AddPriceable(store);
//             shoppingCart.AddPriceable(ball);

//             decimal totalPrice = shoppingCart.GetTotalPrice();
//             Console.WriteLine("Total Price: " + totalPrice);


//         }
//     }
// }

// public interface Priceable{
//     decimal getPrice();
// }

// public class Product : Priceable{
//     private String name;
//     private decimal price;

//     public Product(String name, decimal price){
//         this.name = name;
//         this.price = price;
//     }
//     public decimal getPrice(){
//         return price;
//     }
//     public String getName(){
//         return name;
//     }
//     public void setPrice(decimal price){
//         this.price = price;
//     }
//     public void setName(String name){
//         this.name = name;
//     }
// }

// public class PriceCalculation{
//     public static decimal getTotalProductPrice(List<Product> productList){
//         decimal total = decimal.ZERO;
//         foreach(Product product in productList){
//             total = total.add(product.getPrice());
//         }
//         return total;
//     }

//     public static decimal getTotalPacketPrice(List<Packet> packetList){
//         decimal total = decimal.ZERO;
//         foreach(Packet packet in packetList){
//             total = total.add(getTotalProductPrice(packet.getProductList()));
//         }
//         return total;
//     }
// }

// public class Packet : Priceable{
//     private String name;
//     private List<Product> productList;

//     public Packet(String name){
//         this.name = name;
//         productList = new ArrayList<>();
//     }
//     public decimal getPrice(){
//         return PriceCalculation.getTotalProductPrice(productList);
//     }
//     public String getName(){
//         return name;
//     }
//     public void setName(String name){
//         this.name = name;
//     }
//     public List<Product> getProductList(){
//         return productList;
//     }
//     public void setProductList(List<Product> productList){
//         this.productList = productList;
//     }

// }

// public class Stores : Priceable{
//     private String name;
//     private List<Packet> packetList;
//     private List<Product> productList;

//     public Stores(String name){
//         this.name = name;
//         packetList = new ArrayList<>();
//         productList = new ArrayList<>();
//     }
//     public decimal getPrice(){
//         decimal total = PriceCalculation.getTotalPacketPrice(packetList);
//         total = total.add(PriceCalculation.getTotalProductPrice(productList));
//         return total;

//     }
//     public String getName(){
//         return name;
//     }
//     public void setName(String name){
//         this.name = name;
//     }
//     public List<Packet> getPacketList(){
//         return packetList;
//     }
//     public void setPacketList(List<Packet> packetList){
//         this.packetList = packetList;
//     }
//     public List<Product> getProductList(){
//         return productList;
//     }
//     public void setProductList(List<Product> productList){
//         this.productList = productList;
//     }

// }

// public class ShoppingCart{
//     private string name;
//     private List<Priceable> priceableList;

//     public ShoppingCart(String name){
//         this.name = name;
//         priceableList = new ArrayList<>();
//     }

//     public decimal getTotalPrice(){
//         decimal total = decimal.ZERO;
//         foreach(Priceable priceable in priceableList){
//             total = total.add(priceable.getPrice());
//         }
//         return total;
//     }

//     public String getName(){
//         return name;
//     }
//     public void setName(String name){
//         this.name = name;
//     }
//     public List<Priceable> getPriceableList(){
//         return priceableList;
//     }
//     public void setPriceableList(List<Priceable> priceableList){
//         this.priceableList = priceableList;
//     }
// }
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
