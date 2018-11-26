using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Text;
using Android.Views;
using Android.Widget;
using Android;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Xamarin.Forms.Color;
using AppStudent.MyControls;
using AppStudent.Droid;

[assembly: ExportRenderer(typeof(MyEntry), typeof(MyEntryRenderer))]


namespace AppStudent.Droid
{
    public class MyEntryRenderer : EntryRenderer
    {
        public MyEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            var element = (MyEntry)Element;
            if (Control == null || element == null || e.OldElement != null) return;
            if(element.LineColor == Color.Transparent)
            {
                GradientDrawable gd = new GradientDrawable();
                gd.SetColor(global::Android.Graphics.Color.Transparent);
#pragma warning disable CS0618 // Type or member is obsolete
                Control.SetBackgroundDrawable(gd);
#pragma warning restore CS0618 // Type or member is obsolete
                              //this.Control.SetRawInputType(InputTypes.TextFlagNoSuggestions);
                              //Control.SetHintTextColor(ColorStateList.ValueOf(element.TextColor.ToAndroid()));
            }
            else
            {
                var lineColor = element.LineColor.ToAndroid();
                Control.Background.SetColorFilter(lineColor, PorterDuff.Mode.SrcAtop);
            }
            
        }
    }
}