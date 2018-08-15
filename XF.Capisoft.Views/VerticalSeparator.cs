using System;

using Xamarin.Forms;

namespace XF.Capisoft.Views
{
    public class VerticalSeparator : ContentView
    {
        public VerticalSeparator()
        {
            BackgroundColor = Color.Gray;
            WidthRequest = 1;
            VerticalOptions = LayoutOptions.FillAndExpand;
        }
    }
}

