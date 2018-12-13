namespace MahApps.Metro.Controls.Helper
{
    /// <summary>
    /// Describes a color in terms of Hue, Saturation, and Value (brightness)
    /// </summary>
    struct HsvColor
    {
        public double H { set; get; }
        public double S { set; get; }
        public double V { set; get; }

        public HsvColor(double h, double s, double v)
        {
            H = h;
            S = s;
            V = v;
        }
    }
}