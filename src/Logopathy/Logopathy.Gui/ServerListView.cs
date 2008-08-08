using System;
using System.Collections;
using Gtk;

using Logopathy.Core;
using Logopathy.Irc;
using Logopathy.Gui;

namespace Logopathy.Gui {
    public class ServerListView : Gtk.TreeView {
        public IServer Selected {
            get {
                Gtk.TreeModel selectmodel;
                Gtk.TreeIter iter;
                
                if ( Selection.CountSelectedRows() != 0 ) {
                    Selection.GetSelected(out selectmodel, out iter);
                } else { Store.GetIterFirst(out iter); }
                
                return (IServer)Store.GetValue(iter, 2);
            }
            set {}
        }
        
        public ArrayList Servers {
            get {
                ArrayList list = new ArrayList();
                
                foreach ( object[] row in Store ) {
                    list.Add((IServer)row[2]);
                }
                
                return list;
            }
        }
        
        private Gtk.ListStore Store;
        
        public ServerListView() {
            Store = new Gtk.ListStore(typeof(Gdk.Pixbuf), // a nice icon
                                      typeof(string), // the server's name
                                      typeof(IServer));
            Model = Store;
            
            InsertColumn(-1, "Pix", new Gtk.CellRendererPixbuf(), "pixbuf", 0);
            InsertColumn(-1, "Server", new Gtk.CellRendererText(), "text", 1);
            HeadersVisible = false;
        }
        
        public void AddServer(IServer server) {
            TreeIter iter = Store.Append();
            //Store.SetValue(iter, 0, new Gdk.Pixbuf...)
            Store.SetValue(iter, 1, server.Name);
            Store.SetValue(iter, 2, server);
        }
        
        public void RemoveServer(IServer server) {
        }
    }
}
