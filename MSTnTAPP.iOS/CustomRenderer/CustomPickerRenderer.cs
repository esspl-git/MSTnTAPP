using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using MSTnTAPP.CustomControl;
using MSTnTAPP.iOS.CustomRenderer;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
namespace MSTnTAPP.iOS.CustomRenderer
{
    public class CustomPickerRenderer : PickerRenderer, IUIPickerViewDelegate
    {
        IElementController ElementController => Element as IElementController;

        public CustomPickerRenderer()
        {

        }

        // To be uncemmented after testing is done in iOS

        /*[Export("pickerView:viewForRow:forComponent:reusingView:")]
        public UIView GetView(UIPickerView pickerView, nint row, nint component, UIView view)
        {

            UILabel label = new UILabel
            {
                //here you can set the style of item!!!

                TextColor = UIColor.Blue,

                Text = Element.Items[(int)row].ToString(),

                TextAlignment = UITextAlignment.Center,

            };
            return label;
        }*/

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            var element = (CustomPicker)this.Element;

            if (this.Control != null && this.Element != null && !string.IsNullOrEmpty(element.Image))
            {
                var downarrow = UIImage.FromBundle(element.Image);
                Control.RightViewMode = UITextFieldViewMode.Always;
                Control.RightView = new UIImageView(downarrow);
                //UIPickerView pickerView = (UIPickerView)Control.InputView;
                //pickerView.WeakDelegate = this;
            }
        }
    }
}