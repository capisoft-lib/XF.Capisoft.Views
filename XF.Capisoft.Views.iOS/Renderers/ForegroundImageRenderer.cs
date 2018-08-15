using System;
using System.ComponentModel;
using System.Diagnostics;
using CoreGraphics;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XF.Capisoft.Views;
using XF.Capisoft.Views.iOS.Renderers;

[assembly: ExportRendererAttribute(typeof(ForegroundImage), typeof(ForegroundImageRenderer))]
namespace XF.Capisoft.Views.iOS.Renderers
{
    public class ForegroundImageRenderer : ViewRenderer<ForegroundImage, UIImageView>
    {
        private bool _isDisposed;

        public static void Init() { }

        protected override void Dispose(bool disposing)
        {
            if (_isDisposed)
            {
                return;
            }

            if (disposing && base.Control != null)
            {
                UIImage image = base.Control.Image;
                UIImage uIImage = image;
                if (image != null)
                {
                    uIImage.Dispose();
                    uIImage = null;
                }
            }

            _isDisposed = true;
            base.Dispose(disposing);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<ForegroundImage> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                UIImageView uIImageView = new UIImageView(CGRect.Empty)
                {
                    ContentMode = UIViewContentMode.ScaleAspectFit,
                    ClipsToBounds = true
                };
                SetNativeControl(uIImageView);
            }
            if (e.NewElement != null)
            {
                SetImage(e.OldElement);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == ForegroundImage.SourceProperty.PropertyName)
            {
                SetImage(null);
            }
            else if (e.PropertyName == ForegroundImage.ForegroundProperty.PropertyName)
            {
                SetImage(null);
            }
        }

        private void SetImage(ForegroundImage previous = null)
        {
            if (previous == null && !String.IsNullOrEmpty(Element.Source))
            {
                UIImage uiImage;
                try
                {
                    uiImage = new UIImage(Element.Source);
                }
                catch (Exception)
                {
                    uiImage = UIImage.FromBundle(Element.Source);
                }
                try
                {
                    uiImage = uiImage.ImageWithRenderingMode(UIImageRenderingMode.AlwaysTemplate);
                    Control.TintColor = Element.Foreground.ToUIColor();
                    Control.Image = uiImage;
                    if (!_isDisposed)
                    {
                        ((IVisualElementController)Element).NativeSizeChanged();
                    }
                }
                catch (Exception exc)
                {
                    Debug.WriteLine($"Unable to get Image : {exc.Message}");
                }
            }
        }
    }
}