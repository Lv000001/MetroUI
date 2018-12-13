using MahApps.Metro.Controls.Helper;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MahApps.Metro.Controls.Dialogs
{

    public partial class ColorSelectorDialog : MetroWindow
    {
        #region Properties

        private Color selectedColor = Colors.White;
        /// <summary>
        /// The selected color.
        /// </summary>
        public Color SelectedColor
        {
            get { return selectedColor; }
            set { selectedColor = value; }
        }

        #endregion

        #region Private Variables

        private readonly TranslateTransform _markerTransform = new TranslateTransform();
        private Point? _colorPosition;
        private bool _isUpdating = false;

        #endregion

        #region Constructor


        /// <summary>
        /// Default constructor.
        /// </summary>
        public ColorSelectorDialog(bool showAlpha = true)
        {
            InitializeComponent();

            UpdateMarkerPosition(SelectedColor);

            ColorMarker.RenderTransform = _markerTransform;
            ColorMarker.RenderTransformOrigin = new Point(0.5, 0.5);

            if (!showAlpha)
            {
                AlphaIntegerUpDown.Visibility = Visibility.Collapsed;
                AlphaLabel.Visibility = Visibility.Collapsed;
            }

            InitialColor.Background = CurrentColor.Background = LastColor.Background = new SolidColorBrush(SelectedColor);
        }


        /// <summary>
        /// Default constructor.
        /// </summary>
        public ColorSelectorDialog(Color selectedColor, bool showAlpha = true)
        {
             InitializeComponent();
            SelectedColor = selectedColor;
            UpdateMarkerPosition(SelectedColor);

            ColorMarker.RenderTransform = _markerTransform;
            ColorMarker.RenderTransformOrigin = new Point(0.5, 0.5);

            if (!showAlpha)
            {
                AlphaIntegerUpDown.Visibility = Visibility.Collapsed;
                AlphaLabel.Visibility = Visibility.Collapsed;
            }

            InitialColor.Background = CurrentColor.Background = LastColor.Background = new SolidColorBrush(SelectedColor);
        }
        #endregion


        #region Events

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _isUpdating = true;

            AlphaIntegerUpDown.Value = SelectedColor.A;
            RedIntegerUpDown.Value = SelectedColor.R;
            GreenIntegerUpDown.Value = SelectedColor.G;
            BlueIntegerUpDown.Value = SelectedColor.B;

            HexadecimalTextBox.Text = SelectedColor.ToString();

            _isUpdating = false;
        }

        private void ColorSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_colorPosition != null)
            {
                DetermineColor((Point)_colorPosition);
            }
        }

        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(ColorDetail);
            var p = e.GetPosition(ColorDetail);
            UpdateMarkerPosition(p);
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var p = e.GetPosition(ColorDetail);
                var withinBoundaries = new Point(
                    Math.Max(0, Math.Min(p.X, ColorDetail.ActualWidth)),
                    Math.Max(0, Math.Min(p.Y, ColorDetail.ActualHeight)));
                UpdateMarkerPosition(withinBoundaries);
                Mouse.Synchronize();
            }
        }

        private void ColorDetailSizeChanged(object sender, SizeChangedEventArgs args)
        {
            if (args.PreviousSize != Size.Empty && args.PreviousSize.Width != 0 && args.PreviousSize.Height != 0)
            {
                var widthDifference = args.NewSize.Width / args.PreviousSize.Width;
                var heightDifference = args.NewSize.Height / args.PreviousSize.Height;
                _markerTransform.X = _markerTransform.X * widthDifference;
                _markerTransform.Y = _markerTransform.Y * heightDifference;
            }
            else if (_colorPosition != null)
            {
                _markerTransform.X = ((Point)_colorPosition).X * args.NewSize.Width;
                _markerTransform.Y = ((Point)_colorPosition).Y * args.NewSize.Height;
            }
        }

        private void ColorDetail_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(null); // Release
            LastColor.Background = CurrentColor.Background;
        }

        private void InitialColor_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SelectedColor = ((SolidColorBrush)InitialColor.Background).Color;
            CurrentColor.Background = LastColor.Background = InitialColor.Background;

            UpdateMarkerPosition(SelectedColor);

            #region Update TextBoxes

            _isUpdating = true;

            AlphaIntegerUpDown.Value = SelectedColor.A;
            RedIntegerUpDown.Value = SelectedColor.R;
            GreenIntegerUpDown.Value = SelectedColor.G;
            BlueIntegerUpDown.Value = SelectedColor.B;

            HexadecimalTextBox.Text = SelectedColor.ToString();

            _isUpdating = false;

            #endregion
        }

        private void ColorSlider_OnAfterSelecting()
        {
            LastColor.Background = CurrentColor.Background;
        }

        #region Text Changed

        private void ArgbText_ValueChanged(object sender, RoutedEventArgs e)
        {
            if (AlphaIntegerUpDown == null) return;
            if (_isUpdating) return;

            SelectedColor = Color.FromArgb(
                            (byte)AlphaIntegerUpDown.Value,
                            (byte)RedIntegerUpDown.Value,
                            (byte)GreenIntegerUpDown.Value,
                            (byte)BlueIntegerUpDown.Value);

            _isUpdating = true;

            HexadecimalTextBox.Text = SelectedColor.ToString();

            _isUpdating = false;

            UpdateMarkerPosition(SelectedColor);
        }

        private void HexadecimalText_ValueChanged(object sender, RoutedEventArgs e)
        {
            if (HexadecimalTextBox == null) return;
            if (HexadecimalTextBox.Text == null) return;
            if (_isUpdating) return;

            var converted = ColorConverter.ConvertFromString(HexadecimalTextBox.Text.PadRight(9, '0'));

            if (converted == null) return;

            SelectedColor = (Color)converted;

            UpdateMarkerPosition(SelectedColor);

            _isUpdating = true;

            AlphaIntegerUpDown.Value = SelectedColor.A;
            RedIntegerUpDown.Value = SelectedColor.R;
            GreenIntegerUpDown.Value = SelectedColor.G;
            BlueIntegerUpDown.Value = SelectedColor.B;

            _isUpdating = false;
        }

        #endregion

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        #endregion

        #region Methods

        private void UpdateMarkerPosition(Point p)
        {
            _markerTransform.X = p.X;
            _markerTransform.Y = p.Y;
            p.X = p.X / ColorDetail.ActualWidth;
            p.Y = p.Y / ColorDetail.ActualHeight;
            _colorPosition = p;

            DetermineColor(p);
        }

        private void UpdateMarkerPosition(Color theColor)
        {
            _colorPosition = null;

            var hsv = ColorExtensions.ConvertRgbToHsv(theColor.R, theColor.G, theColor.B);

            CurrentColor.Background = LastColor.Background = new SolidColorBrush(theColor);

            ColorSlider.Value = hsv.H;

            var p = new Point(hsv.S, 1 - hsv.V);

            _colorPosition = p;
            p.X = p.X * ColorDetail.ActualWidth;
            p.Y = p.Y * ColorDetail.ActualHeight;
            _markerTransform.X = p.X;
            _markerTransform.Y = p.Y;
        }

        private void DetermineColor(Point p)
        {
            var hsv = new HsvColor(360 - ColorSlider.Value, 1, 1)
            {
                S = p.X,
                V = 1 - p.Y
            };

            SelectedColor = ColorExtensions.ConvertHsvToRgb(hsv.H, hsv.S, hsv.V, SelectedColor.A);

            CurrentColor.Background = new SolidColorBrush(SelectedColor);

            #region Update TextBoxes

            _isUpdating = true;

            AlphaIntegerUpDown.Value = SelectedColor.A;
            RedIntegerUpDown.Value = SelectedColor.R;
            GreenIntegerUpDown.Value = SelectedColor.G;
            BlueIntegerUpDown.Value = SelectedColor.B;

            HexadecimalTextBox.Text = SelectedColor.ToString();

            _isUpdating = false;

            #endregion
        }

        #endregion


        private void ArgbText_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            if (AlphaIntegerUpDown == null) return;
            if (AlphaIntegerUpDown.Value == null || RedIntegerUpDown.Value == null || GreenIntegerUpDown.Value == null || BlueIntegerUpDown.Value == null)
            {
                return;
            }
            if (_isUpdating) return;

            SelectedColor = Color.FromArgb(
                            (byte)AlphaIntegerUpDown.Value,
                            (byte)RedIntegerUpDown.Value,
                            (byte)GreenIntegerUpDown.Value,
                            (byte)BlueIntegerUpDown.Value);

            _isUpdating = true;

            HexadecimalTextBox.Text = SelectedColor.ToString();

            _isUpdating = false;

            UpdateMarkerPosition(SelectedColor);
        }
    }
}
