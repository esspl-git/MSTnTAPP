using MSTnTAPP.Views.ChatbotView;
using Xamarin.Forms;
using MSTnTAPP.Models;

namespace MSTnTAPP.Util
{
    public class ChatTemplateSelector : DataTemplateSelector
    {
        DataTemplate incomingDataTemplate;
        DataTemplate outgoingDataTemplate;
        DataTemplate singleSearchDataTemplate;
        DataTemplate multiSearchDataTemplate;

        public ChatTemplateSelector()
        {
            this.incomingDataTemplate = new DataTemplate(typeof(IncomingViewCell));
            this.outgoingDataTemplate = new DataTemplate(typeof(OutgoingViewCell));
            this.singleSearchDataTemplate = new DataTemplate(typeof(SingleSearchViewCell));
            this.multiSearchDataTemplate = new DataTemplate(typeof(MultiSearchViewCell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var messageVm = item as ChatbotMessage;
            if (messageVm == null)
                return null;

            if(messageVm.IsBotResponse)
            {
                if (messageVm.IsSingleSearch)
                {
                    return singleSearchDataTemplate;
                }
                else if (messageVm.IsMultiSearch)
                {
                    return multiSearchDataTemplate;
                }
                return incomingDataTemplate;
            } else
            {
                return outgoingDataTemplate;
            }
        }
    }
}
