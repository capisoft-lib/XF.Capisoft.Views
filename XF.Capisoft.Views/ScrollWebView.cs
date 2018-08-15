using System;
using Xamarin.Forms;

namespace XF.Capisoft.Views
{
    public class ScrollWebView : WebView
    {
        public static readonly BindableProperty PaddingProperty = BindableProperty.Create(nameof(Padding), typeof(Thickness), typeof(ScrollWebView), default(Thickness), propertyChanged: HandleBindingPaddingPropertyChangedDelegate);
        static void HandleBindingPaddingPropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue) { }
        public Thickness Padding { get { return (Thickness)GetValue(PaddingProperty); } set { SetValue(PaddingProperty, value); } }

        public static readonly BindableProperty PostFunctionProperty = BindableProperty.Create(nameof(PostFunction), typeof(string), typeof(ScrollWebView), default(string), propertyChanged: HandleBindingPostFunctionPropertyChangedDelegate);
        static void HandleBindingPostFunctionPropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue) { }
        public string PostFunction { get { return (string)GetValue(PostFunctionProperty); } set { SetValue(PostFunctionProperty, value); } }

        public event EventHandler OnScroll;

        public ScrollWebView() : base()
        {

        }

        public void Scrolled(ScrolledEventArgs args)
        {
            if (OnScroll != null)
            {
                this.OnScroll(this, args);
            }
        }
    }
}

