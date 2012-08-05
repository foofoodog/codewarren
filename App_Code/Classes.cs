using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SignalR.Hubs;

public class Chat : Hub, IConnected

{
    public void Say(string message)
    {
        var dt = string.Format("{0:hh:mm:ss}", DateTime.Now);
        Clients.Echo(dt + " : " + Context.User.Identity.Name + " => " + message);
        
    }

    public Task Connect()
    {
        Say("Hi");
        return null;
    }

    public Task Reconnect(IEnumerable<string> groups)
    {
        return null;
    }
}