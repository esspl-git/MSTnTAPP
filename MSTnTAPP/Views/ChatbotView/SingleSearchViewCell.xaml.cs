using MSTnTAPP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSTnTAPP.Views.ChatbotView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SingleSearchViewCell : ViewCell
    {
        ChatbotPageViewModel vm;
        
        public SingleSearchViewCell()
        {
            InitializeComponent();
            BindingContext = vm = new ChatbotPageViewModel();
            vm.Navigation = Application.Current.MainPage.Navigation;
        }
    }
}