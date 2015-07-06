using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace ProbandoMapas.View
{
    public class MenuCell : ViewCell
    {
        public MenuCell()
        {
            this._isSelected = false;
            this.SelectedBackgroundColor = Color.Red;

            var imageLayout = CreateImageLayout();
            var nameLayout = CreateNameLayout();

            var viewLayout = new StackLayout()
            {
                //HorizontalOptions = LayoutOptions.StartAndExpand,
                Spacing = 20,
                Orientation = StackOrientation.Horizontal,
                Children = { imageLayout, nameLayout }
            };

            View = viewLayout;
        }

        static StackLayout CreateNameLayout()
        {
            var nameLabel = new Label
            {
                //HorizontalOptions = LayoutOptions.StartAndExpand,
                //VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
            };
            nameLabel.SetBinding(Label.TextProperty, "Title");

            var nameLayout = new StackLayout()
            {
                Padding = new Thickness(0,5,10,0),
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                Orientation = StackOrientation.Vertical,
                Children = { nameLabel }
            };
            return nameLayout;
        }

        static StackLayout CreateImageLayout()
        {
            var image = new Image
            {
                HorizontalOptions = LayoutOptions.Start
            };

            image.SetBinding(Image.SourceProperty, new Binding("IconSource"));
            image.WidthRequest = image.HeightRequest = 30;

            var imageLayout = new StackLayout()
            {
                Padding = new Thickness(15,0,10,0),
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                Orientation = StackOrientation.Vertical,
                Children = { image }
            };
            return imageLayout;
        }

        public const string IsSelectedPropertyName = "IsSelected";

        private bool _isSelected;

        public bool IsSelected 
        {
            get
            {
                return this._isSelected;
            }
            set
            {
                this._isSelected = value;
                this.OnPropertyChanged(IsSelectedPropertyName);
            }
        }

        public Color SelectedBackgroundColor { get; set; }
    }
}
