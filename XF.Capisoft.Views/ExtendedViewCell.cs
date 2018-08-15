using System;
using Xamarin.Forms;

namespace XF.Capisoft.Views
{
    public class ExtendedViewCell : ViewCell
    {
        public static readonly BindableProperty IsHighlightDisabledProperty = BindableProperty.Create(nameof(IsHighlightDisabled), typeof(bool), typeof(ExtendedViewCell), default(bool), propertyChanged: HandleBindingIsHighlightDisabledPropertyChangedDelegate);
        static void HandleBindingIsHighlightDisabledPropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue) { }
        public bool IsHighlightDisabled { get { return (bool)GetValue(IsHighlightDisabledProperty); } set { SetValue(IsHighlightDisabledProperty, value); } }
    }
}

