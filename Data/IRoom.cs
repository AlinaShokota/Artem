using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface IRoom
    {
        double getActualTemperature();
        void setGoalTemperature(double temperature);
        string getRoomName();
        void setRoomName(string name);
    }
}
