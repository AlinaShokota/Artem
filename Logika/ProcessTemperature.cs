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

    }
}
