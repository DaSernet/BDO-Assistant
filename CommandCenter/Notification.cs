using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BDOAssistant
{
    class Notification
    {
        private readonly NotifyIcon _notifyIcon;

        public Notification()
        {
            _notifyIcon = new NotifyIcon();
            // Extracts your app's icon and uses it as notify icon
            _notifyIcon.Icon = Properties.Resources.logo;
            // Hides the icon when the notification is closed
            _notifyIcon.BalloonTipClosed += (s, e) => _notifyIcon.Visible = false;


        }

        public void ShowNotification(String Title, String Message)
        {
            _notifyIcon.Visible = true;
            // Shows a notification with specified message and title

            _notifyIcon.ShowBalloonTip(3000, Title, Message, ToolTipIcon.Info);
        }

    }
}
