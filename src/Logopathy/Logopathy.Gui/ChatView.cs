using System;
using Gtk;

using Logopathy.Core;
using Logopathy.Irc;

namespace Logopathy.Gui {
    public class ChatView : Gtk.TextView {
        public IChat Chat;
        
        public ChatView(IChat chat) : base() {
            Chat = chat;
            
            Buffer = Chat.Model;
        }
    }
}
