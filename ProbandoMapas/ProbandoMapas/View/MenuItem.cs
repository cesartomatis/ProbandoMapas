using System;
using Xamarin.Forms;
using System.Collections.Generic;

using System.ComponentModel;

namespace ProbandoMapas.View
{
    public class MenuItem : INotifyPropertyChanged
    {
        public string Title { get; set; }

        public ImageSource IconSource { get; set; }

        public Type TargetType { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private Color _backgroundColor;

        public Color BackgroundColor
        {
            get { return _backgroundColor; }
            set
            {
                _backgroundColor = value;

                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("BackgroundColor"));
                }
            }
        }

        public void SetColors(bool isSelected)
        {
            if (isSelected)
            {
                BackgroundColor = Color.Accent;
            }
            else
            {
                BackgroundColor = Color.Transparent;
            }
        }
    }
}
