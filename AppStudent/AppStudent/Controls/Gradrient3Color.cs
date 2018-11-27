using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppStudent.MyControls
{
    public class Gradrient3Color : Frame
    {
        public Gradrient3Color()
        {
            this.Padding = 0;
            this.HorizontalOptions = LayoutOptions.CenterAndExpand;
            this.VerticalOptions = LayoutOptions.CenterAndExpand;
        }
        protected override void OnChildAdded(Element child)
        {
            base.OnChildAdded(child);
            var control = child as View;
            control.BackgroundColor = Color.Transparent;
        }
        public Color StartColor { get; set; }
        public Color CenterColor { get; set; }
        public Color EndColor { get; set; }
    }
}
