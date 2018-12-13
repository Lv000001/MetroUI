using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace MahApps.Metro.Controls
{
    using System.ComponentModel;
    using System.Windows.Media;

    public static class ButtonHelper
    {
        [Obsolete(@"This property will be deleted in the next release. You should use ContentCharacterCasing attached property located in ControlsHelper.")]
        public static readonly DependencyProperty PreserveTextCaseProperty =
            DependencyProperty.RegisterAttached("PreserveTextCase", typeof(bool), typeof(ButtonHelper),
                                                new FrameworkPropertyMetadata(
                                                    false,
                                                    FrameworkPropertyMetadataOptions.Inherits | FrameworkPropertyMetadataOptions.AffectsMeasure,
                                                    (o, e) =>
                                                        {
                                                            var button = o as ButtonBase;
                                                            if (button != null && e.NewValue is bool)
                                                            {
                                                                ControlsHelper.SetContentCharacterCasing(button, (bool)e.NewValue ? CharacterCasing.Normal : CharacterCasing.Upper);
                                                            }
                                                        }));

        /// <summary>
        /// Overrides the text case behavior for certain buttons.
        /// When set to <c>true</c>, the text case will be preserved and won't be changed to upper or lower case.
        /// </summary>
        [Category(AppName.MahApps)]
        [AttachedPropertyBrowsableForType(typeof(ButtonBase))]
        [Obsolete(@"This property will be deleted in the next release. You should use ContentCharacterCasing attached property located in ControlsHelper.")]
        public static bool GetPreserveTextCase(UIElement element)
        {
            return (bool)element.GetValue(PreserveTextCaseProperty);
        }

        [Obsolete(@"This property will be deleted in the next release. You should use ContentCharacterCasing attached property located in ControlsHelper.")]
        public static void SetPreserveTextCase(UIElement element, bool value)
        {
            element.SetValue(PreserveTextCaseProperty, value);
        }

        /// <summary>
        /// DependencyProperty for <see cref="CornerRadius" /> property.
        /// </summary>
        [Obsolete(@"This property will be deleted in the next release. You should use CornerRadius attached property located in ControlsHelper.")]
        public static readonly DependencyProperty CornerRadiusProperty
            = DependencyProperty.RegisterAttached("CornerRadius", typeof(CornerRadius), typeof(ButtonHelper),
                                                  new FrameworkPropertyMetadata(
                                                      new CornerRadius(-1), // this is not valid, but this property is obsolete, set this to -1 to get the fired property changed callback
                                                      FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender,
                                                      (o, e) =>
                                                          {
                                                              var element = o as UIElement;
                                                              if (element != null && e.OldValue != e.NewValue && e.NewValue is CornerRadius)
                                                              {
                                                                  ControlsHelper.SetCornerRadius(element, (CornerRadius)e.NewValue);
                                                              }
                                                          }));

        /// <summary> 
        /// The CornerRadius property allows users to control the roundness of the button corners independently by 
        /// setting a radius value for each corner. Radius values that are too large are scaled so that they
        /// smoothly blend from corner to corner. (Can be used e.g. at MetroButton style)
        /// Description taken from original Microsoft description :-D
        /// </summary>
        [Category(AppName.MahApps)]
        [AttachedPropertyBrowsableForType(typeof(ButtonBase))]
        [AttachedPropertyBrowsableForType(typeof(ToggleButton))]
        [Obsolete(@"This property will be deleted in the next release. You should use CornerRadius attached property located in ControlsHelper.")]
        public static CornerRadius GetCornerRadius(UIElement element)
        {
            return (CornerRadius)element.GetValue(CornerRadiusProperty);
        }

        [Obsolete(@"This property will be deleted in the next release. You should use CornerRadius attached property located in ControlsHelper.")]
        public static void SetCornerRadius(UIElement element, CornerRadius value)
        {
            element.SetValue(CornerRadiusProperty, value);
        }


        [Category(AppName.MahApps)]
        [AttachedPropertyBrowsableForType(typeof(ButtonBase))]
        public static Brush GetMouseOverBackground(UIElement obj)
        {
            return (Brush)obj.GetValue(MouseOverBackgroundProperty);
        }

        public static void SetMouseOverBackground(UIElement obj, Brush value)
        {
            obj.SetValue(MouseOverBackgroundProperty, value);
        }

        /// <summary>
        /// 鼠标覆盖在按钮之上时按钮的背景色
        /// </summary>
        public static readonly DependencyProperty MouseOverBackgroundProperty =
            DependencyProperty.RegisterAttached("MouseOverBackground", typeof(Brush), typeof(ButtonHelper), new FrameworkPropertyMetadata(null));



        [Category(AppName.MahApps)]
        [AttachedPropertyBrowsableForType(typeof(ButtonBase))]
        public static Brush GetPressedBackground(UIElement obj)
        {
            return (Brush)obj.GetValue(PressedBackgroundProperty);
        }

        public static void SetPressedBackground(UIElement obj, Brush value)
        {
            obj.SetValue(PressedBackgroundProperty, value);
        }

        /// <summary>
        /// 鼠标按下时按钮的背景色
        /// </summary>
        public static readonly DependencyProperty PressedBackgroundProperty =
            DependencyProperty.RegisterAttached("PressedBackground", typeof(Brush), typeof(ButtonHelper), new FrameworkPropertyMetadata(null,
                 FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender,
                (o, e) =>
            {
                var element = o as UIElement;
                if (element != null && e.OldValue != e.NewValue && e.NewValue is CornerRadius)
                {
                    SetPressedBackground(element, (Brush)e.NewValue);
                }
            }));


        [Category(AppName.MahApps)]
        [AttachedPropertyBrowsableForType(typeof(ButtonBase))]
        public static Brush GetMouseOverBroderBrush(UIElement obj)
        {
            return (Brush)obj.GetValue(MouseOverBroderBrushProperty);
        }

        public static void SetMouseOverBroderBrush(UIElement obj, Brush value)
        {
            obj.SetValue(MouseOverBroderBrushProperty, value);
        }

        /// <summary>
        /// 鼠标覆盖在按钮之上时按钮的边框色
        /// </summary>
        public static readonly DependencyProperty MouseOverBroderBrushProperty =
            DependencyProperty.RegisterAttached("MouseOverBroderBrush", typeof(Brush), typeof(ButtonHelper), new FrameworkPropertyMetadata(null));


        [Category(AppName.MahApps)]
        [AttachedPropertyBrowsableForType(typeof(ButtonBase))]
        public static Brush GetPressedBorderBrush(UIElement obj)
        {
            return (Brush)obj.GetValue(PressedBorderBrushProperty);
        }

        public static void SetPressedBorderBrush(UIElement obj, Brush value)
        {
            obj.SetValue(PressedBorderBrushProperty, value);
        }

        /// <summary>
        /// 鼠标按下时按钮的边框色
        /// </summary>
        public static readonly DependencyProperty PressedBorderBrushProperty =
            DependencyProperty.RegisterAttached("PressedBorderBrush", typeof(Brush), typeof(ButtonHelper), new FrameworkPropertyMetadata(null));


        [Category(AppName.MahApps)]
        [AttachedPropertyBrowsableForType(typeof(ButtonBase))]
        public static Brush GetMouseOverForeground(UIElement obj)
        {
            return (Brush)obj.GetValue(MouseOverForegroundProperty);
        }

        public static void SetMouseOverForeground(UIElement obj, Brush value)
        {
            obj.SetValue(MouseOverForegroundProperty, value);
        }

        /// <summary>
        ///  鼠标覆盖在按钮之上时按钮的前景色
        /// </summary>
        public static readonly DependencyProperty MouseOverForegroundProperty =
            DependencyProperty.RegisterAttached("MouseOverForeground", typeof(Brush), typeof(ButtonHelper), new FrameworkPropertyMetadata(null));


    }
}
