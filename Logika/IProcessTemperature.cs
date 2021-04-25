using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logika
{
    interface IProcessTemperature
    {
        void addRoom(string name);
        double getRoomTemperature(String name);
        /*double getActualTemperature();
        void setGoalTemperature(double temperature);
        string getRoomName();*/
    }
}
