using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MahApps.Metro.Controls
{
    public class ColorThumb : Thumb
    {
        static ColorThumb()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColorThumb),
                new FrameworkPropertyMetadata(typeof(ColorThumb)));
        }

        public static readonly DependencyProperty ThumbColorProperty =
        DependencyProperty.Register("ThumbColor", typeof(Color), typeof(ColorThumb),
            new FrameworkPropertyMetadata(Colors.Transparent));

        public static readonly DependencyProperty PointerOutlineThicknessProperty =
        DependencyProperty.Register("PointerOutlineThickness", typeof(double), typeof(ColorThumb),
            new FrameworkPropertyMetadata(1.0));

        public static readonly DependencyProperty PointerOutlineBrushProperty =
        DependencyProperty.Register("PointerOutlineBrush", typeof(Brush), typeof(ColorThumb),
            new FrameworkPropertyMetadata(null));

        /// <summary>
        /// The color of the Thumb.
        /// </summary>
        public Color ThumbColor
        {
            get { return (Color)GetValue(ThumbColorProperty); }
            set { SetValue(ThumbColorProperty, value); }
        }

        public double PointerOutlineThickness
        {
            get { return (double)GetValue(PointerOutlineThicknessProperty); }
            set { SetValue(PointerOutlineThicknessProperty, value); }
        }

        public Brush PointerOutlineBrush
        {
            get { return (Brush)GetValue(PointerOutlineBrushProperty); }
            set { SetValue(PointerOutlineBrushProperty, value); }
        }
    }
}
