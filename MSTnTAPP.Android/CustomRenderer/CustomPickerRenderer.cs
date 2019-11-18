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
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;
using MSTnTAPP.CustomControl;
using MSTnTAPP.Droid.CustomRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRenderer))]
namespace MSTnTAPP.Droid.CustomRenderer
{
    public class CustomPickerRenderer : PickerRenderer
    {
        CustomPicker element;
        IElementController ElementController => Element as IElementController;

        public CustomPickerRenderer(Context context) : base(context)
        {
        }

        private AlertDialog _dialog;

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            element = (CustomPicker)this.Element;

            if (Control != null && this.Element != null && !string.IsNullOrEmpty(element.Image))
            {
                Control.SetCompoundDrawablesWithIntrinsicBounds(null, null, GetDrawable(element.Image), null);

            }

            if (e.NewElement == null || e.OldElement != null)
                return;

            Control.Click += Control_Click;
        }

        protected override void Dispose(bool disposing)
        {
            Control.Click -= Control_Click;
            base.Dispose(disposing);
        }

        private void Control_Click(object sender, EventArgs e)
        {
            Picker model = Element;

            var picker = new NumberPicker(Context);
            if (model.Items != null && model.Items.Any())
            {
                // set style here
                picker.MaxValue = model.Items.Count - 1;
                picker.MinValue = 0;
                picker.SetDisplayedValues(model.Items.ToArray());
                picker.WrapSelectorWheel = false;
                picker.Value = model.SelectedIndex;
            }

            var layout = new LinearLayout(Context) { Orientation = Android.Widget.Orientation.Vertical };
            layout.AddView(picker);
            //layout.SetBackground(ContextCompat.GetDrawable(Android.App.Application.Context, Resource.Drawable.dialogBackground));

            ElementController.SetValueFromRenderer(VisualElement.IsFocusedProperty, true);

            var builder = new AlertDialog.Builder(Context);
            builder.SetView(layout);

            builder.SetTitle(model.Title ?? "");
            builder.SetNegativeButton("Cancel  ", (s, a) =>
            {
                ElementController.SetValueFromRenderer(VisualElement.IsFocusedProperty, false);
                // It is possible for the Content of the Page to be changed when Focus is changed.
                // In this case, we'll lose our Control.
                Control?.ClearFocus();
                _dialog = null;
            });
            builder.SetPositiveButton("Ok ", (s, a) =>
            {
                ElementController.SetValueFromRenderer(Picker.SelectedIndexProperty, picker.Value);
                // It is possible for the Content of the Page to be changed on SelectedIndexChanged.
                // In this case, the Element & Control will no longer exist.
                if (Element != null)
                {
                    if (model.Items.Count > 0 && Element.SelectedIndex >= 0)
                        Control.Text = model.Items[Element.SelectedIndex];
                    ElementController.SetValueFromRenderer(VisualElement.IsFocusedProperty, false);
                    // It is also possible for the Content of the Page to be changed when Focus is changed.
                    // In this case, we'll lose our Control.
                    Control?.ClearFocus();
                }
                _dialog = null;
            });

            _dialog = builder.Create();
            _dialog.DismissEvent += (ssender, args) =>
            {
                ElementController?.SetValueFromRenderer(VisualElement.IsFocusedProperty, false);
            };
            _dialog.ShowEvent += (ssender, args) =>
            {
                var dialog = (AlertDialog)ssender;
                Android.Widget.Button negativeButton = dialog.GetButton(DialogButtonType.Negative.GetHashCode());
                negativeButton.SetTextColor(Android.Graphics.Color.Gray);
            };

            _dialog.Show();
        }

        /*public override void onShow(final DialogInterface dialog)
        {

        }*/

        private BitmapDrawable GetDrawable(string imagePath)
        {
            int resID = Resources.GetIdentifier(imagePath, "drawable", this.Context.PackageName);
            var drawable = ContextCompat.GetDrawable(this.Context, resID);
            var bitmap = ((BitmapDrawable)drawable).Bitmap;

            // Handle the image size here
            var result = new BitmapDrawable(Resources, Bitmap.CreateScaledBitmap(bitmap, 13, 13, true));
            result.Gravity = Android.Views.GravityFlags.Right;

            return result;
        }
    }
}