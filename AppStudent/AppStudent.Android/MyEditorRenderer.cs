using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AppStudent.Droid;
using AppStudent.MyControls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Xamarin.Forms.Color;

[assembly: ExportRenderer(typeof(MyEditor), typeof(MyEditorRenderer))]
namespace AppStudent.Droid
{
    public class MyEditorRenderer : EditorRenderer
    {
        public MyEditorRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            var element = (MyEditor)Element;
            if (Control == null || element == null || e.OldElement != null) return;
            if (element.LineColor == Color.Transparent)
            {
                GradientDrawable gd = new GradientDrawable();
                gd.SetColor(global::Android.Graphics.Color.Transparent);
#pragma warning disable CS0618 // Type or member is obsolete
                Control.SetBackgroundDrawable(gd);
#pragma warning restore CS0618 // Type or member is obsolete
            }
            else
            {
                var lineColor = element.LineColor.ToAndroid();
                Control.Background.SetColorFilter(lineColor, PorterDuff.Mode.SrcAtop);
            }
            Control.Background.SetBounds(10, 5, 8, 20);
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            
        }
    }
}