using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace ProbandoMapas.View
{
    public class ViewCellExtend : ViewCell
    {
        Label menuText;
        Image menuImagen;

        public ViewCellExtend()
        {
            menuText = new Label();
            menuImagen = new Image()
            {
                Aspect = Aspect.AspectFit,
                HeightRequest = 30,
                WidthRequest = 30
            };

            StackLayout stContenedor = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Spacing = 20,
                Children =
                {
                    CreateCellBlock()
                }
            };

            //stContenedor.SetBinding(Layout.BackgroundColorProperty, new Binding("BackgroundColor"));

            View = stContenedor;
        }

        Xamarin.Forms.Layout CreateCellBlock()
        {
            StackLayout st2 = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Children =
				{
				    new StackLayout
					{
                        Padding = new Thickness(15,0,10,0),
                        HorizontalOptions = LayoutOptions.Start,
                        VerticalOptions = LayoutOptions.Center,
				    	Children = 
						{ 
                            menuImagen
						}
					},

					new StackLayout
					{
                        Padding = new Thickness(0,5,10,0),
                        HorizontalOptions = LayoutOptions.Start,
                        VerticalOptions = LayoutOptions.Center,
					    Children = 
						{
							menuText
						}
					}
				}
            };

            st2.SetBinding(Layout.BackgroundColorProperty, new Binding("BackgroundColor"));

            return st2;
        }

        public static BindableProperty BindableTextProperty = BindableProperty.Create<ViewCellExtend, string>(ctrl =>
            ctrl.TextProperty,
            defaultValue: string.Empty,
            defaultBindingMode: BindingMode.TwoWay,
            propertyChanging: (bindable, oldValue, newValue) =>
            {
                var ctrl = (ViewCellExtend)bindable;
                ctrl.TextProperty = newValue;
            });


        public string TextProperty
        {
            get { return (string)GetValue(BindableTextProperty); }
            set
            {
                SetValue(BindableTextProperty, value);
                menuText.Text = value;
            }
        }

        public static BindableProperty BindableImageProperty = BindableProperty.Create<ViewCellExtend, ImageSource>(ctrl =>
            ctrl.ImageProperty,
            defaultValue: default(ImageSource),
            defaultBindingMode: BindingMode.Default,
            propertyChanging: (bindable, oldValue, newValue) =>
                {
                    var ctrl = (ViewCellExtend)bindable;
                    ctrl.ImageProperty = newValue;
                }
            );

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            System.Diagnostics.Debug.WriteLine(BindingContext.ToString());
        }

        public ImageSource ImageProperty
        {
            get { return (ImageSource)GetValue(BindableImageProperty); }
            set
            {
                SetValue(BindableImageProperty, value);
                menuImagen.Source = value;
            }
        }
    }
}
