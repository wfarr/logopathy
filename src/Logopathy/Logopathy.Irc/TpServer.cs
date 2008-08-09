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
        
        private IChat to_sate_will;
        
        public TpServer() {
            ActiveChats = new ArrayList();
            to_sate_will = new TpChat("");
            to_sate_will.Name = "Hiya";
            ActiveChats.Add(to_sate_will);
            
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
