using System;
using System.Collections;

using Logopathy.Core;
using Logopathy.Irc;

namespace Logopathy.Irc {
    public interface TpServer : IServer {
        public string Name;
        public string Url;
        
        public ArrayList<IChat> ActiveChats;
        
        public event EventHandler ChatAdded;
        public event EventHandler ChatRemoved;
        
        public TpServer() {
            ActiveChats = new ArrayList<IChat>();
            //FIXME
        }
        
        public IChat JoinChat(string chat_name) {
        }
        
        public bool QuitChat(IChat chat) {
        }
    }
}
