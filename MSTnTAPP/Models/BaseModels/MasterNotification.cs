using System.Collections.Generic;

namespace MSTnTAPP.Models
{
    public class MasterNotification : List<Notification>
    {
        public string Title { get; set; }
        public string ShortName { get; set; } //will be used for jump lists
        public MasterNotification(string title, string shortName)
        {
            Title = title;
            ShortName = shortName;

        }
    }
}
