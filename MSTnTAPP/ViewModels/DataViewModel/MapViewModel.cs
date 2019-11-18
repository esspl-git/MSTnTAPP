using System;
using Xamarin.Forms;

namespace MSTnTAPP.ViewModels.DataViewModel
{
    public class MapViewModel : BaseViewModel
    {
        public string url { get; set; }
        public MapViewModel()
        {
            url = "";
        }

        public void MapClicked()
        {
            Device.OpenUri(new Uri(url));
        }
    }
}
