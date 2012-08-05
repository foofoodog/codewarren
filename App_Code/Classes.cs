using System;
using System.Web;
using SignalR;
using System.Threading.Tasks;
using SignalR.Hubs;

//public class MyConnection : PersistentConnection
//{
//    protected override Task OnReceivedAsync(string clientId, string data)
//    {
//        // Broadcast data to all clients        
//        return Connection.Broadcast(data);
//    }
//}

public class Chat : Hub
{
    public void Send(string message)
    {
        // Call the addMessage method on all clients  

        var user = HttpContext.Current.Request.ServerVariables["AUTH_USER"];
        var dt = string.Format("{0:hh:mm:ss}", DateTime.Now);
        Clients.addMessage(dt + " : " + user + " => " + message);
    }
}