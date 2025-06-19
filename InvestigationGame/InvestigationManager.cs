using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGame
{
    public class InvestigationManager
    {
        private IranianAgent currentAgent;
        private int successfulReveals = 0;

        public void Start()
        {
            Console.WriteLine("Investigation Game Started");

            while (true)
            {
                if (successfulReveals == 0)
                {
                    currentAgent = new FootSoldier();
                }
                else
                {
                    currentAgent = new SquadLeader();
                }

                while (!currentAgent.IsExposed())
                {
                    Console.WriteLine("Choose a sensor to attach: 1. Audio 2. Thermal 3. Pulse 4. Motion");
                    string choice = Console.ReadLine();
                    Sensor sensor = null;
                    switch (choice)
                    {
                        case "1":
                            sensor = new AudioSensor();
                            break;
                        case "2":
                            sensor = new ThermalSensor();
                            break;
                        case "3":
                            sensor = new PulseSensor();
                            break;
                        case "4":
                            sensor = new MotionSensor();
                            break;
                        default:
                            Console.WriteLine("Invalid input.");
                            continue;
                    }


                    currentAgent.AttachSensor(sensor);
                    int matches = currentAgent.ActivateSensors();
                    Console.WriteLine($"Sensor matched {matches}/{currentAgent.Weaknesses.Length}");
                }

                Console.WriteLine($"Agent {currentAgent.Rank} exposed! ✅\n");
                successfulReveals++;
                

                Console.WriteLine("Press any key to continue to next agent or Esc to stop the game");
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Escape)
                    break;
            }
        }
    }
}
