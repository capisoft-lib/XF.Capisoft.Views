using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XF.Capisoft.Views;
using XF.Capisoft.Views.iOS.Renderers;

[assembly: ExportRenderer(typeof(UnbouncedScrollView), typeof(UnbouncedScrollViewRenderer))]
namespace XF.Capisoft.Views.iOS.Renderers
{
    public class UnbouncedScrollViewRenderer : ScrollViewRenderer
    {
        public static void Init() { }

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            Bounces = false;
        }
    }
}
