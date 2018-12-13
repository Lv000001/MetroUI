using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace MahApps.Metro.Adorners
{
    public class AdornerHelper
    {
        public static DependencyProperty GetMouseAdornerLayer(DependencyObject obj)
        {
            return (DependencyProperty)obj.GetValue(MouseAdornerLayerProperty);
        }

        public static void SetMouseAdornerLayer(DependencyObject obj, DependencyProperty value)
        {
            obj.SetValue(MouseAdornerLayerProperty, value);
        }

        /// <summary>  
        /// 注册附加属性  
        /// 用于设置控件的AdornerLayer  
        /// </summary>  
        public static readonly DependencyProperty MouseAdornerLayerProperty =
            DependencyProperty.RegisterAttached("MouseAdornerLayer", typeof(DependencyObject), typeof(AdornerHelper), new UIPropertyMetadata(null, (o, n) =>
                {
                    if (o is Control && n.NewValue is Visual)
                    {
                        //获得注册附加属性的控件  
                        Control c = o as Control;
                        c.Loaded += (s1, e1) =>
                        {
                            AdornerLayer layer = AdornerLayer.GetAdornerLayer((Visual)n.NewValue);

                            //为控件添加获得焦点和失去焦点事件  
                            if (layer != null)
                            {
                                bool isCompleted = true;
                                c.PreviewMouseLeftButtonDown += (sender, args) =>
                                 {
                                     Point pt = System.Windows.Input.Mouse.GetPosition(sender as FrameworkElement);
                                     if (sender is TabItem)
                                     {
                                         Rect rect = new Rect(new Size(((TabItem)sender).ActualWidth, ((TabItem)sender).ActualHeight));
                                         if (!rect.Contains(pt))
                                         {
                                             return;
                                         }
                                     }
                                     //添加自定义装饰器  
                                     MouseClickedAdorner adorner = new MouseClickedAdorner(c, args);
                                     adorner.Completed += () =>
                                     {
                                         isCompleted = true;
                                         //取消控件的装饰器  
                                         Adorner[] ads = layer.GetAdorners(c);
                                         if (ads != null)
                                         {
                                             for (int i = ads.Length - 1; i >= 0; i--)
                                             {
                                                 layer.Remove(ads[i]);
                                             }
                                         }
                                     };
                                     isCompleted = false;
                                     layer.Add(adorner);
                                 };

                                c.MouseLeave += (s, e) =>
                                {
                                    if (isCompleted)
                                    { //取消控件的装饰器  
                                        Adorner[] ads = layer.GetAdorners(c);
                                        if (ads != null)
                                        {
                                            for (int i = ads.Length - 1; i >= 0; i--)
                                            {
                                                layer.Remove(ads[i]);
                                            }
                                        }
                                    }

                                };

                                c.MouseEnter += (s, e) =>
                                {
                                    Point pt = System.Windows.Input.Mouse.GetPosition(s as FrameworkElement);
                                    if (s is TabItem)
                                    {
                                        Rect rect = new Rect(new Size(((TabItem)s).ActualWidth, ((TabItem)s).ActualHeight));
                                        if (!rect.Contains(pt))
                                        {
                                            return;
                                        }
                                    }

                                    //添加自定义装饰器  
                                    layer.Add(new MouseOverAdorner(c));
                                };
                            }
                        };
                    }

                }));


    }
}
