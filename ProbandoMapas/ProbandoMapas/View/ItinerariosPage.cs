using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace ProbandoMapas.View
{
    public class ItinerariosPage : ContentPage
    {
        public ItinerariosPage()
        {
            ListView list = new ListView();
            var celda = new DataTemplate(typeof(ViewCellExtend));
            Label idItinerario = new Label()
            {
                Font = Font.SystemFontOfSize(NamedSize.Large, FontAttributes.Bold),
                TextColor = Color.Maroon
            };
            //idItinerario.SetBinding(Label.BindingContextProperty, ProbandoMapas.ViewModel.VMListadoItinerarios.ItineraryList.)
            
            var outerLayout = new StackLayout()
            {
                Orientation=StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.White,
                Children = { idItinerario } 
            };
            outerLayout.Padding = new Thickness(20, 0, 0, 0);
            outerLayout.VerticalOptions = LayoutOptions.Center;
            outerLayout.HorizontalOptions = LayoutOptions.Center;

            Label description = new Label()
            {
                Font = Font.SystemFontOfSize(NamedSize.Large, FontAttributes.Bold),
                TextColor = Color.Gray
            };

            Label OriginAdress = new Label()
            {
                Font = Font.SystemFontOfSize(NamedSize.Large, FontAttributes.Bold),
                TextColor = Color.Gray
            };

            var innerLayout = new StackLayout()
            {
                Children =
                {
                    description, OriginAdress
                }
            };

            Button flecha = new Button()
            {
                Font = Font.SystemFontOfSize(NamedSize.Large, FontAttributes.Bold),
                TextColor = Color.Black,
                BackgroundColor = Color.Transparent,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center
            };

            var downLayout = new StackLayout()
            {
                Children = { flecha }
            };
            downLayout.Padding = new Thickness(20, 0, 0, 0);
            downLayout.VerticalOptions = LayoutOptions.Center;
            downLayout.HorizontalOptions = LayoutOptions.End;

            //list.SetBinding(ListView.BindingContextProperty, ProbandoMapas.ViewModel.VMListadoItinerarios.ItineraryList.ToString());

            


            Content = list;
        }
    }
}
