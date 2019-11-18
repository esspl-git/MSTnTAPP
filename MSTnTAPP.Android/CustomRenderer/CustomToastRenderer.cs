using Android.App;
using Android.Widget;
using MSTnT.Droid.CustomRenderer;
using MSTnTAPP.CustomControl;

[assembly: Xamarin.Forms.Dependency(typeof(CustomToastRenderer))]
namespace MSTnT.Droid.CustomRenderer
{
    public class CustomToastRenderer : ToastAlert
    {
        public void LongAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }

        public void ShortAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
    }
}