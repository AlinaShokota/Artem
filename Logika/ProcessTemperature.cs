using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logika
{
    public class ProcessTemperature : IProcessTemperature
    {

        List<IRoom> rooms;

        public ProcessTemperature()
        {
            rooms = new List<IRoom>();
        }

        public void addRoom(string roomName)
        {
            rooms.Add(new Room(roomName));
        }

        public double getRoomTemperature(string name)
        {
            foreach (Room r in rooms)
            {
                
                if (r.getRoomName().Equals(name))
                {
                    return r.getActualTemperature();
                }
                    
            }
            Console.WriteLine("No room with this name exist");
            return 0;
        }

        public void setGoalTemp(string roomName, double goalTemp)
        {
            foreach (Room r in rooms)
            {

                if (r.getRoomName().Equals(roomName))
                {
                    r.setGoalTemperature(goalTemp);
                }
                else
                {
                    Console.WriteLine("No room with this name exist");
                }

            }
            
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
