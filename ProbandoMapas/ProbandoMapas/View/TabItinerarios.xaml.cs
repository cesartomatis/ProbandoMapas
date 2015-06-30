using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace ProbandoMapas.View
{
    public partial class TabItinerarios
    {
        public TabItinerarios()
        {
            InitializeComponent();

            ProbandoMapas.ViewModel.VMListadoItinerarios Listado = new ViewModel.VMListadoItinerarios();
            Listado.rellenar();
        }
    }
}
