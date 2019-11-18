using System;
using System.Collections.Generic;
using System.Text;

namespace MSTnTAPP.CustomControl
{
    public interface ToastAlert
    {
        void LongAlert(string message);
        void ShortAlert(string message);
    }
}
