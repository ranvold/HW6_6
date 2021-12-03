using System;

namespace Facade.Examples
{
    // Mainapp test application 
    class MainApp
    {
        public static void Main()
        {
            var water = new WaterManagingSubSystem();
            var thermo = new Thermo();
            var engine = new Engine();
            var dryer = new Dryer();

            var washingMachine = new WashingMachineFacade(water, thermo, engine, dryer);

            // Linen
            washingMachine.WashLinen();
            Console.WriteLine();

            // Silk
            washingMachine.WashSilk();
            Console.WriteLine();


            // Wait for user 
            Console.Read();
        }
    }


    // "Subsystem ClassA" 
    class WaterManagingSubSystem
    {
        public void FillWater(int litres)
        {
            Console.WriteLine("Fill with {0} litres of water", litres);
        }
        public void EmptyWater()
        {
            Console.WriteLine("Empty water tank");
        }
    }

    // Subsystem ClassB" 
    class Thermo
    {
        public void WarmUp(int degrees)
        {
            Console.WriteLine("Warm for {0} degrees", degrees);
        }
    }


    // Subsystem ClassC" 
    class Dryer
    {
        public void Dry(int seconds, int intensity)
        {
            Console.WriteLine("Drying {0} seconds with intensity {1}", seconds, intensity);
        }
    }
    // Subsystem ClassD" 
    class Engine
    {
        public void Rotate()
        {
            Console.WriteLine("Start rotating");
        }
        public void Stop()
        {
            Console.WriteLine("Stop rotating");
        }
    }
    // "Facade" 
    class WashingMachineFacade
    {
        private WaterManagingSubSystem _water;
        private Thermo _thermo;
        private Engine _engine;
        private Dryer _dryer;

        public WashingMachineFacade(WaterManagingSubSystem water, Thermo thermo, Engine engine, Dryer dryer)
        {
            _water = water;
            _thermo = thermo;
            _engine = engine;
            _dryer = dryer;
        }

        public void WashLinen()
        {
            _water.FillWater(8);
            _thermo.WarmUp(50);
            _engine.Rotate();
            _engine.Rotate();
            _engine.Stop();
            _water.EmptyWater();
            _water.FillWater(10);
            _thermo.WarmUp(30);
            _engine.Rotate();
            _engine.Rotate();
            _engine.Rotate();
            _engine.Stop();
            _water.EmptyWater();
            _dryer.Dry(40, 600);
        }

        public void WashSilk()
        { 
            _water.FillWater(9);
            _thermo.WarmUp(55);
            _engine.Rotate();
            _engine.Stop();
            _water.EmptyWater();
            _water.FillWater(12);
            _thermo.WarmUp(35);
            _engine.Rotate();
            _engine.Rotate();
            _engine.Stop();
            _water.EmptyWater();
            _dryer.Dry(35, 500);
        }
    }
}
