using System;
using Xamarin.Forms;

namespace XF.Capisoft.Views
{
    public class UnbouncedScrollView : ScrollView
    {
        public static readonly BindableProperty IsBounceableProperty = BindableProperty.Create(nameof(IsBounceable), typeof(bool), typeof(UnbouncedScrollView), default(bool), propertyChanged: HandleBindingIsBounceablePropertyChangedDelegate);
        static void HandleBindingIsBounceablePropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue) { }
        public bool IsBounceable { get { return (bool)GetValue(IsBounceableProperty); } set { SetValue(IsBounceableProperty, value); } }

        public UnbouncedScrollView() : base()
        {
        }
    }
}
