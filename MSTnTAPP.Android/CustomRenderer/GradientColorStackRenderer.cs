using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MSTnTAPP.CustomRenderer;
using MSTnTAPP.Droid;
using MSTnTAPP.Droid.CustomRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(GradientLayoutRenderer), typeof(GradientColorStackRenderer))]

namespace MSTnTAPP.Droid.CustomRenderer
{
    [Obsolete]
    public class GradientColorStackRenderer : VisualElementRenderer < StackLayout >
    {
        private Color[] Colors { get; set; }

        private GradientColorStackMode Mode { get; set; }

        public GradientColorStackRenderer(Context ctx) : base(ctx)
        { }


        protected override void DispatchDraw(global::Android.Graphics.Canvas canvas)
        {

            Android.Graphics.LinearGradient gradient;

            int[] colors = new int[Colors.Length];

            for (int i = 0, l = Colors.Length; i < l; i++)
            {
                colors[i] = Colors[i].ToAndroid().ToArgb();
            }

            switch (Mode)
            {
                default:
                case GradientColorStackMode.ToRight:
                    gradient = new Android.Graphics.LinearGradient(0, 0, Width, 0, colors, null, Android.Graphics.Shader.TileMode.Mirror);
                    break;
                case GradientColorStackMode.ToLeft:
                    gradient = new Android.Graphics.LinearGradient(Width, 0, 0, 0, colors, null, Android.Graphics.Shader.TileMode.Mirror);
                    break;
                case GradientColorStackMode.ToTop:
                    gradient = new Android.Graphics.LinearGradient(0, Height, 0, 0, colors, null, Android.Graphics.Shader.TileMode.Clamp);
                    break;
                case GradientColorStackMode.ToBottom:
                    gradient = new Android.Graphics.LinearGradient(0, 0, 0, 22*Height/30, colors, null, Android.Graphics.Shader.TileMode.Clamp);
                    break;
                case GradientColorStackMode.ToTopLeft:
                    gradient = new Android.Graphics.LinearGradient(Width, Height, 0, 0, colors, null, Android.Graphics.Shader.TileMode.Mirror);
                    break;
                case GradientColorStackMode.ToTopRight:
                    gradient = new Android.Graphics.LinearGradient(0, Height, Width, 0, colors, null, Android.Graphics.Shader.TileMode.Mirror);
                    break;
                case GradientColorStackMode.ToBottomLeft:
                    gradient = new Android.Graphics.LinearGradient(Width, 0, 0, Height, colors, null, Android.Graphics.Shader.TileMode.Mirror);
                    break;
                case GradientColorStackMode.ToBottomRight:
                    gradient = new Android.Graphics.LinearGradient(0, 0, Width, Height, colors, null, Android.Graphics.Shader.TileMode.Mirror);
                    break;
            }

            var paint = new Android.Graphics.Paint()
            {
                Dither = true,
            };

            paint.SetShader(gradient);
            canvas.DrawPaint(paint);

            base.DispatchDraw(canvas);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<StackLayout> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
                return;

            try
            {
                if (e.NewElement is GradientLayoutRenderer layout)
                {
                    Colors = layout.Colors;
                    Mode = layout.Mode;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"ERROR:", ex.Message);
            }
        }

       
    }
}