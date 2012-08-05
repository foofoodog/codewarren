using System;
using SignalR.Hubs;

public class Chat : Hub

{
    public void Say(string message)
    {
        var dt = string.Format("{0:hh:mm:ss}", DateTime.Now);
        Clients.Echo(dt + " : " + Context.User.Identity.Name + " => " + message);
        
    }

}