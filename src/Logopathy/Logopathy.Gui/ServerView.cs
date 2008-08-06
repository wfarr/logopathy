using System;
using Gtk;

using Logopathy.Core;

namespace Logopathy.Gui {
    public class ServerView : Gtk.TreeView {
        public Chat Selected {
            get {
                Gtk.TreeModel selectmodel;
                Gtk.TreeIter iter;
                
                if ( Selection.CountSelectedRows() != 0 ) {
                    Selection.GetSelected(out selectmodel, out iter);
                } else { Store.GetIterFirst(out iter); }
                
                string val = (string)Store.GetValue(iter, 1);
                
                if ( val != null ) {
                    return Logopathy.Core.Application.Chats[val];
                }
                return null;
            }
            set {
                store.GetIterFirst(out iter);
                
                bool has_chat = false;
                
                while ( !has_chat ) {
                    GLib.Value idvalue = new GLib.Value("");
                    if ( !Store.IterIsValid(iter) ) {
                        break;
                    }
                    store.GetValue(iter, 1, ref idvalue);
                    if ( (string)idvalue.Val ) {
                        Store.IterNext( ref iter );
                    } else {
                        has_chat = true;
                        Selection.SelectIter(iter);
                        ScrollToCell(Store.GetPath(iter), null, false, 0, 0);
                        break;
                    }
                }
            }
        }
        
        private Gtk.ListStore Store;
        
        public ChannelView() {
            Store = new Gtk.ListStore(typeof(Gdk.Pixbuf), // the icon, from Chat.Status
                                      typeof(string), // the chat's ID FIXME
                                      typeof(string)); //the chat's name
            Model = Store;
            
            InsertColumn(-1, "Pix", new Gtk.CellRendererPixbuf(), "pixbuf", 0);
            InsertColumn(-1, "Chat", new Gtk.CellRendererText(), "text", 2);
            HeadersVisible = false;
        }
        
        public void AddChat(Chat chat) {
            TreeIter iter = Store.Append();
            //Store.SetValue(iter, 0, new Gdk.Pixbuf...)
            Store.SetValue(iter, 1, chat.Id);
            Store.SetValue(iter, 2, chat.Name);
        }
        
        public void RemoveChat(Chat chat) {
            
        }
    }
}
