using MahApps.Metro.Controls.Helper;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MahApps.Metro.Controls
{
    /// <summary>
    /// 按照步骤 1a 或 1b 操作，然后执行步骤 2 以在 XAML 文件中使用此自定义控件。
    ///
    /// 步骤 1a) 在当前项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根 
    /// 元素中: 
    ///
    ///     xmlns:MyNamespace="clr-namespace:MahApps.Metro.Controls"
    ///
    ///
    /// 步骤 1b) 在其他项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根 
    /// 元素中: 
    ///
    ///     xmlns:MyNamespace="clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro.Controls"
    ///
    /// 您还需要添加一个从 XAML 文件所在的项目到此项目的项目引用，
    /// 并重新生成以避免编译错误: 
    ///
    ///     在解决方案资源管理器中右击目标项目，然后依次单击
    ///     “添加引用”->“项目”->[浏览查找并选择此项目]
    ///
    ///
    /// 步骤 2)
    /// 继续操作并在 XAML 文件中使用控件。
    ///
    ///     <MyNamespace:SpectrumSlider/>
    ///
    /// </summary>
    public class SpectrumSlider : Slider
    {
        #region Private Fields

        private ColorThumb _colorThumb;
        private Rectangle _spectrumRectangle;
        private LinearGradientBrush _pickerBrush;

        public delegate void AfterSelectingEventHandler();

        public event AfterSelectingEventHandler AfterSelecting;

        #endregion

        static SpectrumSlider()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SpectrumSlider), new FrameworkPropertyMetadata(typeof(SpectrumSlider)));
        }

        #region Public Properties

        /// <summary>
        /// Current selected Color.
        /// </summary>
        public Color SelectedColor
        {
            get { return (Color)GetValue(SelectedColorProperty); }
            set { SetValue(SelectedColorProperty, value); }
        }

        #endregion

        #region Dependency Property Fields

        public static readonly DependencyProperty SelectedColorProperty = DependencyProperty.Register
            ("SelectedColor", typeof(Color), typeof(SpectrumSlider), new PropertyMetadata(Colors.Transparent));

        #endregion

        #region Public Methods

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _spectrumRectangle = GetTemplateChild("PART_SpectrumDisplay") as Rectangle;

            _colorThumb = GetTemplateChild("Thumb") as ColorThumb;
            if (_colorThumb != null)
            {

                _colorThumb.PreviewMouseLeftButtonUp += _colorThumb_MouseLeftButtonUp;
                _colorThumb.MouseEnter += _colorThumb_MouseEnter;
            }

            UpdateColorSpectrum();
            OnValueChanged(Double.NaN, Value);
        }

        void _colorThumb_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AfterSelecting?.Invoke();
        }

        private void _colorThumb_MouseEnter(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed && e.MouseDevice.Captured == null)
            {
                // https://social.msdn.microsoft.com/Forums/vstudio/en-US/5fa7cbc2-c99f-4b71-b46c-f156bdf0a75a/making-the-slider-slide-with-one-click-anywhere-on-the-slider?forum=wpf
                // the left button is pressed on mouse enter
                // but the mouse isn't captured, so the thumb
                // must have been moved under the mouse in response
                // to a click on the track thanks to IsMoveToPointEnabled.
                // Generate a MouseLeftButtonDown event.
                _colorThumb.RaiseEvent(
                    new MouseButtonEventArgs(e.MouseDevice, e.Timestamp, MouseButton.Left)
                    {
                        RoutedEvent = MouseLeftButtonDownEvent
                    });
            }
        }

        #endregion

        #region Protected Methods

        protected override void OnValueChanged(double oldValue, double newValue)
        {
            base.OnValueChanged(oldValue, newValue);
            var theColor = ColorExtensions.ConvertHsvToRgb(360 - newValue, 1, 1, 255);
            SetValue(SelectedColorProperty, theColor);
        }

        #endregion

        #region Private Methods

        private void UpdateColorSpectrum()
        {
            if (_spectrumRectangle != null)
                CreateSpectrum();
        }

        private void CreateSpectrum()
        {
            _pickerBrush = new LinearGradientBrush();
            _pickerBrush.StartPoint = new Point(0.5, 0);
            _pickerBrush.EndPoint = new Point(0.5, 1);
            _pickerBrush.ColorInterpolationMode = ColorInterpolationMode.SRgbLinearInterpolation;

            var colorsList = ColorExtensions.GenerateHsvSpectrum();
            var stopIncrement = (double)1 / colorsList.Count;

            int i;
            for (i = 0; i < colorsList.Count; i++)
                _pickerBrush.GradientStops.Add(new GradientStop(colorsList[i], i * stopIncrement));

            _pickerBrush.GradientStops[i - 1].Offset = 1.0;
            _spectrumRectangle.Fill = _pickerBrush;
        }

        #endregion
    }
}
