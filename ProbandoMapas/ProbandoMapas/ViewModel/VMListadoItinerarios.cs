using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;


using Xamarin.Forms;
using ProbandoMapas.Model;
using System.Collections.ObjectModel;

namespace ProbandoMapas.ViewModel
{
    public class VMListadoItinerarios: INotifyPropertyChanged
    {
        public ObservableCollection<Itinerary> ItineraryList { get; set; }

        public ICommand viewDetails_OnClicked { get; set; }

        int contador = 1;

        public VMListadoItinerarios()
        {
            viewDetails_OnClicked = new Command(getDetails);

            #region Lista
            ItineraryList = new ObservableCollection<Itinerary>()
            {

                new Itinerary{Description = "Runzheimer Intl.", OriginAndress = "Alvear 1670, Rosario, Santa Fe", FinalAndress = "851 Cornerstone Crossing Waterford, WI 53185, Estados Unidos", ItineraryMiles = 45.0, OriginTime=DateTime.Today, FinalTime=DateTime.Today, ItineraryDay = DateTime.Today, IdItinerario = contador++ },
                new Itinerary{Description = "Caesar's Palace", OriginAndress = "Alvear 1670, Rosario, Santa Fe", FinalAndress = "Juan A. Maza 3754, Rosario, Argentina", ItineraryMiles = 45.0, OriginTime=DateTime.Today, FinalTime=DateTime.Today, ItineraryDay = DateTime.Today, IdItinerario = contador++ },
                new Itinerary{Description = "Abel Enterprises", OriginAndress = "Alvear 1670, Rosario, Santa Fe", FinalAndress = "Alem 2276, Rosario, Argentina", ItineraryMiles = 12.233, OriginTime=DateTime.Today, FinalTime=DateTime.Today, ItineraryDay = DateTime.Today, IdItinerario = contador++ },
                new Itinerary{Description = "Casino Royale", OriginAndress = "Alvear 1670, Rosario, Santa Fe", FinalAndress = "Bv. Oroño 6300, Rosario, Santa Fe", ItineraryMiles = 45.4, OriginTime=DateTime.Today, FinalTime=DateTime.Today, ItineraryDay = DateTime.Today, IdItinerario = contador++ },
                new Itinerary{Description = "Casino Cal.", OriginAndress = "Alvear 1670, Rosario, Santa Fe", FinalAndress = "Callao 100 bis, Rosario, Santa Fe", ItineraryMiles = 25.0, OriginTime=DateTime.Today, FinalTime=DateTime.Today, ItineraryDay = DateTime.Today, IdItinerario = contador++ },
                new Itinerary{Description = "Racket shaker", OriginAndress = "Alvear 1670, Rosario, Santa Fe", FinalAndress = "Gaboto 552, Rosario, Santa Fe", ItineraryMiles = 25.0, OriginTime=DateTime.Today, FinalTime=DateTime.Today, ItineraryDay = DateTime.Today, IdItinerario = contador++ },
                new Itinerary{Description = "Souless corp.", OriginAndress = "Alvear 1670, Rosario, Santa Fe", FinalAndress = "Dean Funes 740, Rosario, Santa Fe", ItineraryMiles = 25.0, OriginTime=DateTime.Today, FinalTime=DateTime.Today, ItineraryDay = DateTime.Today,IdItinerario = contador++ },
                new Itinerary{Description = "Runzheimer Intl.", OriginAndress = "Alvear 1670, Rosario, Santa Fe", FinalAndress = "851 Cornerstone Crossing Waterford, WI 53185, Estados Unidos", ItineraryMiles = 45.0, OriginTime=DateTime.Today, FinalTime=DateTime.Today, ItineraryDay = DateTime.Today, IdItinerario = contador++ },
                new Itinerary{Description = "Caesar's Palace", OriginAndress = "Alvear 1670, Rosario, Santa Fe", FinalAndress = "Juan A. Maza 3754, Rosario, Argentina", ItineraryMiles = 45.0, OriginTime=DateTime.Today, FinalTime=DateTime.Today, ItineraryDay = DateTime.Today, IdItinerario = contador++ },
                new Itinerary{Description = "Abel Enterprises", OriginAndress = "Alvear 1670, Rosario, Santa Fe", FinalAndress = "Alem 2276, Rosario, Argentina", ItineraryMiles = 12.233, OriginTime=DateTime.Today, FinalTime=DateTime.Today, ItineraryDay = DateTime.Today, IdItinerario = contador++ },
                new Itinerary{Description = "Casino Royale", OriginAndress = "Alvear 1670, Rosario, Santa Fe", FinalAndress = "Bv. Oroño 6300, Rosario, Santa Fe", ItineraryMiles = 45.4, OriginTime=DateTime.Today, FinalTime=DateTime.Today, ItineraryDay = DateTime.Today, IdItinerario = contador++ },
                new Itinerary{Description = "Runzheimer Intl.", OriginAndress = "Alvear 1670, Rosario, Santa Fe", FinalAndress = "851 Cornerstone Crossing Waterford, WI 53185, Estados Unidos", ItineraryMiles = 45.0, OriginTime=DateTime.Today, FinalTime=DateTime.Today, ItineraryDay = DateTime.Today, IdItinerario = contador++ },
                new Itinerary{Description = "Caesar's Palace", OriginAndress = "Alvear 1670, Rosario, Santa Fe", FinalAndress = "Juan A. Maza 3754, Rosario, Argentina", ItineraryMiles = 45.0, OriginTime=DateTime.Today, FinalTime=DateTime.Today, ItineraryDay = DateTime.Today, IdItinerario = contador++ },
                new Itinerary{Description = "Abel Enterprises", OriginAndress = "Alvear 1670, Rosario, Santa Fe", FinalAndress = "Alem 2276, Rosario, Argentina", ItineraryMiles = 12.233, OriginTime=DateTime.Today, FinalTime=DateTime.Today, ItineraryDay = DateTime.Today, IdItinerario = contador++ },
                new Itinerary{Description = "Casino Royale", OriginAndress = "Alvear 1670, Rosario, Santa Fe", FinalAndress = "Bv. Oroño 6300, Rosario, Santa Fe", ItineraryMiles = 45.4, OriginTime=DateTime.Today, FinalTime=DateTime.Today, ItineraryDay = DateTime.Today, IdItinerario = contador++ }



            };
            #endregion
        }

        private async void getDetails()
        {

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
