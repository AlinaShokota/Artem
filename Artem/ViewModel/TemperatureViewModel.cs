using Artem.Model;
using Logika;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Artem.ViewModel
{
    class TemperatureViewModel : INotifyPropertyChanged
    {
        public DispatcherTimer _timer;
        TemperaturaModel temperaturaModel;

        private double currentTemp;
        public double CurrentTemp
        {
            get
            {
                return this.currentTemp;
            }
            set
            {

                currentTemp = value;
                OnPropertyChanged();
            }
        }

        private string selectedRoom = "";
        public string SelectedRoom
        {
            get { return selectedRoom; }
            set
            {
                selectedRoom = value;
                OnPropertyChanged();
            }
        }


        public TemperatureViewModel()
        {
            temperaturaModel = new TemperaturaModel();
            temperaturaModel.initData();


            double temp = temperaturaModel.getRoomTemperature(selectedRoom);
            CurrentTemp = Math.Round(temp, 2);
            _timer = new DispatcherTimer(DispatcherPriority.Render);
            _timer.Interval = TimeSpan.FromSeconds(3);
            _timer.Tick += (sender, args) =>
            {
                temp = temperaturaModel.getRoomTemperature(selectedRoom);
                CurrentTemp = Math.Round(temp, 2);
                Console.WriteLine(CurrentTemp);
            };
            _timer.Start();
        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


    }
}
