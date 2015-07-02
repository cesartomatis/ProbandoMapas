using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace ProbandoMapas.View
{
    public class CustomViewCell : ViewCell
    {
        public CustomViewCell()
        {
            var tour_Desc = new Xamarin.Forms.ViewCell();
            var round_Desc = new Xamarin.Forms.ViewCell();

            Label Test = new Label()
            {
                Font = Font.BoldSystemFontOfSize(17),
                //TextColor = Xamarin.Forms.Labs.Helpers.Color.AppGreen.ToFormsColor(),
                BackgroundColor = Color.White,
                Text = "Prueba"
            };

            var image = new Image();
            image.Source = ImageSource.FromFile("ic_car_grey600_24dp.png");

            Label Test2 = new Label()
            {
                Text = "Prueba 2"
            };

            //tour_Desc.SetBinding(Label.TextProperty, "Test");
            //round_Desc.SetBinding(Label.TextProperty, "Test2");

            var grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,

                RowDefinitions = 
            {
                new RowDefinition {Height = GridLength.Auto },
                new RowDefinition {Height = GridLength.Auto },
                new RowDefinition {Height = 1}
            },
                ColumnDefinitions = 
            {
                new ColumnDefinition {Width = GridLength.Auto},
                new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
                new ColumnDefinition {Width = 80 }
            }
                ,
                BackgroundColor = Color.White,
            };

            grid.Children.Add(image, 0, 0);
            Grid.SetRowSpan(image, 2);

            //grid.Children.Add(tour_Desc, 1, 0);
            //Grid.SetColumnSpan(tour_Desc, 2);

            grid.Children.Add(Test, 1, 1);
            grid.Children.Add(Test2, 1, 2);

            this.View = grid;
        }

    }
}
