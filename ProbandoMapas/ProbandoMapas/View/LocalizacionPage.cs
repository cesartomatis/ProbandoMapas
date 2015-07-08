using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace ProbandoMapas.View
{
    public class LocalizacionPage : ContentPage
    {
        Label lblCoordenadas, lblAdress;
        Button btnCoordenadas, btnDireccion, btnLista;
        ListView lvDatosCercanos;

        public LocalizacionPage()
        {
            this.BindingContext = new ViewModel.VMClass();

            initConfig();

            StackLayout stContenedor = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.Start,
                Spacing = 20,
                Children =
                {
                    lblCoordenadas,
                    btnCoordenadas,
                    lblAdress,
                    btnDireccion,
                    lvDatosCercanos,
                    btnLista
                }
            };

            if (Device.OS == TargetPlatform.iOS)
            {
                stContenedor.Padding = new Thickness(0, 20, 0, 0);
            }

            Content = stContenedor;
        }

        public void initConfig()
        {
            lblCoordenadas = new Label();
            lblCoordenadas.VerticalOptions = LayoutOptions.Center;
            lblCoordenadas.HorizontalOptions = LayoutOptions.Center;
            lblCoordenadas.SetBinding(Label.TextProperty, new Binding("GetCoordsLabel"));

            lblAdress = new Label();
            lblAdress.VerticalOptions = LayoutOptions.Center;
            lblAdress.HorizontalOptions = LayoutOptions.Center;
            lblAdress.SetBinding(Label.TextProperty, new Binding("GetAdressLabel"));

            btnCoordenadas = new Button();
            btnCoordenadas.Text = "Get Coords";
            btnCoordenadas.SetBinding(Button.CommandProperty, new Binding("GetCoords"));

            btnDireccion = new Button();
            btnDireccion.Text = "Get Direction";
            btnDireccion.SetBinding(Button.CommandProperty, new Binding("GetAdress"));

            btnLista = new Button();
            btnLista.Text = "Rellenar Lista";
            btnLista.SetBinding(Button.CommandProperty, new Binding("Rellenador"));

            lvDatosCercanos = new ListView();
            lvDatosCercanos.HeightRequest = 100;
            lvDatosCercanos.SetBinding(ListView.ItemsSourceProperty, new Binding("LvDatos"));
        }
    }
}
