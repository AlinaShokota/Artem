using Artem.Model;
using Logika;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Artem.ViewModel
{
    class TemperatureViewModel : INotifyPropertyChanged
    {
        public DispatcherTimer _timer;
        public ICommand SubmitButtonCommand { get; set; }
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

        private double goalTemp;
        public double GoalTemp
        {
            get
            {
                return goalTemp;
            }
            set
            {
                goalTemp = value;
                CheckAndEnableButton();
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
            };
            _timer.Start();
        }

        public void CheckAndEnableButton()
        {
            string result = string.Empty;
            if (SelectedRoom.Equals(""))
            {
                result = string.Format("Choose the room!");
                SubmitButtonCommand = new RelayCommand((ob) => { return true; }, (ob) => {
                    MessageBox.Show(result);
                });
            }
            else
            {
                if (GoalTemp >= 17 && GoalTemp <= 28)
                {
                    result = string.Format("Goal temperature is set: \n{0}", GoalTemp);
                    SubmitButtonCommand = new RelayCommand((ob) => { return true; }, (ob) => {
                        MessageBox.Show(result);
                        temperaturaModel.setGoalTemperature(selectedRoom, GoalTemp);
                    });
                }
                else if (GoalTemp > 28)
                {
                    result = result = string.Format("Goal temperature \n{0} is too high. Enter lower temperature", GoalTemp);
                    SubmitButtonCommand = new RelayCommand((ob) => { return true; }, (ob) => {
                        MessageBox.Show(result);
                    });
                }
                else
                {
                    result = result = string.Format("Goal temperature \n{0} is too low. Enter higher temperature", GoalTemp);
                    SubmitButtonCommand = new RelayCommand((ob) => { return true; }, (ob) => {
                        MessageBox.Show(result);
                    });
                }
            }

            OnPropertyChanged("SubmitButtonCommand");

        }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


    }
}
