using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;

using Xamarin.Forms;
using ProbandoMapas.Model;

namespace ProbandoMapas.ViewModel
{
    public class VMListadoItinerarios: INotifyPropertyChanged
    {
        public string ordinalNumber { get; set; }
        public string ClientName { get; set; }
        public string ClientAdress { get; set; }



        public event PropertyChangedEventHandler PropertyChanged;
    }
}
