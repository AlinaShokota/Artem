using System;

namespace Data
{
    public class Room : IRoom
    {
        private double actualTemperature;
        private double goalTemperature;
        private string roomName;

        public Room(string roomName, double goalTemperature)
        {
            this.roomName = roomName;
            this.actualTemperature = generateActualTemp();
            this.goalTemperature = goalTemperature;
        }
        public Room(string roomName)
        {
            this.roomName = roomName;
            this.actualTemperature = generateActualTemp();
            this.goalTemperature = 0;
        }
        public double getActualTemperature()
        {
            return actualTemperature;
        }

        public string getRoomName()
        {
            simulateUpdateTemp();
            return roomName;
        }

        public void setGoalTemperature(double temperature)
        {
            goalTemperature = temperature;
            Console.WriteLine("GOAL TEMPERATURE**********"+ goalTemperature);
        }

        public void setRoomName(string name)
        {
            roomName = name;
        }

        private static Random rnd = new Random();
        private static double generateActualTemp()
        {
            return rnd.Next(18, 30);
        }

        private Random rnd2 = new Random();
        private void simulateUpdateTemp()
        {
            
            if (goalTemperature == 0 || Math.Round(goalTemperature, 1) == Math.Round(actualTemperature, 1))
            {
                Console.WriteLine("random " + Math.Round(goalTemperature, 1) + " "+ Math.Round(actualTemperature, 1));
                if (actualTemperature < 16 || actualTemperature > 30)
                {
                    simulateUpdateTemp();
                }
                int a = rnd2.Next(0, 100);
                if (a > 50)
                {
                    actualTemperature += 0.1;
                }
                else
                {
                    actualTemperature -= 0.1;
                }
            }
            else
            {
                Console.WriteLine("increase decease " + goalTemperature + " " + actualTemperature);
                if (actualTemperature < goalTemperature)
                {
                    actualTemperature += 0.1;
                }
                else if (actualTemperature > goalTemperature)
                {
                    actualTemperature -= 0.1;
                }
                else
                {

                }
            }
            

        }

        public override string ToString()
        {
            return base.ToString() + ": " + actualTemperature + " " + roomName;
        }
    }
}
