using System;
using System.Collections;

using Gtk;

namespace Logopathy.Core {
    public static class Application {
        public static Logopathy.Gui.ChatWindow ChatWindow;
        
        public static ArrayList Log;
        public static Hashtable Chats;
        
        public static void Main() {
            Gtk.Application.Init();
            
            Log = new ArrayList();
            Chats = new Hashtable();
            
            ChatWindow = new Logopathy.Gui.ChatWindow();
            ChatWindow.ShowAll();
            
            Gtk.Application.Run();
        }
    }
}
