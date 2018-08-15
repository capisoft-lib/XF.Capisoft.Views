using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XF.Capisoft.Views;
using XF.Capisoft.Views.iOS.Renderers;

[assembly: ExportRenderer(typeof(ScrollListView), typeof(ScrollListViewRenderer))]
namespace XF.Capisoft.Views.iOS.Renderers
{
    public class ScrollListViewRenderer : ListViewRenderer
    {
        private IDisposable _offsetObserver;

        protected override void OnElementChanged(ElementChangedEventArgs<ListView> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement is ScrollListView)
            {
                _offsetObserver = Control.AddObserver("contentOffset",
                             Foundation.NSKeyValueObservingOptions.New, HandleAction);
                Control.Bounces = false;
            }
        }

        private double _prevYOffset;

        private void HandleAction(Foundation.NSObservedChange obj)
        {
            var effectiveY = Math.Max(Control.ContentOffset.Y, 0);
            if (!CloseTo(effectiveY, _prevYOffset) && Element is ScrollListView)
            {
                var direction = effectiveY > _prevYOffset ? ScrollListView.ScrollDirection.UP : ScrollListView.ScrollDirection.DOWN;
                var myList = Element as ScrollListView;
                myList.LastScrollDirection = direction;
                myList.AtStartOfList = CloseTo(effectiveY, 0);
                _prevYOffset = effectiveY;
            }
        }

        private bool CloseTo(double d1, double d2)
        {
            double Lambda = 10;
            return (Math.Abs(d1 - d2) < Lambda);
        }
    }
}
