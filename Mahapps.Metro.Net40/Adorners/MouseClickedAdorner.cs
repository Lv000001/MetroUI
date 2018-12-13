using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MahApps.Metro.Adorners
{
    public class MouseClickedAdorner : Adorner
    {

        public event Action Completed;

        /// <summary>
        /// 用来绘制圆形
        /// </summary>
        private Grid grid = null;

        /// <summary>
        /// 圆形
        /// </summary>
        private Ellipse ellipse = null;

        /// <summary>
        /// 可视化树的存储
        /// </summary>
        private VisualCollection visCollec;

        public MouseClickedAdorner(UIElement adornedElement) : base(adornedElement)
        {
            IsHitTestVisible = false;
        }


        public MouseClickedAdorner(UIElement adornedElement, System.Windows.Input.MouseButtonEventArgs args) : this(adornedElement)
        {
            FrameworkElement element = args.Source as FrameworkElement;
            Point pt = Mouse.GetPosition(element);//WPF方法

            visCollec = new VisualCollection(this);
            grid = new Grid
            {
                Background = Brushes.Transparent,
                Height = element.ActualHeight,
                Width = element.Width,
                ClipToBounds = true
            };

            ellipse = new Ellipse { Fill = new SolidColorBrush(Color.FromArgb(60, 255, 255, 255)), Width = 1, Height = 1 };
            ellipse.Margin = new Thickness(pt.X, pt.Y, element.ActualWidth - pt.X - 1, element.ActualHeight - pt.Y - 1);
            grid.Children.Add(ellipse);

            double radius = Math.Max(element.ActualWidth, element.ActualHeight);

            ScaleTransform sctr = new ScaleTransform();
            sctr.ScaleY = 1;
            sctr.ScaleX = 1;
            TransformGroup trfg = new TransformGroup();
            trfg.Children.Add(sctr);
            ellipse.RenderTransformOrigin = new Point(0.5, 0.5);
            ellipse.RenderTransform = trfg;

            ellipse.Loaded += (sender, e) =>
            {
                Storyboard story = new Storyboard();
                DoubleAnimation animationWidth = new DoubleAnimation(2 * radius, new Duration(TimeSpan.FromMilliseconds(300)));
                DoubleAnimation animationHeight = new DoubleAnimation(2 * radius, new Duration(TimeSpan.FromMilliseconds(300)));

                animationWidth.EasingFunction = new CircleEase()
                {
                    EasingMode = EasingMode.EaseInOut,
                };

                animationHeight.EasingFunction = new CircleEase()
                {
                    EasingMode = EasingMode.EaseInOut,
                };
                animationHeight.Completed += AnimationHeight_Completed;
                story.Children.Add(animationWidth);
                story.Children.Add(animationHeight);
                story.FillBehavior = FillBehavior.HoldEnd;
                Storyboard.SetTarget(animationWidth, ellipse);
                Storyboard.SetTarget(animationHeight, ellipse);
                Storyboard.SetTargetProperty(animationWidth, new PropertyPath("(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleX)"));
                Storyboard.SetTargetProperty(animationHeight, new PropertyPath("(UIElement.RenderTransform).(TransformGroup.Children)[0].(ScaleTransform.ScaleY)"));

                story.Begin();

            };

            //添加到可视化树中
            visCollec.Add(grid);
        }

        private void AnimationHeight_Completed(object sender, EventArgs e)
        {
            Completed?.Invoke();
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            grid.Arrange(new Rect(new Point(0, 0), finalSize));
            return finalSize;
        }

        protected override Visual GetVisualChild(int index)
        {
            return visCollec[index];
        }

        protected override int VisualChildrenCount
        {
            get
            {
                if (visCollec == null)
                {
                    return 0;
                }
                return visCollec.Count;
            }
        }


    }
}
