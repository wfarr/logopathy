using System;
using System.Collections;

using Logopathy.Core;
using Logopathy.Irc;

namespace Logopathy.Irc {
    public interface IServer {
        string Name;
        string Url;
        
        event EventHandler ChatAdded;
        event EventHandler ChatRemoved;
        
        ArrayList<IChat> ActiveChats;
        
        IChat JoinChat(string chat_name);
        bool QuitChat(IChat chat);
    }
}
