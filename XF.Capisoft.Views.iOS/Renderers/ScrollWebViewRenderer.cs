using System;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XF.Capisoft.Views;
using XF.Capisoft.Views.iOS.Renderers;

[assembly: ExportRenderer(typeof(ScrollWebView), typeof(ScrollWebViewRenderer))]
namespace XF.Capisoft.Views.iOS.Renderers
{
    public class ScrollWebViewRenderer : WebViewRenderer, IUIScrollViewDelegate
    {

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);
            Thickness padding = (e.NewElement as ScrollWebView).Padding;
            (NativeView as UIWebView).ScrollView.ContentInset = new UIEdgeInsets((nfloat)padding.Top, (nfloat)padding.Left, (nfloat)padding.Bottom, (nfloat)padding.Right);
            (NativeView as UIWebView).AllowsInlineMediaPlayback = true;
            (NativeView as UIWebView).MediaPlaybackRequiresUserAction = false;
        }

        [Export("scrollViewDidScroll:")]
        public override void Scrolled(UIScrollView scrollView)
        {
            (this.Element as ScrollWebView).Scrolled(new Xamarin.Forms.ScrolledEventArgs(scrollView.ContentOffset.X, scrollView.ContentOffset.Y));
        }
    }
}
