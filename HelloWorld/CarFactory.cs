using System;

namespace HelloWorld
{
    public interface Car{
        string getBrand();
        int getYear();
        int getPrice(); 
    }

    public class Audi : Car{
        public string getBrand(){
            return "Audi";
        }
        public int getYear(){
            return 2019;
        }
        public int getPrice(){
            return 100000;
        }
    } 

    public class BMW : Car{
        public string getBrand(){
            return "BMW";
        }
        public int getYear(){
            return 2019;
        }
        public int getPrice(){
            return 120000;
        }
    }

    public class Mercedes : Car{
        public string getBrand(){
            return "Mercedes";
        }
        public int getYear(){
            return 2019;
        }
        public int getPrice(){
            return 150000;
        }
    }

    public class Porsche : Car{
        public string getBrand(){
            return "Porsche";
        }
        public int getYear(){
            return 2019;
        }
        public int getPrice(){
            return 200000;
        }
    }

    // public class CarFactory{
    //     public static Car getCar(string brandName){
    //         Car car = null;

    //         if(brandName == "Audi"){
    //             car = new Audi();
    //         }
    //         else if(brandName == "BMW"){
    //             car = new BMW();
    //         }
    //         return car;
    //     }
    // }

    public abstract class CarFactory{

        protected abstract Car ProduceCar();
        public Car CreateCar(){
            return this.ProduceCar();
        }
    }

    public class AudiFactory : CarFactory{
        protected override Car ProduceCar(){
            Audi car = new Audi();
            return car;
        }
    }
    public class BMWFactory : CarFactory{
        protected override Car ProduceCar(){
            BMW car = new BMW();
            return car;
        }
    }
    public class MercedesFactory : CarFactory{
        protected override Car ProduceCar(){
            Mercedes car = new Mercedes();
            return car;
        }
    }

    public class PorscheFactory : CarFactory{
        protected override Car ProduceCar(){
            Porsche car = new Porsche();
            return car;
        }
    }
}