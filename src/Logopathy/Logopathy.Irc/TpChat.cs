using System;
using System.Collections;
using Gtk;

using Logopathy.Core;
using Logopathy.Irc;

namespace Logopathy.Irc {
    public class TpChat : IChat {
        private TextBuffer model;
        public TextBuffer Model {
            get {
                return model;
            }
            set {
                model = value;
            }
        }
        
        private string id;
        public string Id {
            get {
                return id;
            }
            set {
                id = value;
            }
        }
        
        private string name;
        public string Name {
            get {
                return name;
            }
            set {
                name = value;
            }
        }
        private ChatStatus status;
        public ChatStatus Status {
            get {
                return status;
            }
            set {
                status = value;
            }
        }
        
        private string username;
        public string Username {
            get {
                return username;
            }
            set {
                username = value;
            }
        }
        
        private ArrayList users;
        public ArrayList Users {
            get {
                return users;
            }
            set {
                users = value;
            }
        }
        
        public TpChat(string chatid /*FIXME when we have telepathy-glib-sharp &c.*/) {
            this.Id = chatid;
            
            this.Model = new Gtk.TextBuffer(new Gtk.TextTagTable());
            
            this.Name = "Something"; //FIXME when we can fetch this
            this.Status = ChatStatus.AllRead;
            
            this.Username = "Me"; //FIXME same as Name
            
            /* FIXME - there should be various event watches here for signals
               when the Telepathy chat has new messages, status changes, etc.
               But that depends on working bindings. */
        }
        
        public void Conversation(DateTime time, string username, string message) {
            string text = String.Format("<{0}> <b>*{1}</b>: {2}",Util.MakePrettyDate(time), username, message);
            AppendText(text);
        }
        
        public void Me(DateTime time, string username, string message) {
            string text = String.Format("<{0}> <b>*{1} {2}</b>", Util.MakePrettyDate(time), username, message);
            AppendText(text);
        }
        
        private void AppendText(string text) {
            Model.Text += text+"\n";
        }
    }
}
