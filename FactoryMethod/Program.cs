using System;

namespace FactoryMethodExample
{
    //абстрактний клас творця, який має абстрактний метод FactoryMethod, що приймає тип продукта
    public abstract class BMWFactory
    {
        public Car GetCar(string type)
        {
            Car car = CreateCar(type);

            car.Configure();
            car.AssembleBody();
            car.InstallEngine();
            car.Paint();
            car.InstallWheels();

            return car;
        }
        public abstract Car CreateCar(string type);
    }

    public class DeutchBMWFactory : BMWFactory
    {
        public override Car CreateCar(string type)
        {
            Car car;

            if (type == "M3")
                car = new DeutchM3();
            else if (type == "535d")
                car = new Deutch535d();
            else if (type == "X6")
                car = new DeutchX6();
            else
                car = new Deutch320i();

            return car;
        }
    }

    //абстрактний клас продукт
    public abstract class Car
    {
        protected string Name = "BMW ";
        protected string Engine = "Diesel";
        protected string PaintColor = "White";
        protected string Wheels = "16 inch";
        protected string Body = "Sedan";

        public void Configure()
        {
            Console.WriteLine("Configuring {0}", Name);
            Console.WriteLine("Engine is: {0}", Engine);
            Console.WriteLine("Body is: {0}", Body);
            Console.WriteLine("PaintColor is: {0}", PaintColor);
            Console.WriteLine("Wheels are: {0}", Wheels);
        }

        public void AssembleBody()
        {
            Console.WriteLine("Body is assembled");
        }

        public void InstallEngine()
        {
            Console.WriteLine("Engine is in its place");
        }

        public void Paint()
        {
            Console.WriteLine("Car is painted");
        }

        public void InstallWheels()
        {
            Console.WriteLine("Wheels are installed");
        }
    }

    //конкретні продукти з різною реалізацією
    public class DeutchM3 : Car
    {
        public DeutchM3()
        {
            Name += "M3";
            Body = "Coupe";
            Engine = "Gasoline";
            PaintColor = "Silver";
            Wheels = "19 inch";
        }
    }

    public class Deutch535d : Car
    {
        public Deutch535d()
        {
            Name += "535d";
            Wheels = "17 inch";
        }
    }

    public class DeutchX6 : Car
    {
        public DeutchX6()
        {
            Name += "X6";
            Body = "SUV";
            Wheels = "17 inch";
            PaintColor = "Black";
        }
    }

    public class Deutch320i : Car
    {
        public Deutch320i()
        {
            Name += "320i";
            Engine = "Gasoline";
        }
    }
    class MainApp
    {
        static void Main()
        {       //створюємо творця

            BMWFactory factory = new DeutchBMWFactory();
            factory.GetCar("M3");
            Console.WriteLine();
            factory.GetCar("320i");
            Console.WriteLine();
            factory.GetCar("X6");
            Console.WriteLine();
            factory.GetCar("535d");

            Console.ReadKey();
        }
    }
}
