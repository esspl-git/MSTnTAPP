using MSTnTAPP.CustomControl;
using MSTnTAPP.Util;
using MSTnTAPP.ViewModels;
using MSTnTAPP.Views.ChatbotView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MSTnTApp.Views.Partials
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChatInputBarView : ContentView
    {
        public ChatInputBarView()
        {
            InitializeComponent();

            if (Device.RuntimePlatform == Device.iOS)
            {
                this.SetBinding(HeightRequestProperty, new Binding("Height", BindingMode.OneWay, null, null, null, chatTextInput));
            }

            chatTextInput.Focus();
        }

        public void Handle_Completed(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("----------------------------------------------------chatTextInput.Text:" + chatTextInput.Text);

            string text = chatTextInput.Text;
            if (string.IsNullOrEmpty(text))
            {
                DependencyService.Get<ToastAlert>().ShortAlert("Please type a question to send.");
            } else
            {
                (this.Parent.Parent.BindingContext as ChatbotPageViewModel).OnSendCommand.Execute(text);
            }
        }

        public void UnFocusEntry()
        {
            chatTextInput?.Unfocus();
        }
    }
}