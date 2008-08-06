using System;
using System.Collections;
using Gtk;

using Logopathy.Core;
using Logopathy.Irc;

namespace Logopathy.Irc {
    public interface IChat {
        TextBuffer Model;
        string Id;
        string Name;
        ChatStatus Status;
        
        ArrayList<IUser> Users;
        
        string Username;
        
        void Conversation(DateTime time, string username, string message);
        void Me(DateTime time, string username, string message);
    }
}
