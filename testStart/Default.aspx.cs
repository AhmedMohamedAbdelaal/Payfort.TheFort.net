using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Start.Net.Tests;
using System.Net;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void btnTest_Click(object sender, EventArgs e)
    {
        string IPAddress = GetIPAddress();
        ChargeServiceTests obj = new ChargeServiceTests(IPAddress);        
        obj.CreateCharge_UsingCardDetails_Success();
    }

    public string GetIPAddress()
    {
        string IPAddress = "";
        IPHostEntry Host = default(IPHostEntry);
        string Hostname = null;
        Hostname = System.Environment.MachineName;
        Host = Dns.GetHostEntry(Hostname);
        foreach (IPAddress IP in Host.AddressList)
        {
            if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                IPAddress = Convert.ToString(IP);
            }
        }
        return IPAddress;

    }
}