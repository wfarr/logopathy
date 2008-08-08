using System;
using System.Collections;
using Gtk;

using Logopathy.Core;
using Logopathy.Irc;

namespace Logopathy.Gui {
    public class ChatNotebook : Gtk.Notebook {
        public IServer Server;
        
        private Hashtable hash;
        private ArrayList AddedChats;
        private Hashtable ChatToPage;
        
        public IChat CurrentChat {
            get {
                Bin c = (Gtk.Bin)GetNthPage(Page);
                ChatView cv = (ChatView)c.Child;
                return cv.Chat;
            }
        }
        
        public ChatNotebook(IServer server) : base() {
            Scrollable = true;
            Server = server;
            
            hash = new Hashtable();
            AddedChats = new ArrayList();
            ChatToPage = new Hashtable();
            
            foreach ( IChat chat in Server.ActiveChats ) {
                AppendChat(chat);
            }
            
            Server.ChatAdded += OnChatAdded;
            Server.ChatRemoved += OnChatRemoved;
        }
        
        private void AppendChat(IChat chat) {
            Gtk.HBox container = new Gtk.HBox();
            Gtk.Label label = new Gtk.Label(chat.Name);
            container.PackStart(label);
            Gtk.Button button = new Gtk.Button(new Gtk.Image(Gtk.IconTheme.Default.LookupIcon("gtk-close", 16, Gtk.IconLookupFlags.NoSvg).LoadIcon()));
            button.Clicked += OnClicked;
            button.Relief = Gtk.ReliefStyle.None;
            button.SetSizeRequest(20, 20);
            container.PackEnd(button);
            
            Gtk.TextView view = new Logopathy.Gui.ChatView(chat);
            ScrolledWindow view_swin = new Gtk.ScrolledWindow(new Gtk.Adjustment(0, 0, 0, 0, 0, 0), new Gtk.Adjustment(0, 0, 0, 0, 0, 0));
            view_swin.Add(view);
            view_swin.SetPolicy(Gtk.PolicyType.Automatic, Gtk.PolicyType.Automatic);
            
            hash.Add(container, view);
            
            int pos = AppendPage(view_swin, container);
            container.ShowAll();
            
            ShowAll();
            
            AddedChats.Add(chat);
            ChatToPage.Add(chat, pos);
        }
        
        private void RemoveChat(IChat chat) {
            RemovePage((int)ChatToPage[chat]);
            AddedChats.Remove(chat);
            
            ChatToPage.Remove(chat);
        }
        
        private void OnClicked(object obj, EventArgs args) {
            Button b = (Gtk.Button)obj;
            Gtk.Widget o = (Gtk.Widget)hash[b.Parent];
            int pos = PageNum(o.Parent);
            RemovePage(pos);
            hash.Remove(b.Parent);
            foreach ( DictionaryEntry entry in ChatToPage ) {
                if ( (int)entry.Value == pos ) {
                    ChatToPage.Remove((IChat)entry.Key);
                }
            }
            
            ShowAll();
        }
        
        private void OnChatAdded(object obj, EventArgs args) {
            foreach ( IChat chat in Server.ActiveChats ) {
                if ( !AddedChats.Contains(chat) ) {
                    AppendChat(chat);
                }
            }
        }
        
        private void OnChatRemoved(object obj, EventArgs args) {
            foreach ( IChat chat in AddedChats ) {
                if ( !Server.ActiveChats.Contains(chat) ) {
                    RemoveChat(chat);
                }
            }
        }
    }
}
