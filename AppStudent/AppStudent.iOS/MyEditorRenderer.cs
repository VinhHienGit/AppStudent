using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppStudent.iOS;
using AppStudent.MyControls;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(MyEditor), typeof(MyEditorRenderer))]
namespace AppStudent.iOS
{
    public class MyEditorRenderer: EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            if(Control != null)
            {
                //some things
            }
        }
    }
}