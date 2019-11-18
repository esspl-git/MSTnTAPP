using Android.Support.Design.Widget;
using MSTnTAPP.CustomControl;
using MSTnTAPP.Droid.CustomRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(CustomTabPage), typeof(CustomTabRenderer))]
namespace MSTnTAPP.Droid.CustomRenderer
{
    public class CustomTabRenderer : TabbedPageRenderer
    {
        public override void OnViewAdded(Android.Views.View child)
        {
            base.OnViewAdded(child);
            var tabLayout = child as TabLayout;
            if (tabLayout != null)
            {
                tabLayout.TabMode = TabLayout.ModeScrollable;
            }
        }
    }
}