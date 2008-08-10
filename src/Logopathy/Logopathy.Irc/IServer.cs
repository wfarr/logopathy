using System;
using System.Collections;

using Logopathy.Core;
using Logopathy.Irc;

namespace Logopathy.Irc {
    public interface IServer {
        string Name { get; set; }
        string Url { get; set; }
        
        event EventHandler ChatAdded;
        event EventHandler ChatRemoved;
        
        ArrayList ActiveChats { get; set; }
        
        IAccount Account { get; set; }
        
        IChat JoinChat(string chat_name);
        bool QuitChat(IChat chat);
    }
}
