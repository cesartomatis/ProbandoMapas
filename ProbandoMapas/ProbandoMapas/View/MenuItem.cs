using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace ProbandoMapas.View
{
    public class MenuItem
    {
        public string Title { get; set; }

        public ImageSource IconSource { get; set; }

        public Type TargetType { get; set; }
    }
}
