using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestigationGame
{
    public abstract class Sensor
    {
        public string Name { get; set; }
        public int ActivationCount { get; protected set; } = 0;
        public bool IsBroken { get; protected set; } = false;

        public Sensor(string name)
        {
            Name = name;
        }

        public abstract bool Activate(string[] weaknesses);
    }

    public class AudioSensor : Sensor
    {
        public AudioSensor() : base("Audio") { }

        public override bool Activate(string[] weaknesses)
        {
            ActivationCount++;
            return Array.Exists(weaknesses, w => w == Name);
        }
    }

    public class ThermalSensor : Sensor
    {
        public ThermalSensor() : base("Thermal") { }

        public override bool Activate(string[] weaknesses)
        {
            ActivationCount++;
            return Array.Exists(weaknesses, w => w == Name);
        }
    }

    public class PulseSensor : Sensor
    {
        public PulseSensor() : base("Pulse") { }

        public override bool Activate(string[] weaknesses)
        {
            ActivationCount++;
            if (ActivationCount >= 3) IsBroken = true;
            return Array.Exists(weaknesses, w => w == Name);
        }
    }

    public class MotionSensor : Sensor
    {
        public MotionSensor() : base("Motion") { }

        public override bool Activate(string[] weaknesses)
        {
            ActivationCount++;
            if (ActivationCount >= 3) IsBroken = true;
            return Array.Exists(weaknesses, w => w == Name);
        }
    }

    public class MagneticSensor : Sensor
    {
        public MagneticSensor() : base("Magnetic") { }

        public override bool Activate(string[] weaknesses)
        {
            ActivationCount++;
            return Array.Exists(weaknesses, w => w == Name);
        }
    }

    public class SignalSensor : Sensor
    {
        public SignalSensor() : base("Signal") { }

        public override bool Activate(string[] weaknesses)
        {
            ActivationCount++;
            return Array.Exists(weaknesses, w => w == Name);
        }
    }

    public class LightSensor : Sensor
    {
        public LightSensor() : base("Light") { }

        public override bool Activate(string[] weaknesses)
        {
            ActivationCount++;
            return Array.Exists(weaknesses, w => w == Name);
        }
    }
}
