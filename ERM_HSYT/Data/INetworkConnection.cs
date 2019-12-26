using System;
using System.Collections.Generic;
using System.Text;

namespace ERM_HSYT.Data
{
    public interface INetworkConnection
    {
        bool IsConnected { get; set; }
        void CheckNetWorkConnection();
    }
}
