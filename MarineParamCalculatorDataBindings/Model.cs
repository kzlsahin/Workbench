using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MarineParamCalculatorDataBindings
{
    public class Model : INotifyPropertyChanged
    {
        double _b;
        public double B
        {
            get => _b;
            set
            {
                _b = value;
                RenewDelta();
                OnPropertyChanged();
            }
        }
        double _l;
        public double L
        {
            get => _l;
            set
            {
                _l = value;
                RenewDelta();
                OnPropertyChanged();
            }
        }
        double _t;
        public double T
        {
            get => _t;
            set
            {
                _t = value;
                RenewDelta();
                OnPropertyChanged();
            }
        }
        double _cb = 1;
        public double Cb
        {
            get => _cb;
            set
            {
                _cb = value;
                RenewDelta();
                OnPropertyChanged();
            }
        }
        double _delta;
        public double Delta
        {
            get => _delta;
            set
            {
                _delta = value;
                RenewCb();
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void RenewDelta()
        {
            Delta = Cb * B * T * L;
        }
        public void RenewCb()
        {
            Cb = Delta / (B * T * L);
        }
    }
}
