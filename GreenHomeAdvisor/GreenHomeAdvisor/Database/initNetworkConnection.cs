using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenHomeAdvisor.Database
{
    public interface initNetworkConnection     //This interface will be used for platform specific network troubleshooting
    {
        bool IsConnected { get; }
        void CheckNetworkConnection();

    }
}
