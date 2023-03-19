using System;
using System.Collections.Generic;
using System.Threading;

namespace Flyweight{
    public enum EBulletSize
    {
        SMALL = 10, 
        MEDIUM = 30, 
        LARGE = 50
    }

    public abstract class Soldier
    
    {
        private EBulletSize _bulletSize;

        public Soldier(EBulletSize bulletSize){
            _bulletSize = bulletSize;
        }

        public void Fire(){
           // Bullet bullet = new Bullet(_bulletSize);
            Bullet bullet = BulletFactory.createBullet(_bulletSize);
            bullet.Shoot();
        }

        public void SerieFire()
        {
            for(int i = 0; i < 10; i++)
            {
                Fire();
            }
        }
    }

    public class Bullet
    {
        private EBulletSize _bulletSize;

        public Bullet(EBulletSize bulletSize)
        {
            _bulletSize = bulletSize;
            Console.WriteLine("Bullet with size: " + _bulletSize.ToString() + " is created");
            try
            {
                Thread.Sleep(1000);
            }catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void Shoot()
        {
            Console.WriteLine("Bullet with size: " + _bulletSize.ToString() + " is fired");
        }
    }

    public class Corporal : Soldier
    {
        public Corporal() : base(EBulletSize.SMALL) {}
    }

    public class Sergeant : Soldier
    {
        public Sergeant() : base(EBulletSize.MEDIUM) {}
    }

    public class Captain : Soldier
    {
        public Captain() : base(EBulletSize.LARGE) {}
    }

    public class BulletFactory
    {
        private static Dictionary<EBulletSize, Bullet> _bulletMap = new Dictionary<EBulletSize, Bullet>();

        public static Bullet createBullet(EBulletSize bulletSize)
        {
            Bullet bullet;
            if (!_bulletMap.TryGetValue(bulletSize, out bullet))
                {
                    bullet = new Bullet(bulletSize);
                    _bulletMap[bulletSize] = bullet;
                }
            return bullet;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Soldier> soldierList = new List<Soldier>();
            Captain captain = new Captain();
            soldierList.Add(captain);
            for(int i = 0; i < 50; i++)
            {
                Corporal corporal = new Corporal();
                soldierList.Add(corporal);
            }
            foreach(Soldier soldier in soldierList)
            {
                soldier.Fire();
            }
        }
    }
}