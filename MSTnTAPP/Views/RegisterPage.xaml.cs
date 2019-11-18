using FormsControls.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSTnTAPP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : AnimationPage
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private async void OnBackIconTapped(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
          
        }
    }
}