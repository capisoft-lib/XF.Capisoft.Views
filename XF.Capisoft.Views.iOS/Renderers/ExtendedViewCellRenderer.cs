using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XF.Capisoft.Views;
using XF.Capisoft.Views.iOS.Renderers;

[assembly: ExportRenderer(typeof(ExtendedViewCell), typeof(ExtendedViewCellRenderer))]
namespace XF.Capisoft.Views.iOS.Renderers
{
    public class ExtendedViewCellRenderer : ViewCellRenderer
    {
        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv)
        {
            var returnCell = base.GetCell(item, reusableCell, tv);
            if (returnCell != null)
            {
                if ((item as ExtendedViewCell).IsHighlightDisabled)
                {
                    returnCell.SelectionStyle = UITableViewCellSelectionStyle.None;
                }
                else
                {
                    returnCell.SelectionStyle = UITableViewCellSelectionStyle.Default;
                }
            }
            return returnCell;
        }
    }
}
