using System;
using System.Collections;

using Logopathy.Core;
using Logopathy.Irc;

namespace Logopathy.Irc {
    public class TpServer : IServer {
        private string name;
        public string Name {
            get {
                return name;
            }
            set {
                name = value;
            }
        }
        private string url;
        public string Url {
            get {
                return url;
            }
            set {
                url = value;
            }
        }
        
        private ArrayList active_chats;
        public ArrayList ActiveChats {
            get {
                return active_chats;
            }
            set {
                active_chats = value;
            }
        }
        
        public event EventHandler ChatAdded;
        public event EventHandler ChatRemoved;
        
        public TpServer() {
            ActiveChats = new ArrayList();
            IChat chat1 = new TpChat("");
            chat1.Name = "Hiya";
            ActiveChats.Add(chat1);
            
            //FIXME
        }
        
        public IChat JoinChat(string chat_name) {
            return new TpChat("");
        }
        
        public bool QuitChat(IChat chat) {
            return false;
        }
    }
}
