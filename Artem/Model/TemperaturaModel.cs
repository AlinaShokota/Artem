using Logika;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Artem.Model
{
    class TemperaturaModel
    {
        ProcessTemperature processTemperature;

        public TemperaturaModel()
        {
            processTemperature = new ProcessTemperature();
        }

        public void initData()
        {
            processTemperature.addRoom("bedroom");
            processTemperature.addRoom("kitchen");
            processTemperature.addRoom("livingroom");
        }

        public double getRoomTemperature(string roomName)
        {
            double actual = processTemperature.getRoomTemperature(roomName);
            Console.WriteLine("GET ROOM "+ roomName+ " TEMP: "+actual);
            return actual;
        }
    }
}
