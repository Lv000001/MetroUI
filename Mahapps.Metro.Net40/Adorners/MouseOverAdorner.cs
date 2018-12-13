using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace MahApps.Metro.Adorners
{
    public class MouseOverAdorner : Adorner
    {
        public MouseOverAdorner(UIElement adornedElement) : base(adornedElement)
        {
            IsHitTestVisible = false;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            Rect adornedElementRect = new Rect(this.AdornedElement.RenderSize);
            drawingContext.DrawRectangle(new SolidColorBrush(Color.FromArgb(30, 0, 0, 0)), null, adornedElementRect);
        }
    }
}
