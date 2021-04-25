using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logika
{
    public class ProcessTemperature : IProcessTemperature
    {

        List<Room> rooms;

        public ProcessTemperature()
        {
            rooms = new List<Room>();
        }

        public void addRoom(string roomName)
        {
            rooms.Add(new Room(roomName));
        }

        public double getRoomTemperature(string name)
        {
            //Console.WriteLine("NAME " + name);
            foreach (Room r in rooms)
            {
                
                if (r.getRoomName().Equals(name))
                {
                    //Console.WriteLine("W IF" + r.getRoomName().Equals(name));
                    return r.getActualTemperature();
                }
                    
            }
            Console.WriteLine("No room with this name exist");
            return 0;
        }


        /*Room room;

        public ProcessTemperature(string roomName, double actualTemperature, double goalTemperature)
        {
            room = new Room(roomName, actualTemperature, goalTemperature);
        }

        public double getActualTemperature()
        {
            return room.getActualTemperature();
        }

        public string getRoomName()
        {
            return room.getRoomName();
        }

        public void setGoalTemperature(double temperature)
        {
            room.setGoalTemperature(temperature);
        }*/
    }
}
