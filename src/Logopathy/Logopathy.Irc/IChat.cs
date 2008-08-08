using System;
using System.Collections;
using Gtk;

using Logopathy.Core;
using Logopathy.Irc;

namespace Logopathy.Irc {
    public interface IChat {
        TextBuffer Model { get; set; }
        
        string Id { get; set; }
        string Name { get; set; }
        ChatStatus Status { get; set; }
        
        ArrayList Users { get; set; }
        
        string Username { get; set; }
        
        void Conversation(DateTime time, string username, string message);
        void Me(DateTime time, string username, string message);
    }
}
