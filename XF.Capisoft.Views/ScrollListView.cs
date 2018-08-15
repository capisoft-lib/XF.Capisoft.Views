using System;
using Xamarin.Forms;

namespace XF.Capisoft.Views
{
    public class ScrollListView : ListView
    {
        public enum ScrollDirection
        {
            UP,
            NONE,
            DOWN
        }

        public static readonly BindableProperty
            LastScrollDirectionProperty =
                BindableProperty.Create(nameof(LastScrollDirection),
                                        typeof(ScrollDirection), typeof(ScrollListView), ScrollDirection.NONE);
        public static readonly BindableProperty
            AtStartOfListProperty =
                BindableProperty.Create(nameof(AtStartOfList),
                                        typeof(bool), typeof(ScrollListView), false);

        public ScrollDirection LastScrollDirection
        {
            get { return (ScrollDirection)GetValue(LastScrollDirectionProperty); }
            set
            {
                ScrollDirection direction = (ScrollDirection)GetValue(LastScrollDirectionProperty);
                if (direction != value)
                {
                    SetValue(LastScrollDirectionProperty, value);
                    OnScroll(value);
                }
            }
        }

        public bool AtStartOfList
        {
            get { return (bool)GetValue(AtStartOfListProperty); }
            set { SetValue(AtStartOfListProperty, value); }
        }

        public event ScrollDirectionHandler Scrolled;
        public delegate void ScrollDirectionHandler(ScrollListView listView, ScrollEventArgs e);

        public void Scroll(ScrollDirection direction)
        {
            OnScroll(direction);
        }

        public class ScrollEventArgs : EventArgs
        {
            public ScrollDirection ScrollDirection { get; set; }

            public ScrollEventArgs(ScrollDirection direction) : base()
            {
                ScrollDirection = direction;
            }
        }

        private void OnScroll(ScrollDirection direction)
        {
            if (Scrolled != null)
            {
                Scrolled(this, new ScrollEventArgs(direction));
            }
        }

        public ScrollListView() : base()
        {
        }
    }
}

