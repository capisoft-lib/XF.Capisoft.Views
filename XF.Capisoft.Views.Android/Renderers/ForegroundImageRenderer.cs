using System;
using System.ComponentModel;
using Android.Content;
using Android.Graphics;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XF.Capisoft.Views;
using XF.Capisoft.Views.Android.Renderers;

[assembly: ExportRendererAttribute(typeof(ForegroundImage), typeof(ForegroundImageRenderer))]
namespace XF.Capisoft.Views.Android.Renderers
{
    public class ForegroundImageRenderer : ViewRenderer<ForegroundImage, ImageView>
    {
        private bool _isDisposed;

        public void Init() { }

        public ForegroundImageRenderer(Context context) : base(context)
        {
            base.AutoPackage = false;
        }

        public ForegroundImageRenderer()
        {
            base.AutoPackage = false;
        }

        protected override void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            }
            _isDisposed = true;
            base.Dispose(disposing);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<ForegroundImage> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                SetNativeControl(new ImageView(Context));
            }
            UpdateBitmap(e.OldElement);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == ForegroundImage.SourceProperty.PropertyName)
            {
                UpdateBitmap(null);
            }
            else if (e.PropertyName == ForegroundImage.ForegroundProperty.PropertyName)
            {
                UpdateBitmap(null);
            }
        }

        private void UpdateBitmap(ForegroundImage previous = null)
        {
            if (!_isDisposed)
            {
                try
                {
                    var d = Resources.GetDrawable(Element.Source).Mutate();
                    d.SetColorFilter(new LightingColorFilter(Element.Foreground.ToAndroid(), Element.Foreground.ToAndroid()));
                    d.Alpha = Element.Foreground.ToAndroid().A;
                    Control.SetImageDrawable(d);
                    ((IVisualElementController)Element).NativeSizeChanged();
                }
                catch (Exception)
                {
                    Console.WriteLine("Unable to find Resource");
                }
            }
        }
    }
}