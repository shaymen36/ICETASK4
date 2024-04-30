using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventHandling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EventHub eventHub = new EventHub();

            
            eventHub.MotionDetected += (sender, args) =>
            {
                Console.WriteLine($"Motion detected by sensor {args.SensorId} at {args.Timestamp}");
               
            };

           
            MotionSensor motionSensor = new MotionSensor(eventHub);
            motionSensor.DetectMotion("Sensor1", DateTime.Now);

            
            Console.ReadLine();
        }
    }
    public class MotionEventArgs : EventArgs
    {
        public string SensorId { get; }
        public DateTime Timestamp { get; }

        public MotionEventArgs(string sensorId, DateTime timestamp)
        {
            SensorId = sensorId;
            Timestamp = timestamp;
        }
    }
    public class MotionSensor
    {
        private EventHub _eventHub;

        public MotionSensor(EventHub eventHub)
        {
            _eventHub = eventHub;
        }

        public void DetectMotion(string sensorId, DateTime timestamp)
        {
            // Logic to detect motion
            _eventHub.TriggerMotionDetected(sensorId, timestamp);
        }
    }

}
