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
            Content = new StackLayout
            {
                Children = {
					new Label { Text = "Hello ContentPage" }
				}
            };
        }
    }
}
