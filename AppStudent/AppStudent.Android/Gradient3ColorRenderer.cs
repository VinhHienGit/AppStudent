using System;
using Android.Content;
using AppStudent.MyControls;
using AppStudent.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;

[assembly: ExportRenderer(typeof(Gradrient3Color), typeof(Gradient3ColorRenderer))]

namespace AppStudent.Droid
{
    public class Gradient3ColorRenderer : VisualElementRenderer<Frame>
    {
        public Gradient3ColorRenderer(Context context) : base(context)
        {
        }

        //protected override void DispatchDraw(global::Android.Graphics.Canvas canvas)
        //{
        //    #region for Vertical Gradient
        //    //var gradient = new Android.Graphics.LinearGradient(0, 0, 0, Height,
        //    #endregion
        //    var gradient = new GradientDrawable(GradientDrawable.Orientation.TopBottom, new[] {
        //        Color.FromRgba(255, 255, 255, 255).ToAndroid().ToArgb(),
        //        Color.FromRgba(70, 70, 70, 50).ToAndroid().ToArgb() });
        //    base.SetBackgroundDrawable(gradient);
        //}
        
        protected override void OnElementChanged(ElementChangedEventArgs<Frame> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || Element == null)
            {
                return;
            }
            try
            {
                var btn = e.NewElement as Gradrient3Color;
                var gradient = new GradientDrawable(GradientDrawable.Orientation.LeftRight, new[] {
                    btn.StartColor.ToAndroid().ToArgb(),
                    btn.CenterColor.ToAndroid().ToArgb(),
                    btn.EndColor.ToAndroid().ToArgb()});
#pragma warning disable CS0618 // Type or member is obsolete
                base.SetBackgroundDrawable(gradient);
#pragma warning restore CS0618 // Type or member is obsolete
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(@"          ERROR: ", ex.Message);
            }
        }
            
    }
}