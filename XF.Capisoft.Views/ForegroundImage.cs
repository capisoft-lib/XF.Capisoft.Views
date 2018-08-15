using System;

using Xamarin.Forms;

namespace XF.Capisoft.Views
{
    public class ForegroundImage : View
    {
        #region ForegroundProperty

        public static readonly BindableProperty ForegroundProperty = BindableProperty.Create(nameof(Foreground), typeof(Color), typeof(ForegroundImage), default(Color));

        public Color Foreground
        {
            get
            {
                return (Color)GetValue(ForegroundProperty);
            }
            set
            {
                SetValue(ForegroundProperty, value);
            }
        }

        #endregion

        #region SourceProperty

        public static readonly BindableProperty SourceProperty = BindableProperty.Create(nameof(Source), typeof(string), typeof(ForegroundImage), default(string));

        public string Source
        {
            get
            {
                return (string)GetValue(SourceProperty);
            }
            set
            {
                SetValue(SourceProperty, value);
            }
        }

        #endregion

        public ForegroundImage()
        {

        }
    }
}

