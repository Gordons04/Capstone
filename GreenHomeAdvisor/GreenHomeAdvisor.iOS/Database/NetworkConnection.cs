using System;
using System.Collections.Generic;
using System.Text;
using GreenHomeAdvisor.Database;
using SystemConfiguration;
using CoreFoundation;
using GreenHomeAdvisor.iOS.Database;
using Xamarin.Forms;

[assembly: Dependency(typeof(NetworkConnection))]

namespace GreenHomeAdvisor.iOS.Database
{
    public class NetworkConnection : initNetworkConnection
    {
        private NetworkReachability defaultReachability;

        private event EventHandler ReachabilityChanged;

        private void OnChange(NetworkReachabilityFlags flags)
        {
            var handler = ReachabilityChanged;
            if (handler != null)
            {
                handler(null, EventArgs.Empty);
            }
        }

        public bool IsConnected { get; set; }

        public void CheckNetworkConnection()
        {
            InternetStatus();
        }

        public bool InternetStatus()
        {
            NetworkReachabilityFlags flags;
            bool defaultNetworkAvailable = IsNetworkAvailable(out flags);
            if(defaultNetworkAvailable && ((flags & NetworkReachabilityFlags.IsDirect) != 0))
            {
                return false;
            }
            else if((flags & NetworkReachabilityFlags.IsWWAN) != 0)
            {
                return true;
            }
            else if(flags == 0)
            {
                return false;
            }

            return true;

        }

        public bool IsNetworkAvailable(out NetworkReachabilityFlags flags)
        {
            if(defaultReachability == null)
            {
                defaultReachability = new NetworkReachability(new System.Net.IPAddress(0));
                defaultReachability.SetNotification(OnChange);
                defaultReachability.Schedule(CFRunLoop.Current, CFRunLoop.ModeDefault);
            }

            if(!defaultReachability.TryGetFlags(out flags))
            {
                return false;
            }
            return IsReachableWithoutRequiredConnection(flags);

        }

        private bool IsReachableWithoutRequiredConnection(NetworkReachabilityFlags flags)
        {
            bool isReachable = (flags & NetworkReachabilityFlags.Reachable) != 0;
            bool noConnectionRequired = (flags & NetworkReachabilityFlags.ConnectionRequired) == 0;

            if((flags & NetworkReachabilityFlags.IsWWAN) != 0)
            {
                noConnectionRequired = true;
            }

            return (isReachable && noConnectionRequired);
        }
    }
}
