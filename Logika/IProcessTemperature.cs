using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logika
{
    public interface IProcessTemperature
    {
        void addRoom(string name);
        double getRoomTemperature(String name);
        void setGoalTemp(string roomName, double goalTemp);
        /*double getActualTemperature();
        void setGoalTemperature(double temperature);
        string getRoomName();*/
    }
}
