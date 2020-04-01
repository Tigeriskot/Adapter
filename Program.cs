using System;


namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            // путешественник
            Driver driver = new Driver();

            // машина
            Auto auto = new Auto();
            // отправляемся в путешествие
            driver.Travel(auto);

            // встретились пески, надо использовать верблюда
            Camel camel = new Camel();
            // используем адаптер
            ITransport camelTransport = new MountsToTransportAdapter(camel);
            // продолжаем путь по пескам пустыни
            driver.Travel(camelTransport);

            //встретились снежные горы, нужно использовать собак
            SnowDog snowDog = new SnowDog();
            // использование адаптера
            ITransport snowDogTransport = new MountsToTransportAdapter(snowDog);
            //Продолжить путь на собаках
            driver.Travel(snowDogTransport);

            Console.Read();
        }
    }
    interface ITransport
    {
        void Drive();
    }
    // класс машины
    class Auto : ITransport
    {
        public void Drive()
        {
            Console.WriteLine("Машина едет по дороге");
        }
    }
    // класс водитель, который будет использовать транспорт
    class Driver
    {
        public void Travel(ITransport transport)
        {
            transport.Drive();
        }
    }
    // интерфейс ездовые животные животного
    interface IMounts 
    {
        void Move();
    }
    // класс верблюда
    class Camel : IMounts 
    {
        public void Move()
        {
            Console.WriteLine("Верблюд идет по пескам пустыни");
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

        public void Drive()
        {
            mounts.Move();
        }
    }
}
