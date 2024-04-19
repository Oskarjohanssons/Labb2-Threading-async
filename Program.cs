namespace Labb2_Threading_async
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Car erminsBil = new Car("Ermins BMW");
            Car oskarsBil = new Car("Oskars SAAB");

            Thread erminsThread = new Thread(() => erminsBil.Drive());
            Thread oskarsThread = new Thread(() => oskarsBil.Drive());

            Console.WriteLine("Klara....");
            Thread.Sleep(300);
            Console.WriteLine("Färdiga....");
            Thread.Sleep(300);
            Console.WriteLine("Gå!!!!");
            Thread.Sleep(300);

            Console.WriteLine("Tävlingen har börjat!");

            erminsThread.Start();
            oskarsThread.Start();

            Thread statusThread = new Thread(() =>
            {
                while (!erminsBil.Finished || !oskarsBil.Finished)
                {
                    if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Enter) 
                    {
                        Console.WriteLine("\nTävlingsstatus:");
                        Console.WriteLine($"{erminsBil.Name}: {erminsBil.Distance:F2} km, Hastighet: {erminsBil.Speed} km/h");
                        Console.WriteLine($"{oskarsBil.Name}: {oskarsBil.Distance:F2} km, Hastighet: {oskarsBil.Speed} km/h");
                    }
                }
            });

            statusThread.Start();

            erminsThread.Join();
            oskarsThread.Join();

            Car winner = erminsBil.Distance > oskarsBil.Distance ? erminsBil : oskarsBil;
            Car loser = erminsBil.Distance > oskarsBil.Distance ? oskarsBil : erminsBil;


            Console.WriteLine("\nAlla bilar har kommit i mål!");

            Console.WriteLine("\nVinnaren är: ");
            for (int i = 0; i < 5; i++)
            {
                if (i % 2 == 0)
                    Console.ForegroundColor = ConsoleColor.Yellow;
                else 
                    Console.ForegroundColor = ConsoleColor.Cyan;

                Console.Write(winner.Name.ToUpper() + "!! ");
                Thread.Sleep(500);
            }
            Console.ResetColor();

            Console.WriteLine($"\n\nFörloraren är {loser.Name}.");
            Thread.Sleep(1000);

            Console.WriteLine("\nRace finished!");
            Console.ReadKey();
        }
    }
}
