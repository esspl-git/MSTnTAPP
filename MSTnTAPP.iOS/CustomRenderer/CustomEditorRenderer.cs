using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using CoreGraphics;
using Foundation;
using MSTnT.iOS.CustomRenderer;
using MSTnTAPP.CustomControl;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEditor), typeof(CustomEditorRenderer))]
namespace MSTnT.iOS.CustomRenderer
{
    class CustomEditorRenderer : EditorRenderer
    {
        UILabel _placeholderLabel;
        double previousHeight = -1;
        int prevLines = 0;
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Editor> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                if (_placeholderLabel == null)
                {
                    CreatePlaceholder();
                }

            }

            if (e.NewElement != null)
            {
                var customControl = (CustomEditor)e.NewElement;

                if (customControl.IsExpandable)
                    Control.ScrollEnabled = false;
                else
                    Control.ScrollEnabled = true;

                if (customControl.HasRoundedCorner)
                    Control.Layer.CornerRadius = 5;
                else
                    Control.Layer.CornerRadius = 0;

                Control.InputAccessoryView = new UIView(CGRect.Empty);
                Control.ReloadInputViews();

            }

            if (e.OldElement != null)
            {

            }
        }



        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            var customControl = (CustomEditor)Element;

            if (e.PropertyName == Editor.TextProperty.PropertyName)
            {
                if (customControl.IsExpandable)
                {
                    CGSize size = Control.Text.StringSize(Control.Font, Control.Frame.Size, UILineBreakMode.WordWrap);

                    int numLines = (int)(size.Height / Control.Font.LineHeight);

                    if (prevLines > numLines)
                    {
                        customControl.HeightRequest = -1;

                    }
                    else if (string.IsNullOrEmpty(Control.Text))
                    {
                        customControl.HeightRequest = -1;
                    }

                    prevLines = numLines;
                }

                _placeholderLabel.Hidden = !string.IsNullOrEmpty(Control.Text);

            }
            else if (CustomEditor.PlaceholderProperty.PropertyName == e.PropertyName)
            {
                _placeholderLabel.Text = customControl.Placeholder;
            }
            else if (CustomEditor.PlaceholderColorProperty.PropertyName == e.PropertyName)
            {
                _placeholderLabel.TextColor = customControl.PlaceholderColor.ToUIColor();
            }
            else if (CustomEditor.HasRoundedCornerProperty.PropertyName == e.PropertyName)
            {
                if (customControl.HasRoundedCorner)
                    Control.Layer.CornerRadius = 5;
                else
                    Control.Layer.CornerRadius = 0;
            }
            else if (CustomEditor.IsExpandableProperty.PropertyName == e.PropertyName)
            {
                if (customControl.IsExpandable)
                    Control.ScrollEnabled = false;
                else
                    Control.ScrollEnabled = true;

            }
            else if (CustomEditor.HeightProperty.PropertyName == e.PropertyName)
            {
                if (customControl.IsExpandable)
                {
                    CGSize size = Control.Text.StringSize(Control.Font, Control.Frame.Size, UILineBreakMode.WordWrap);

                    int numLines = (int)(size.Height / Control.Font.LineHeight);
                    if (numLines >= 5)
                    {
                        Control.ScrollEnabled = true;

                        customControl.HeightRequest = previousHeight;

                    }
                    else
                    {
                        Control.ScrollEnabled = false;
                        previousHeight = customControl.Height;

                    }
                }
            }
        }

        public void CreatePlaceholder()
        {
            var element = Element as CustomEditor;

            _placeholderLabel = new UILabel
            {
                Text = element?.Placeholder,
                TextColor = element.PlaceholderColor.ToUIColor(),
                BackgroundColor = UIColor.Clear
            };

            var edgeInsets = Control.TextContainerInset;
            var lineFragmentPadding = Control.TextContainer.LineFragmentPadding;

            Control.AddSubview(_placeholderLabel);

            var vConstraints = NSLayoutConstraint.FromVisualFormat(
                "V:|-" + edgeInsets.Top + "-[PlaceholderLabel]-" + edgeInsets.Bottom + "-|", 0, new NSDictionary(),
                NSDictionary.FromObjectsAndKeys(
                    new NSObject[] { _placeholderLabel }, new NSObject[] { new NSString("PlaceholderLabel") })
            );

            var hConstraints = NSLayoutConstraint.FromVisualFormat(
                "H:|-" + lineFragmentPadding + "-[PlaceholderLabel]-" + lineFragmentPadding + "-|",
                0, new NSDictionary(),
                NSDictionary.FromObjectsAndKeys(
                    new NSObject[] { _placeholderLabel }, new NSObject[] { new NSString("PlaceholderLabel") })
            );

            _placeholderLabel.TranslatesAutoresizingMaskIntoConstraints = false;

            Control.AddConstraints(hConstraints);
            Control.AddConstraints(vConstraints);
        }
    }
}