using System.Drawing;
using System.Drawing.Drawing2D;

namespace WeekPlanner
{
    internal class WeekPlannerColorTable
    {
        static WeekPlannerColorTable()
        {
            GridBackgroundColor = Color.FromArgb(208, 221, 242);
            BorderColor = Color.FromArgb(83, 98, 128);
            HeaderBackgroundColor = Color.FromArgb(237, 244, 255);
            HeaderFillColor = Color.FromArgb(168, 192, 234);
            HeaderFillLeftMarginColor = Color.FromArgb(156, 221, 252);
            ItemBackgroundColor = Color.White;
            LeftMarginColor = Color.FromArgb(220, 231, 245);
        }

        public static Color GridBackgroundColor
        {
            get;
            set;
        }

        public static Color BorderColor
        {
            get;
            set;
        }

        public static Color HeaderBackgroundColor
        {
            get;
            set;
        }

        public static Color HeaderFillColor
        {
            get;
            set;
        }

        public static Color HeaderFillLeftMarginColor
        {
            get;
            set;
        }

        public static Color LeftMarginColor
        {
            get;
            set;
        }

        public static Color ItemBackgroundColor
        {
            get;
            set;
        }

        public static LinearGradientBrush ItemGradientBackBrush(Rectangle bounds, Color backColor)
        {
            LinearGradientBrush linearGradientBrush = new LinearGradientBrush(bounds, Color.White, backColor, LinearGradientMode.Vertical);
            if (linearGradientBrush != null)
            {
                Blend blend = new Blend();

                blend.Factors = new float[] { 1.0f, 0.9f, 0.8f, 0.7f, 0.6f, 0.5f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f };
                blend.Positions = new float[] { 0, 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f, 0.9f, 1.0f };

                linearGradientBrush.Blend = blend;
            }
            return linearGradientBrush;
        }


        public static LinearGradientBrush HeaderGradientBackBrush(Rectangle bounds, Color backColor)
        {
            var linearGradientBrush = new LinearGradientBrush(bounds, Color.White, backColor, LinearGradientMode.Vertical);
            if (linearGradientBrush != null)
            {
                Blend blend = new Blend();
                blend.Positions = new float[] { 0.0F, 0.2F, 0.3F, 0.4F, 0.8F, 1.0F };
                blend.Factors = new float[] { 0.3F, 0.4F, 0.5F, 1.0F, 0.8F, 0.7F };
                linearGradientBrush.Blend = blend;
            }
            return linearGradientBrush;
        }
    }
}
