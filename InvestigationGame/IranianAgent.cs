using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGame
{
    public abstract class IranianAgent
    {
        public string Rank { get; protected set; }
        public int TurnCounter { get; protected set; } = 0;
        public string[] Weaknesses { get; protected set; }
        public List<Sensor> AttachedSensors { get; private set; } = new List<Sensor>();

        public IranianAgent(string rank, string[] weaknesses)
        {
            Rank = rank;
            Weaknesses = weaknesses;
        }

        public int ActivateSensors()
        {
            TurnCounter++;
            int match = 0;
            foreach (var sensor in AttachedSensors)
            {
                if (!sensor.IsBroken && sensor.Activate(Weaknesses))
                    match++;
            }
            PerformCounterattack();
            return match;
        }

        public bool IsExposed() => ActivateSensors() == Weaknesses.Length;

        public void AttachSensor(Sensor sensor)
        {
            if (!sensor.IsBroken)
                AttachedSensors.Add(sensor);
        }

        public abstract void PerformCounterattack();
    }

    public class FootSoldier : IranianAgent
    {
        public FootSoldier() : base("Foot Soldier", GenerateWeaknesses(2)) { }

        public override void PerformCounterattack() { }

        private static string[] GenerateWeaknesses(int count)
        {
            var options = new[] { "Audio", "Thermal" };
            var rand = new Random();
            var result = new string[count];
            for (int i = 0; i < count; i++)
                result[i] = options[rand.Next(options.Length)];
            return result;
        }
    }

    public class SquadLeader : IranianAgent
    {
        public SquadLeader() : base("Squad Leader", GenerateWeaknesses(4)) { }

        public override void PerformCounterattack()
        {
            if (TurnCounter % 3 == 0 && AttachedSensors.Count > 0)
            {
                var rand = new Random();
                AttachedSensors.RemoveAt(rand.Next(AttachedSensors.Count));
            }
        }

        private static string[] GenerateWeaknesses(int count)
        {
            var options = new[] { "Audio", "Thermal", "Pulse", "Motion" };
            var rand = new Random();
            var result = new string[count];
            for (int i = 0; i < count; i++)
                result[i] = options[rand.Next(options.Length)];
            return result;
        }
    }
}
