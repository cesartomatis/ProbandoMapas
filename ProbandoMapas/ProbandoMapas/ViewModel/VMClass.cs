using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using System.ComponentModel;
using ProbandoMapas.Model;
using System.Windows.Input;

namespace ProbandoMapas.ViewModel
{
    public class VMClass : INotifyPropertyChanged
    {
        #region Declaracion de variables
        private string _GetCoordsLabel;
        private string _AdressLabel;
        private string _GetAdressLabel;

        private List<string> _LvLista;
        private string _PosUno;
        private string _PosDos;
        private string _LblDistanciaMetros;
        private string _LblDistanciaKilometros;
        private string _LblDistanciaMillas;

        PosicionamientoLogica plObj;

        public string LblDistanciaMillas
        {
            get
            {
                return _LblDistanciaMillas;
            }
            set
            {
                _LblDistanciaMillas = value;
                OnPropertyChanged("LblDistanciaMillas");
            }
        }

        public string LblDistanciaKilometros
        {
            get
            {
                return _LblDistanciaKilometros;
            }
            set
            {
                _LblDistanciaKilometros = value;
                OnPropertyChanged("LblDistanciaKilometros");
            }
        }

        public string LblDistanciaMetros
        {
            get
            {
                return _LblDistanciaMetros;
            }
            set
            {
                _LblDistanciaMetros = value;
                OnPropertyChanged("LblDistanciaMetros");
            }
        }

        public string PosUno
        {
            get
            {
                return _PosUno;
            }
            set
            {
                _PosUno = value;
                OnPropertyChanged("PosUno");
            }
        }

        public string PosDos
        {
            get
            {
                return _PosDos;
            }
            set
            {
                _PosDos = value;
                OnPropertyChanged("PosDos");
            }
        }        

        public string GetCoordsLabel
        {
            get { return _GetCoordsLabel; }
            set
            {
                _GetCoordsLabel = value;
                OnPropertyChanged("GetCoordsLabel");
            }
        }        

        public string AdressLabel
        {
            get { return _AdressLabel; }
            set
            {
                _AdressLabel = value;
                OnPropertyChanged("AdressLabel");
            }
        }

        public string GetAdressLabel
        {
            get { return _GetAdressLabel; }
            set
            {
                _GetAdressLabel = value;
                OnPropertyChanged("GetAdressLabel");
            }
        }

        public ICommand GetCoords { get; set; }
        public ICommand GetAdress { get; set; }
        public ICommand Rellenador { get; set; }
        public ICommand Distancia_Clicked { get; set; }
        #endregion

        public VMClass()
        {
            plObj = new PosicionamientoLogica();

            GetCoords = new Command(GetCoordsEvent);
            GetAdress = new Command(GetandShowAdress);
            Distancia_Clicked = new Command(GetDistancia);
        }

        private async void GetCoordsEvent()
        {
            var rta = await plObj.GetCoordenadas();
            GetCoordsLabel = "You're on " + rta;
        }

        private async void GetandShowAdress()
        {
            var rta = await plObj.ShowMyAdress();
            GetAdressLabel = "You're looking for " + rta;
        }

        private async void GetDistancia()
        {
            double dMtrs = await plObj.GetDistancia(PosUno, PosDos);
            LblDistanciaMetros = "La distancia en metros es: " + dMtrs.ToString();

            double dKm = dMtrs / 1000.0;
            LblDistanciaKilometros = "La distancia en kilometros es: " + dKm.ToString();

            double dMillas = dMtrs * 0.000621371192;
            LblDistanciaMillas = "La distancia en millas es: " + dMillas.ToString();
        }   

        #region INPC
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
