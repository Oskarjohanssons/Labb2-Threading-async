using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2_Threading_async
{
    internal class Car
    {
        private readonly Random random = new Random();
        public string Name { get; }
        public double Distance { get; private set; }
        public int Speed { get; private set; } = 120;
        public bool Finished { get; private set; }

        public Car(string name)
        {
            Name = name;
        }

        public void Drive()
        {
            Console.WriteLine($"{Name} startar....");

            while (Distance < 10) 
            {
                Distance += Speed / 3600.0; //Ändrar hastigheten från km/h till km/s
                Thread.Sleep(1000);

                if (random.Next(1, 51) == 1)
                    OutOfGas();
                else if (random.Next(1, 51) <= 2)
                    FlatTire();
                else if (random.Next(1, 51) <= 5)
                    DirtyWindshield();
                else if (random.Next(1,51) <= 10)
                    EngineTrouble();
                else if(random.Next(1,101) <= 10)
                    SpeedBoost();

            }

            Finished = true;
            Console.WriteLine($"{Name} kom i mål!!");
        }

        private void OutOfGas()
        {
            Console.WriteLine($"{Name} har slut på bensin och behöver tanka! Stannar i 30 sekunder.");
            Thread.Sleep(30000);
        }

        private void FlatTire()
        {
            Console.WriteLine($"{Name} fick en punktering och behöver byta däck! Stannar i 20 sekunder.");
            Thread.Sleep(20000);
        }

        private void DirtyWindshield()
        {
            Console.WriteLine($"{Name} har en fågel på vindrutan och behöver tvätta den! Stannar i 10 sekunder.");
            Thread.Sleep(10000);
        }

        private void EngineTrouble()
        {
            Console.WriteLine($"{Name} har motorfel och hastigheten sänks med 1 km/h.");
            Speed -= 1;
        }

        private void SpeedBoost()
        {
            int boostAmount = random.Next(10, 31);
            Speed += boostAmount;
            Console.WriteLine($"{Name} fick en hastighetsökning och ökar hastigheten med {boostAmount} km/h!");
        }
    }
}
