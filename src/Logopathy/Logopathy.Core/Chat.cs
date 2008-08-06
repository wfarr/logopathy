using System;

using Logopathy.Core;

namespace Logopathy.Core {
    public class Chat {
        public Gtk.TextBuffer Model;
        
        public string Id;
        
        public string Name;
        public ChatStatus Status;
        
        public string Username;
        
        public Chat(string chatid /*FIXME when we have telepathy-glib-sharp &c.*/) {
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
            string text = String.Format("\<{0}\> <b>*{1}</b>: {2}",this.MakePrettyDate(time), username, message);
            AppendText(text);
        }
        
        public void Me(DateTime time, string username, string message) {
            string text = String.Format("\<{0}\> <b>*{1} {2}</b>", this.MakePrettyDate(time), username, message);
            AppendText(text);
        }
        
        private void AppendText(string text) {
            Model.Text += text+"\n";
        }
        
        private string MakePrettyDate(DateTime dtdate) {
            string hour;
            string minute;
            string second;
            
            if ( dtdate.Hour.ToString().Length == 1 ) {
                hour = "0"+dtdate.Hour.ToString();
            } else {
                hour = dtdate.Hour.ToString();
            }
            
            if ( dtdate.Minute.ToString().Length == 1 ) {
                minute = "0"+dtdate.Minute.ToString();
            } else {
                minute = dtdate.Minute.ToString();
            }
            
            if ( dtdate.Second.ToString().Length == 1 ) {
                second = "0"+dtdate.Second.ToString();
            } else {
                second = dtdate.Second.ToString();
            }
            
            return hour+":"+minute+":"+second;
        }
    }
}
