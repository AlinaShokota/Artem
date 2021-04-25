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
        IProcessTemperature processTemperature;

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
            return actual;
        }

        public void setGoalTemperature(string roomName, double goalTemperature)
        {
            processTemperature.setGoalTemp(roomName, goalTemperature);
        }
    }
}
