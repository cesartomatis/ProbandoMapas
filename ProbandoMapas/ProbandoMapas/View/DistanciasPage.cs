using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace ProbandoMapas.View
{
    public class DistanciasPage : ContentPage
    {
        Entry pUno, pDos;
        Button btnDistancia;
        Label lblMetros, lblKm, lblMillas;

        public DistanciasPage()
        {
            initConfig();

            StackLayout stContenedor = new StackLayout() 
            { 
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.Center,
                Spacing = 20,
                Children =
                {
                    pUno,
                    pDos,
                    btnDistancia,
                    lblMetros,
                    lblKm,
                    lblMillas
                }
            };

            Content = stContenedor;
        }

        public void initConfig()
        {
            pUno = new Entry();
            pUno.SetBinding(Entry.TextProperty, new Binding("PosUno"));

            pDos = new Entry();
            pDos.SetBinding(Entry.TextProperty, new Binding("PosDos"));

            btnDistancia = new Button();
            btnDistancia.Text = "Obtener Distancia";
            btnDistancia.SetBinding(Button.CommandProperty, new Binding("Distancia_Clicked"));

            lblMetros = new Label();
            lblMetros.SetBinding(Label.TextProperty, new Binding("LblDistanciaMetros"));

            lblKm = new Label();
            lblKm.SetBinding(Label.TextProperty, new Binding("LblDistanciaKilometros"));

            lblMillas = new Label();
            lblMillas.SetBinding(Label.TextProperty, new Binding("LblDistanciaMillas"));
        }
    }
}
