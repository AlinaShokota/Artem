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

       
        private void simulateUpdateTemp()
        {
            //Console.WriteLine("actual " + actualTemperature);
            //Console.WriteLine("updating " + roomName + " temperature ...");
            if (actualTemperature < 16 || actualTemperature > 30)
            {
                simulateUpdateTemp();
            }
            int a = rnd.Next(0, 100);
            if (a > 50)
            {
                actualTemperature += 0.1;
            }
            else
            {
                actualTemperature -= 0.1;
            }

        }

        public override string ToString()
        {
            return base.ToString() + ": " + actualTemperature + " " + roomName;
        }
    }
}
