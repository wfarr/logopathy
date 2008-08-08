using System;
using Gtk;

using Logopathy.Core;
using Logopathy.Irc;

namespace Logopathy.Gui {
    public class UserView : Gtk.TreeView {
        private Gtk.ListStore Store;
        
        public UserView() {
            Store = new Gtk.ListStore(typeof(Gdk.Pixbuf), typeof(string));
            Model = Store;
            
            InsertColumn(-1, "Pix", new Gtk.CellRendererPixbuf(), "pixbuf", 0);
            InsertColumn(-1, "Name", new Gtk.CellRendererText(), "text", 1);
            HeadersVisible = false;
            
            string[] users = new string[10];
            users[0] = "Bob";
            users[1] = "Bill";
            users[2] = "Norma Jean";
            users[3] = "Susie";
            users[4] = "Katie";
            users[5] = "Mbutu";
            users[6] = "KoolKat74383u";
            
            foreach ( string user in users ) {
                Gtk.TreeIter iter = Store.Append();
                Model.SetValue(iter, 0, null);
                Model.SetValue(iter, 1, user);
            }
        }
        
        public void Populate(IChat chat) {
            foreach ( IUser user in chat.Users ) {
            }
        }
    }
}
