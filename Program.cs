using System;


namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            // путешественник
            Traveler Traveler = new Traveler();

            // машина
            Car Car = new Car();
            // отправляемся в путешествие
            Traveler.Travel(Car);

            // встретились поля и леса, надо использовать лошадей
            Horse Horse = new Horse();
            // используем адаптер
            ITransport HorseTransport = new MountsToTransportAdapter(Horse);
            // продолжаем путь по полям и лесам
            Traveler.Travel(HorseTransport);

            //встретились снежные горы, нужно использовать собак
            SnowDog SnowDog = new SnowDog();
            // использование адаптера
            ITransport SnowDogTransport = new MountsToTransportAdapter(SnowDog);
            //Продолжить путь на собаках
            Traveler.Travel(SnowDogTransport);

            Console.Read();
        }
    }



    interface ITransport
    {
        void Moving();
    }

    // класс машины
    class Car : ITransport
    {
        public void Moving()
        {
            Console.WriteLine("Машина едет по дороге");
        }
    }



    // класс путешественник, который будет использовать транспорт
    class Traveler
    {
        public void Travel(ITransport transport)
        {
            transport.Moving();
        }
    }
    // интерфейс ездовые животные 
    interface IMounts 
    {
        void Move();
    }
    // класс лошадь
    class Horse : IMounts 
    {
        public void Move()
        {
            Console.WriteLine("Лошади идут по полям и лесам");
        }
    }
    // класс ездовых собак
    class SnowDog : IMounts
    {
        public void Move()
        {
            Console.WriteLine("Собачья упряжка бежит по заснеженным горам");
        
        }
    
    }


    // Адаптер от IMounts к ITransport
    class MountsToTransportAdapter : ITransport
    {
        IMounts mounts;
        public MountsToTransportAdapter(IMounts c)
        {
            mounts = c;
        }

        public void Moving()
        {
            mounts.Move();
        }
    }
}
