using System;

using Xamarin.Forms;

namespace XF.Capisoft.Views
{
    public class HorizontalSeparator : ContentView
    {
        public HorizontalSeparator()
        {
            BackgroundColor = Color.Gray;
            HeightRequest = 1;
            HorizontalOptions = LayoutOptions.FillAndExpand;
        }
    }
}

